using System;
using CadSage.Domain.Core.Notifications;
using CadSage.Domain.Interfaces;
using MediatR;
using CadSage.Domain.Entidades;
using CadSage.Domain.Interfaces.Repository;
using CadSage.Domain.Commands.Pessoa;
using CadSage.Domain.Core.Constantes;
using System.Linq;

namespace CadSage.Domain.Handlers
{
    public class PessoaCommandHandler : CommandHandler,
        INotificationHandler<RegistrarPessoaCommand>,
        INotificationHandler<AtualizarPessoaCommand>,
        INotificationHandler<ExcluirPessoaCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMediatorHandler _mediator;

        public PessoaCommandHandler(IPessoaRepository pessoaRepository,
                                 IUnitOfWork uow,
                                 INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _pessoaRepository = pessoaRepository;
            _mediator = mediator;
        }

        public void Handle(RegistrarPessoaCommand message)
        {
            var pessoa = new Pessoa(message.ViewModel.Id, message.ViewModel.Nome, message.ViewModel.Email, message.ViewModel.CPF, message.ViewModel.Rua,
                message.ViewModel.CEP, message.ViewModel.Bairro, message.ViewModel.Cidade, message.ViewModel.UF);

            if (!PessoaValido(pessoa)) return;

            // TODO:
            // Validacoes de negocio!
            if (_pessoaRepository.Buscar(x => x.CPF == message.ViewModel.CPF).Count() > 0)
            {
                _mediator.PublicarEvento(new DomainNotification("Pessoa", string.Format(Mensagens.JaExistente, "Pessoa")));
                return;
            }

            _pessoaRepository.Adicionar(pessoa);

            if (Commit())
            {
                // TODO:
                // Tarefas por salvar
            }
        }

        public void Handle(AtualizarPessoaCommand message)
        {
            var pessoaAtual = PessoaExistente(message.ViewModel.Id.Value, message.MessageType);

            if (pessoaAtual == null) return;

            var pessoa = new Pessoa(message.ViewModel.Id, message.ViewModel.Nome, message.ViewModel.Email, message.ViewModel.CPF, message.ViewModel.Rua,
                message.ViewModel.CEP, message.ViewModel.Bairro, message.ViewModel.Cidade, message.ViewModel.UF);

            if (!PessoaValido(pessoa)) return;

            _pessoaRepository.Atualizar(pessoa);

            if (Commit())
            {
                // TODO:
                // Tarefas por salvar
            }
        }

        public void Handle(ExcluirPessoaCommand message)
        {
            var pessoaAtual = PessoaExistente(message.Id, message.MessageType);

            if (pessoaAtual == null) return;

            // Validacoes de negocio

            _pessoaRepository.Remover(pessoaAtual);

            if (Commit())
            {
                // TODO:
                // Tarefas por salvar
            }
        }

        private bool PessoaValido(Pessoa pessoa)
        {
            if (pessoa.EhValido()) return true;

            NotificarValidacoesErro(pessoa.ValidationResult);
            return false;
        }

        private Pessoa PessoaExistente(Guid id, string messageType)
        {
            var pessoa = _pessoaRepository.ObterPorId(id);

            if (pessoa != null) return pessoa;

            _mediator.PublicarEvento(new DomainNotification(messageType, string.Format(Mensagens.NaoEncontrado, "Pessoa")));

            return null;
        }
    }
}