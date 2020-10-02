﻿using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected Guid ClienteId => Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected bool OperacaoValida() => !_notifications.TemNotificacao();

        protected IEnumerable<string> ObterMensagensNotificacao() => _notifications.ObterNotificacoes().Select(c => c.Value).ToList();

        protected void NotificarErro(string codigo, string message) => _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, message));
    }
}