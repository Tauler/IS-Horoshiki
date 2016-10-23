using System;
using System.Globalization;
using System.Threading;

namespace IsHoroshiki.BusinessServices.Helpers
{
    /// <summary>
    /// Вызывает делегат с заданным интервалом
    /// </summary>
    public class RecurrentTask : IDisposable
    {
        /// <summary>
        /// Интервал между вызовами
        /// </summary>
        protected TimeSpan _interval;

        /// <summary>
        /// Делегат, который необходимо вызвать
        /// </summary>
        protected Action _body;

        /// <summary>
        /// CancellationTokenSource
        /// </summary>
        protected CancellationTokenSource _threadCts;

        /// <summary>
        /// Флаг запущенности задачи
        /// </summary>
        protected bool _isStarted;

        /// <summary>
        /// Примитив синхронизации
        /// </summary>
        protected object _lock = new object();

        /// <summary>
        /// Поток
        /// </summary>
        protected Thread _thread;

        /// <summary>
        /// Наименование потока
        /// </summary>
        protected string _name;

        /// <summary>
        /// Время последней итерации
        /// </summary>
        private DateTime _lastCallTime;

        /// <summary>
        /// Флаг необходимости ожидания перед первым вызовом делегата.
        /// true, если перед вызовом делегата нужно пропустить один интервал.
        /// false, если делегат нужно вызвать немедленно
        /// </summary>
        private bool _waitBeforeFirstCall;

        /// <summary>
        /// Интервал
        /// </summary>
        public TimeSpan Interval
        {
            get
            {
                return this._interval;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="interval">Интервал</param>
        /// <param name="name">Наименование задачи</param>
        /// <param name="waitBeforeFirstCall">Флаг необходимости ожидания перед первым вызовом делегата.
        /// true, если перед вызовом делегата нужно пропустить один интервал.
        /// false, если делегат нужно вызвать немедленно</param>
        protected RecurrentTask(TimeSpan interval, string name, bool waitBeforeFirstCall)
        {
            this._interval = interval;
            this._name = name;
            this._waitBeforeFirstCall = waitBeforeFirstCall;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="interval">Интервал между вызовами</param>
        /// <param name="body">Делегат, который необходимо вызвать</param>
        /// <param name="name">Наименование задачи</param>
        /// <param name="waitBeforeFirstCall">Флаг необходимости ожидания перед первым вызовом делегата.
        /// true, если перед вызовом делегата нужно пропустить один интервал.
        /// false, если делегат нужно вызвать немедленно</param>
        public RecurrentTask(TimeSpan interval, Action body, string name, bool waitBeforeFirstCall = false)
            : this(interval, name, waitBeforeFirstCall)
        {
            this._body = body;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="interval">Интервал между вызовами(миллисекунды)</param>
        /// <param name="body">Делегат, который необходимо вызвать</param>
        /// <param name="name">Наименование задачи</param>
        /// <param name="waitBeforeFirstCall">Флаг необходимости ожидания перед первым вызовом делегата.
        /// true, если перед вызовом делегата нужно пропустить один интервал.
        /// false, если делегат нужно вызвать немедленно</param>
        public RecurrentTask(int interval, Action body, string name, bool waitBeforeFirstCall = false)
            : this(TimeSpan.FromMilliseconds(interval), name, waitBeforeFirstCall)
        {
            this._body = body;
        }

        #region IStartable Members

        /// <summary>
        /// Запускает компонент
        /// </summary>
        public void Start()
        {
            lock (this._lock)
            {
                if (this._isStarted)
                {
                    return;
                }
                this._threadCts = new CancellationTokenSource();
                this._isStarted = true;
                this.StartEx();
            }
        }

        /// <summary>
        /// Останавливает компонент
        /// </summary>
        public void Stop()
        {
            if (this._threadCts != null)
            {
                this._threadCts.Cancel();
                if (!this._thread.Join(1000))
                {
                    this._thread.Abort();
                }
            }
            lock (this._lock)
            {
                this._isStarted = false;
            }
        }

        #endregion

        private void StartEx()
        {
            lock (this._lock)
            {
                if (this._isStarted)
                {
                    CultureInfo uiCulture = Thread.CurrentThread.CurrentUICulture;
                    this._thread = new Thread(this.Iterate);
                    this._thread.IsBackground = true;
                    this._thread.CurrentUICulture = uiCulture;
                    this._thread.Start();
                }
            }
        }

        private void Iterate()
        {
            string oldThreadName = Thread.CurrentThread.Name;
            string logContext = "RecurrentTask";
            if (this._name != null)
            {
                logContext = logContext + " (" + this._name + ")";
                Thread.CurrentThread.Name = this._name;
            }

            try
            {
                bool firstCall = true;
                this._lastCallTime = DateTime.UtcNow;

                while (!this._threadCts.Token.IsCancellationRequested)
                {
                    if (firstCall)
                    {
                        firstCall = false;
                        if (this._waitBeforeFirstCall)
                        {
                            Thread.Sleep(this._interval);
                        }
                    }
                    else
                    {
                        TimeSpan span = DateTime.UtcNow - this._lastCallTime;
                        if (span < this._interval)
                        {
                            TimeSpan toSleep = this._interval - span;
                            Thread.Sleep(toSleep);
                        }
                        this._lastCallTime = DateTime.UtcNow;
                    }

                    try
                    {
                        this._body();
                    }
                    catch (ThreadAbortException ex)
                    {
                        Logger.Error("Поток: {0}. Исключение:{1}", logContext, ex.Message);
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Поток: {0}. Исключение:{1}", logContext, ex.Message);
                    }
                }
            }
            catch (ThreadAbortException ex)
            {
                Logger.Error("Поток: {0}. Исключение:{1}", logContext, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error("Поток: {0}. Исключение:{1}", logContext, ex.Message);
            }
        }

        /// <summary>
        /// Возвращает время текущей итерации
        /// </summary>
        public DateTime GetCurrentIterationTime()
        {
            return this._lastCallTime;
        }

        /// <summary>
        /// Возвращает время текущей итерации за вычетом интервала вызовов
        /// </summary>
        public DateTime GetPreviousIterationTime()
        {
            return this._lastCallTime - this._interval;
        }

        #region IDisposable Members

        /// <summary>
        /// Освобождает ресурсы
        /// </summary>
        public void Dispose()
        {
            this.Stop();
        }

        #endregion
    }
}
