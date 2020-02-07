using System.Threading.Tasks;
using CadSage.Domain.Core.Commands;
using CadSage.Domain.Core.Events;

namespace CadSage.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}