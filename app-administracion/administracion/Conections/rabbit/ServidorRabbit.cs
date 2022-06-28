
using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using administracion.Persistence.Database;

namespace administracion.Conections.rabbit
{
    public class ProductorRabbit: IProductorRabbit
    {

        private ConnectionFactory factory = new ConnectionFactory() 
        {
            HostName =  "localhost" 
        };
        //metodo para generar una cadena de accion para el receptor

        private string GenerateMessage(string keyword, string content)
        {
            //keyword: comando que reconcera el cliente
            //content: el Id u otro contenido con el que va a trabjar
            return keyword + ":" + content;
        }

        //metodo para enviar un mensaje a una ruta especifica
            //routing: "ruta a la que se va a mandar el mensaje"
        public bool SendMessage(Routings routing,string instruccion, string contenido)
        {
            try
            {
                var comando = GenerateMessage(instruccion,contenido);
                using(var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare(exchange:"administracion",type:ExchangeType.Direct);

                        BasicPublish(channel,comando, routing);

                        Console.WriteLine($"[x] Enviando {comando}");
                    }
                    Console.WriteLine("mansaje enviado");
                }
            }catch(Exception ex)
            {
                Console.WriteLine("ocurrio un error al enviar el mensaje por RabbitMQ");
            }
            return true;
            
        }

        //metodo para crear el modelo
        private IModel BasicPublish(IModel channel, string message, Routings routingkey)
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange:"administracion", 
                routingKey: routingkey.ToString(), 
                basicProperties: null, 
                body:body);
            return channel;
        }

        
    }

}
