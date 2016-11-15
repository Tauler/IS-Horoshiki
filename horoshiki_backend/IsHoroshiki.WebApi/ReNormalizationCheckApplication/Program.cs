using System;
using IsHoroshiki.BusinessServices.Integrations.Queues;

namespace ReNormalizationCheckApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            IntegrationCheckQueue.Instance.Load();
            IntegrationCheckQueue.Instance.Start();

            while (IntegrationCheckQueue.Instance.Count > 0)
            {
                Console.WriteLine("Осталось чеков: {0}", IntegrationCheckQueue.Instance.Count);
                System.Threading.Thread.Sleep(500);
            }

            sw.Stop();

            Console.WriteLine("Выполнилось за: {0}", sw.Elapsed);
            Console.ReadLine();
        }
    }
}
