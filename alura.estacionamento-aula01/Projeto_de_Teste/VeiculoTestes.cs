using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Projeto_de_Teste
{
    public class VeiculoTestes

    /**
     * PROJETO DE TESTES UTILIZANDO xUNIT
     **/
    {

        /** PADRÃO AAA
         * Arrange - Preparar o cenário de testes, ou seja, criar instâncias inicializar variáveis etc...
         * Act - Invocação do método que será testado. Ex.: Acelerar() Frear() etc...
         * Assert - Verificação do resultado obtido da execução do método. Ex.: resultado de Acelerar() Frear()
         **/

        [Fact] // Notação que indica um método de teste do pacote Xunit
        public void TestaAcelerar() // método de teste
        {
            var veiculo = new Veiculo(); // Variável veículo sendo instanciada pela classe Veiculo
            veiculo.Acelerar(10);// invocação do método Acelerar()
            Assert.Equal(100, veiculo.VelocidadeAtual);// Verifica se a propriedade VelocidadeAtual possui o valor 100
        }

        [Fact]
        // Com padrão AAA
        public void TestaFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
    }
}
