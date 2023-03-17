using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using Xunit;
using Xunit.Abstractions;

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


        // linhas 24 at� 29, Conceito de Setup - prepara��o do cen�rio de teste
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste; // ITestOutputHelper escreve uma mensagem no console do gerenciador de testes toda vez que algum m�todo invoca o construtor
        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste) // Construtor
        {
            this.saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor Invocado!!!");//Mensagem exibida no console do gerenciador de testes
            veiculo = new Veiculo(); // Vari�vel Global, substitui a necessidade de criar um objeto veiculo em cada m�todo de teste
        }


        [Fact(DisplayName =" Teste n� 1")] // Nota��o que indica um m�todo de teste do pacote Xunit
        [Trait("Funcionalidade","Acelerar")]// Trait serve para descrever a caracter�stica do teste.... e funciona como uma chave valor, a orimeira string � a chave a segunda o valor
        public void TestaAcelerarComParametro10() // m�todo de teste
        {
            //var veiculo = new Veiculo(); // Vari�vel ve�culo sendo instanciada pela classe Veiculo
            veiculo.Acelerar(10);// invoca��o do m�todo Acelerar()
            Assert.Equal(100, veiculo.VelocidadeAtual);// Verifica se a propriedade VelocidadeAtual possui o valor 100
        }

        [Fact(DisplayName ="Teste n� 3")]
        [Trait("Funcionalidade","Frear")] // Vide a aba caracteriscitas no Gerenciador de Testes
        // Com padr�o AAA
        public void TestaFrearComParametro10()
        {
            //Arrange
           // var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        // Skip Ignora um teste que ainda est� sendo implementado e passa uma mensagem de aviso
        [Fact (DisplayName="Teste n� 2",Skip ="Teste ainda n�o implementado - ignorar!!!")] // Anota��o para ignorar um teste que ainda n�o foi finalizado
        public void ValidaNomeDoProprietario()
        {

        }

        [Fact]
        public void FichaDeDadosDoVeiculo()
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

            Assert.Contains("Placa: ", dados);// Verifica se o m�todo ToString cont�m a string ""
        }


        // TESTANDO UMA EXCE��O
        [Fact]
        public void TestaNomeVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "ab";
            //Assert
            Assert.Throws<System.FormatException>( //Assert.Thorws m�todo para testar uma exce��o, <System.FormatException> tipo da exce��o que ser� testada
            //Act    
            ()=> new Veiculo(nomeProprietario)); // Passa para o construtor Veiculo a vari�vel com o nome do propriet�rio
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaracterDaPlaca()
        {
            //Arrange
            string placa = "qwer1313";
            
            //Act
            var mensagem = Assert.Throws<FormatException>(
                ()=> new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }

    }
}
