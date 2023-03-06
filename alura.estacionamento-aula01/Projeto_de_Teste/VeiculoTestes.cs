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

        /** PADR�O AAA
         * Arrange - Preparar o cen�rio de testes, ou seja, criar inst�ncias inicializar vari�veis etc...
         * Act - Invoca��o do m�todo que ser� testado. Ex.: Acelerar() Frear() etc...
         * Assert - Verifica��o do resultado obtido da execu��o do m�todo. Ex.: resultado de Acelerar() Frear()
         **/

        [Fact] // Nota��o que indica um m�todo de teste do pacote Xunit
        public void TestaAcelerar() // m�todo de teste
        {
            var veiculo = new Veiculo(); // Vari�vel ve�culo sendo instanciada pela classe Veiculo
            veiculo.Acelerar(10);// invoca��o do m�todo Acelerar()
            Assert.Equal(100, veiculo.VelocidadeAtual);// Verifica se a propriedade VelocidadeAtual possui o valor 100
        }

        [Fact]
        // Com padr�o AAA
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
