using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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

        [Fact(DisplayName =" Teste n� 1")] // Nota��o que indica um m�todo de teste do pacote Xunit
        [Trait("Funcionalidade","Acelerar")]// Trait serve para descrever a caracter�stica do teste.... e funciona como uma chave valor, a orimeira string � a chave a segunda o valor
        public void TestaAcelerar() // m�todo de teste
        {
            var veiculo = new Veiculo(); // Vari�vel ve�culo sendo instanciada pela classe Veiculo
            veiculo.Acelerar(10);// invoca��o do m�todo Acelerar()
            Assert.Equal(100, veiculo.VelocidadeAtual);// Verifica se a propriedade VelocidadeAtual possui o valor 100
        }

        [Fact(DisplayName ="Teste n� 3")]
        [Trait("Funcionalidade","Frear")] // Vide a aba caracteriscitas no Gerenciador de Testes
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

        // Skip Ignora um teste que ainda est� sendo implementado e passa uma mensagem de aviso
        [Fact (DisplayName="Teste n� 2",Skip ="Teste ainda n�o implementado - ignorar!!!")] // Anota��o para ignorar um teste que ainda n�o foi finalizado
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrenge

            var carro = new Veiculo();
            carro.Proprietario = "Rafael Geromel";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "ABS-3578";
            carro.Cor = "Branco";
            carro.Modelo = "T-Cross";

            //Act

            string dados = carro.ToString();

            //Assert

            Assert.Contains("Tipo do Ve�culo: ", dados);
        }

    }
}
