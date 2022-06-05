using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServer;


namespace ConsoleHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ServiceCursor)))
            {
                host.Open();
                Console.WriteLine("Запуск сервера");
                Console.ReadLine();
            }
        }
    }
}
