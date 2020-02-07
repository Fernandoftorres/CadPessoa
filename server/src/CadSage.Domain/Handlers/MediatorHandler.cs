using System.Threading.Tasks;
using MediatR;
using CadSage.Domain.Interfaces;
using CadSage.Domain.Core.Commands;
using CadSage.Domain.Core.Events;

namespace Seven.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task EnviarComando<T>(T comando) where T : Command
        {
            return Publicar(comando);
        }

        public Task PublicarEvento<T>(T evento) where T : Event
        {
            return Publicar(evento);
        }

        private Task Publicar<T>(T mensagem) where T : Message
        {
            return _mediator.Publish(mensagem);
        }
    }
}