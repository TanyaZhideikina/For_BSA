using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Threading;

namespace CheckAvailability
{
    internal class Program
    {
        private static Ping Pinger = new Ping();
        private static PingReply reply;

        private static void PingSite()
        {
            Pinger.SendPingAsync("http://dou.ua/");
            Console.Write("dou.ua is available");
            Thread.Sleep(1000);
        }

        private static void Main(string[] args)
        {
            try
            {
                PingSite();
            }
            catch
            {
                Console.Write(reply.Status);
                Thread.Sleep(1000);
                string text = reply.Status.ToString();
                System.IO.File.WriteAllText(
                @"D:\Documents\Visual Studio 2013\Projects\CheckAvailability\WriteError.txt", text);
                File.WriteAllText(@"D:\Documents\Visual Studio 2013\Projects\CheckAvailability\WriteError.log", text);

            }
        }
    }
}
