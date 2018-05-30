using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SkypeClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient clientt = new TcpClient();
            Client client = new Client();
            bool exit = true;
            while (exit)
            {
                Console.WriteLine("Введите путь -- для выхода 4");
                string path = Console.ReadLine();
                var task = client.Working(clientt,path);
                //task.Wait();
                exit = task.Result;
                task.Dispose();
            }
            
           
        }
    }
}
