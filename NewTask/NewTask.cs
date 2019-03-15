using System;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NewTask.Services;
using System.IO;

namespace Services
{
    class Program
    {     
        static void Main(string[] args)
        {

            ServiceProvider serviceProvider = new ServiceCollection()
                      
            .AddSingleton<ISendMessageService, SendMessageService>()
            .BuildServiceProvider();

            ISendMessageService sendMessageServ = serviceProvider.GetService<ISendMessageService>();

            sendMessageServ.SendMessage(args);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
