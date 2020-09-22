using System;
using NerdStore.Core.DomainObjects;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
            {
                new Produto(string.Empty, "descricao", false, 100, Guid.NewGuid(), DateTime.Now, "imagem", new Dimensoes(1, 1, 1));
            });

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "imagem", new Dimensoes(1, 1, 1));
            });

            Assert.Equal("O campo Descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("nome", "descricao", false, 0, Guid.NewGuid(), DateTime.Now, "imagem", new Dimensoes(1, 1, 1));
            });

            Assert.Equal("O campo Valor do produto não pode se menor igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("nome", "descricao", false, 100, Guid.Empty, DateTime.Now, "imagem", new Dimensoes(1, 1, 1));
            });

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("nome", "descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1));
            });

            Assert.Equal("O campo Imagem do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("nome", "descricao", false, 100, Guid.NewGuid(), DateTime.Now, "imagem", new Dimensoes(0, 1, 1));
            });

            Assert.Equal("O campo Altura não pode ser menor ou igual a 0", ex.Message);
        }
    }
}
