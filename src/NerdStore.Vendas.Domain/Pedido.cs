using System;
using System.Collections.Generic;
using System.Linq;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; set; }
        public bool VoucherUtilizado { get; set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _peditoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems { get; set; }

        //EF Rel.
        public Voucher Voucher { get; private set; }

        protected Pedido() { _peditoItems = new List<PedidoItem>(0); }
        public Pedido(Guid clienteId, bool voucherUtilizado, decimal desconto, decimal valorTotal)
        {
            ClienteId = clienteId;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            ValorTotal = valorTotal;
            _peditoItems = new List<PedidoItem>(0);
        }

        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUtilizado = true;
            CalularValorPedido();
        }

        public void CalularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        public void CalcularValorTotalDesconto()
        {
            if(!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;
            if (Voucher.TipoDescontoVoucher == TipoDescontoVoucher.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }

        public bool PedidoItemExistente(PedidoItem item) => _peditoItems.Any(p => p.ProdutoId == item.ProdutoId);

        public void AdicionarItem(PedidoItem item)
        {
            if (!item.EhValido()) return;

            item.AssociarPedido(Id);
            if (PedidoItemExistente(item))
            {
                var itemExistente = _peditoItems.First(p => p.ProdutoId == item.ProdutoId);
                itemExistente.AdicionarUnidades(item.Quantidade);
                item = itemExistente;

                _peditoItems.Remove(itemExistente);
            }

            item.CalcularValor();
            _peditoItems.Add(item);
            CalularValorPedido();
        }

        public void RemoverItem(PedidoItem item)
        {
            if(!item.EhValido()) return;

            var itemExistente = PedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
            if(itemExistente == null) throw new DomainException("O item não pertence ao pedido");
            _peditoItems.Remove(itemExistente);

            CalularValorPedido();
        }
    }
}