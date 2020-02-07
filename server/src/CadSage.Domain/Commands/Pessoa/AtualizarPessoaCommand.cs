using CadSage.Domain.Core.Commands;
using CadSage.Domain.Core.ViewModels;

namespace CadSage.Domain.Commands.Pessoa
{
    public class AtualizarPessoaCommand : Command
    {
        public PessoaViewModel ViewModel { get; private set; }

        public AtualizarPessoaCommand(PessoaViewModel model)
        {
            ViewModel = model;
        }
    }
}