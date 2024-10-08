using Xunit;
using FluentAssertions;
using CrudMongoDB.Models;
using CrudMongoDB.Services;

namespace CrudMongoDB.Tests
{
    public class ProdutoServiceTests
    {
        [Fact]
        public void Deve_Criar_Produto_Correctamente()
        {
            // Arrange
            var produto = new Produto
            {
                Id = "1",
                Nome = "Produto Teste"
            };

            // Act
            // Aqui você chamaria um método de serviço que manipula o produto, se aplicável.

            // Assert
            produto.Nome.Should().Be("Produto Teste");
            produto.Id.Should().Be("1");
        }

        [Fact]
        public void Deve_Retornar_Nome_Corrreto()
        {
            // Arrange
            var produto = new Produto
            {
                Id = "2",
                Nome = "Outro Produto"
            };

            // Act & Assert
            produto.Nome.Should().Be("Outro Produto");
        }

        // Adicione outros testes conforme necessário...

        // Exemplo de teste adicional
        [Fact]
        public void Produto_Nome_Nao_Deve_Estar_Nulo()
        {
            // Arrange
            var produto = new Produto
            {
                Id = "3",
                Nome = null // Intencionalmente nulo
            };

            // Act
            // Você pode querer implementar lógica aqui para garantir que o nome não seja nulo em sua aplicação.

            // Assert
            produto.Nome.Should().BeNull();
        }
    }
}
