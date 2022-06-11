using System;
using System.Threading;
using WcfServiceTestExample.ServiceReference1;

namespace WcfServiceTestExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            string result = client.GetData(12);
            Console.WriteLine(result);
            client.Close();
            Console.ReadLine();
        }
    }
}
