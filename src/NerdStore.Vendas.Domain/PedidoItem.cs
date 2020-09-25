using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain
{
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; }
        public string ProdutoNome { get; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; }

        //EF Rel.
        public Pedido Pedido { get; set; }

        protected PedidoItem() { }
        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        internal void AssociarPedido(Guid pedidoId) => PedidoId = pedidoId;

        public decimal CalcularValor() => Quantidade * ValorUnitario;

        internal void AdicionarUnidades(int unidades) => Quantidade += unidades;

        internal void AtualizarUnidades(int unidades) => Quantidade -= unidades;

        public override bool EhValido() => true;
    }
}