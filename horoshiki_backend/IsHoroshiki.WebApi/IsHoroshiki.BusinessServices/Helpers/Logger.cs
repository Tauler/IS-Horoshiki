using NLog;
using NLog.Config;
using System.IO;
using System.Reflection;

namespace IsHoroshiki.BusinessServices.Helpers
{
    /// <summary>
    /// Класс логирования
    /// </summary>
    public class Logger
    {
        #region поля и свойства

        /// <summary>
        /// Логирование
        /// </summary>
        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        static Logger()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#if DEBUG
            var path = Path.Combine(directoryName, "NLog.config");
#else
            var path = Path.Combine(directoryName, "NLog.config");
#endif
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                LogManager.Configuration = new XmlLoggingConfiguration(path);
            }
        }

        #endregion

        #region методы

        /// <summary>
        /// Запись в лог
        /// </summary>
        /// <param name="message">Сообщение лога</param>
        /// <param name="pars">Дополнительный данные лога</param>
        public static void Error(string message, params object[] pars)
        {
            _logger.Error(message, pars);
        }

        /// <summary>
        /// Запись в лог
        /// </summary>
        /// <param name="message">Сообщение лога</param>
        /// <param name="pars">Дополнительный данные лога</param>
        public static void Debug(string message, params object[] pars)
        {
            _logger.Debug(message, pars);
        }

        /// <summary>
        /// Запись в лог
        /// </summary>
        /// <param name="message">Сообщение лога</param>
        /// <param name="pars">Дополнительный данные лога</param>
        public static void Info(string message, params object[] pars)
        {
            _logger.Info(message, pars);
        }


        /// <summary>
        /// Запись в лог
        /// </summary>
        /// <param name="message">Сообщение лога</param>
        /// <param name="pars">Дополнительный данные лога</param>
        public static void Warn(string message, params object[] pars)
        {
            _logger.Warn(message, pars);
        }

        #endregion
    }
}
