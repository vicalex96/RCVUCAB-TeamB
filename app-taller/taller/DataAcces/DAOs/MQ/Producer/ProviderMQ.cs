using taller.Exceptions;
using Newtonsoft.Json;
using RabbitMQ.Client;
using taller.Configurations;
using System.Text;
using taller.DataAcces.Enums;

namespace taller.DataAccess.DAOs.MQ
{
    public class ProviderMQ
    {
        public void Producer(object message, ExchangeName exchangeName)
        {
            try
            {
                AppSettings config = new AppSettings();
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(config.MQConnectionString)
                };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.ExchangeDeclare(
                    exchange: exchangeName.ToString(),
                    type: ExchangeType.Fanout.ToString(), 
                    durable: true
                    );
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchangeName.ToString(),"", null, body);
            }
            catch(Exception)
            {
                throw new RCVException("Error al enviar el mensaje por RabbitMQ");
            }
        }

    }
}
