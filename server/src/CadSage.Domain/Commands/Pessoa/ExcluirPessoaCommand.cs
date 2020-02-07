using CadSage.Domain.Core.Commands;
using System;

namespace CadSage.Domain.Commands.Pessoa
{
    public class ExcluirPessoaCommand : Command
    {
        public Guid Id { get; private set; }

        public ExcluirPessoaCommand(Guid id)
        {
            Id = id;
        }
    }
}