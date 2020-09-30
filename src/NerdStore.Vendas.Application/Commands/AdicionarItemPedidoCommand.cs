using System;
using FluentValidation;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Application.Validations;

namespace NerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage(FluentValitionMessages.RequiredSetPropertyName("Id do Cliente"));

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage(FluentValitionMessages.RequiredSetPropertyName("Id do Cliente"));

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage(FluentValitionMessages.RequiredSetPropertyName("Nome do Produto"));

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage(FluentValitionMessages.ValueGreaterThan);

            RuleFor(c => c.Quantidade)
                .LessThan(15)
                .WithMessage(FluentValitionMessages.ValueLessThan);

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0)
                .WithMessage(FluentValitionMessages.ValueGreaterThanSetPropertyName("Valor do Item"));
        }
    }
}