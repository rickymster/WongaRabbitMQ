using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Worker.WorkerServices;

namespace Services
{
    class Worker
    {       
        public static void Main(string[] args)
        {            
            ServiceProvider serviceProvider = new ServiceCollection()                    
           .AddSingleton<IWorkerService, WorkerService>()
           .BuildServiceProvider();

            IWorkerService workerServ = serviceProvider.GetService<IWorkerService>();

            workerServ.GetResponse();

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

