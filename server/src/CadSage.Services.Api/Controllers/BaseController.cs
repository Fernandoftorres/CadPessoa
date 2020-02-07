using System;
using System.Linq;
using CadSage.Domain.Core.Notifications;
using CadSage.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadSage.Services.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected Guid UsuarioId { get; set; }

        protected BaseController(INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected new IActionResult Response(object result = null, bool? isShowData = false)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = (isShowData.HasValue && isShowData.Value) ? result : null
                });
            }

            return BadRequest(new
            {
                success = false,
                mensagem = _notifications.GetNotifications().Select(n=>n.Value)
            });
        }

        protected object MensagemSucesso(string mensagem)
        {
            return new { Mensagem = mensagem };
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.PublicarEvento(new DomainNotification(codigo, mensagem));
        }

        protected bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }

    }
}