using System;
using AutoMapper;
using CadSage.Domain.Core.Notifications;
using CadSage.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CadSage.Domain.Core.ViewModels;
using CadSage.Domain.Interfaces.Repository;
using System.Collections.Generic;
using CadSage.Domain.Commands.Pessoa;

namespace CadSage.Services.Api.Controllers
{
    public class PessoaController : BaseController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public PessoaController(INotificationHandler<DomainNotification> notifications,
                                IPessoaRepository pessoaRepository,
                                IMapper mapper,
                                IMediatorHandler mediator) : base(notifications, mediator)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("pessoas")]
        public IEnumerable<PessoaViewModel> Get()
        {
            return _mapper.Map<IEnumerable<PessoaViewModel>>(_pessoaRepository.ObterTodos());
        }

        [HttpGet]
        [Route("pessoa/{id}")]
        public PessoaViewModel Get(string id)
        {
            Guid _id = Guid.Empty;
            Guid.TryParse(id, out _id);
            return _mapper.Map<PessoaViewModel>(_pessoaRepository.ObterPorId(_id));
        }

        [HttpPost]
        [Route("pessoa")]
        public IActionResult Post([FromBody]PessoaViewModel pessoaViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var command = _mapper.Map<RegistrarPessoaCommand>(pessoaViewModel);

            _mediator.EnviarComando(command);

            return Response(command);
        }

        [HttpPut]
        [Route("pessoa/{id}")]
        public IActionResult Put([FromBody]PessoaViewModel pessoaViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var command = _mapper.Map<AtualizarPessoaCommand>(pessoaViewModel);

            _mediator.EnviarComando(command);

            return Response(command);
        }

        [HttpDelete]
        [Route("pessoa/{id}")]
        public IActionResult Delete(string id)
        {
            Guid _id = Guid.Empty;
            Guid.TryParse(id, out _id);
            var command = new ExcluirPessoaCommand(_id);

            _mediator.EnviarComando(command);

            return Response(command);
        }
    }
}
