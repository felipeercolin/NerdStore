using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Data.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProdutoId)
                .IsRequired();

            builder.Property(c => c.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.ValorUnitario)
                .IsRequired();

            // 1 : N => Pedido : PedidoItem
            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.PedidoItems)
                .HasForeignKey(c => c.PedidoId);

            builder.ToTable("PedidoItems");
        }
    }
}