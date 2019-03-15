using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.IO;
using System.Text;

namespace NewTask.Services
{
    public class SendMessageService : ISendMessageService
    {      
        public string SendMessage(string[] args)
        {           
            ServiceProvider serviceProvider = new ServiceCollection()           
           .AddSingleton<IGetMessageService, GetMessageService>()         
           .BuildServiceProvider();

            IGetMessageService messageService = serviceProvider.GetService<IGetMessageService>();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = messageService.GetName(args);

                string messageString = "";
                if (string.IsNullOrEmpty(message))
                {
                    messageString = " [x] No Name Sent {0}";                    

                    Console.WriteLine(messageString);

                    return messageString;
                }

                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);

                messageString = string.Format(" [x] Sent {0}", message);                

                Console.WriteLine(messageString);

                return messageString;
            }
        }
    }
}
