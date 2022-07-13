/*
using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace levantamiento.Conections.rabbit
{
    public class ConsumerRabbit2: IConsumerRabbit
    {
        private Exchanges _exchange;
        private Routings _routing;
        private QueueNames _queueName;

        private ConnectionFactory factory = new ConnectionFactory() {
            HostName = "localhost"
        };

        public void configureRabbit (Exchanges exchange, Routings routing, QueueNames queueName)
        {
            _exchange = exchange;
            _routing = routing;
            _queueName = queueName;
        }

        public Task<List<string>> StartAsync(CancellationToken cancelToken = default)
        {
            return Task.Run(async () => await Consume(), cancelToken);
        }

        private Task<List<string>> Consume()
        {
            List<string> messages = new List<string>();

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

      //  RabbitMessageReceiver receiver = new RabbitMessageReceiver(channel, _serializer, _handleMessage);

      //      channel.BasicConsume(_queueName.ToString(), false, receiver);

      //      return Task.FromResult(new List<string>(messages));

                    
            channel.ExchangeDeclare(
                exchange: _exchange.ToString(),
                type:ExchangeType.Direct, 
                durable:true
                );

            channel.QueueBind(
                queue:_queueName.ToString(), 
                exchange: _exchange.ToString(), 
                routingKey: _routing.ToString()
                );

            var consumer=new EventingBasicConsumer(channel);

            channel.BasicConsume(
                queue:_queueName.ToString(), 
                autoAck: false, 
                consumer: consumer
                );
            
            consumer.Received += (model, ea)=>
            {
                    var body = ea.Body.ToArray();
                    messages.Add(Encoding.UTF8.GetString(body));
                    Console.WriteLine(" [x] Received {0}", Encoding.UTF8.GetString(body));
            };
                
            return Task.FromResult<List<string>>(messages);
        }

    }
}
*/