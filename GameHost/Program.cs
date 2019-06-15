using System;
using System.ServiceModel;
using GameService;

namespace GameHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Game));
            sh.AddServiceEndpoint(typeof(IGame), new NetTcpBinding(), "net.tcp://localhost/Game/ep1");
            sh.Open();
            Console.WriteLine("Служба Game запущена.");
            Console.WriteLine("Для завершения нажмите <ENTER>\n");
            Console.ReadLine();
            sh.Close();
        }
    }
}