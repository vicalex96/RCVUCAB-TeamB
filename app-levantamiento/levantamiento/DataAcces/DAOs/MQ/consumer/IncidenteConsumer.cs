using levantamiento.BussinesLogic.Commands;
using levantamiento.BussinesLogic.DTOs;
using MassTransit;

namespace levantamiento.DataAccess.DAOs.MQ
{
    internal class IncidenteConsumer: IConsumer<PublishIncidente>
    {
        readonly ILogger<IncidenteConsumer> _Logger;

        public IncidenteConsumer (ILogger <IncidenteConsumer> logger)
        {
            _Logger = logger;
        }
        public async Task Consume(ConsumeContext<PublishIncidente> context)
        {
            await Console.Out.WriteLineAsync("Location Update:" +  context.Message.Id + " " + context.Message.polizaId);
            IncidenteRegisterDTO dto = new IncidenteRegisterDTO();
            dto.Id = Guid.Parse(context.Message.Id!);
            dto.polizaId = Guid.Parse(context.Message.polizaId!);

            RegisterIncidenteCommand command = IncidenteCommandFactory.createRegisterIncidenteCommand(dto);
            command.Execute();
            Guid id = command.GetResult();
            Console.WriteLine("respuesta: "+id);
        }

    }
}