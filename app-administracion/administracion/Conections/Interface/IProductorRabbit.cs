using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace administracion.Conections.rabbit
{
    public interface IProductorRabbit
    {
        public bool SendMessage(Routings routing,string instruccion, string contenido)
        ;  
    }

    public enum Routings //Es quien va a recibir el mensaje
    {
        taller,
        proveedor,
        perito,
        administrador
    }
}