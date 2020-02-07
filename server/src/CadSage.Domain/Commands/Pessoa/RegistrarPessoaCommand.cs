using CadSage.Domain.Core.Commands;
using CadSage.Domain.Core.ViewModels;

namespace CadSage.Domain.Commands.Pessoa
{
    public class RegistrarPessoaCommand : Command
    {
        public PessoaViewModel ViewModel { get; private set; }

        public RegistrarPessoaCommand(PessoaViewModel model)
        {
            ViewModel = model;
        }
    }
}