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

        /** PADRÃO AAA
         * Arrange - Preparar o cenário de testes, ou seja, criar instâncias inicializar variáveis etc...
         * Act - Invocação do método que será testado. Ex.: Acelerar() Frear() etc...
         * Assert - Verificação do resultado obtido da execução do método. Ex.: resultado de Acelerar() Frear()
         **/


        // linhas 24 até 29, Conceito de Setup - preparação do cenário de teste
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste; // ITestOutputHelper escreve uma mensagem no console do gerenciador de testes toda vez que algum método invoca o construtor
        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste) // Construtor
        {
            this.saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor Invocado!!!");//Mensagem exibida no console do gerenciador de testes
            veiculo = new Veiculo(); // Variável Global, substitui a necessidade de criar um objeto veiculo em cada método de teste
        }


        [Fact(DisplayName =" Teste nº 1")] // Notação que indica um método de teste do pacote Xunit
        [Trait("Funcionalidade","Acelerar")]// Trait serve para descrever a característica do teste.... e funciona como uma chave valor, a orimeira string é a chave a segunda o valor
        public void TestaAcelerarComParametro10() // método de teste
        {
            //var veiculo = new Veiculo(); // Variável veículo sendo instanciada pela classe Veiculo
            veiculo.Acelerar(10);// invocação do método Acelerar()
            Assert.Equal(100, veiculo.VelocidadeAtual);// Verifica se a propriedade VelocidadeAtual possui o valor 100
        }

        [Fact(DisplayName ="Teste nº 3")]
        [Trait("Funcionalidade","Frear")] // Vide a aba caracteriscitas no Gerenciador de Testes
        // Com padrão AAA
        public void TestaFrearComParametro10()
        {
            //Arrange
           // var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        // Skip Ignora um teste que ainda está sendo implementado e passa uma mensagem de aviso
        [Fact (DisplayName="Teste nº 2",Skip ="Teste ainda não implementado - ignorar!!!")] // Anotação para ignorar um teste que ainda não foi finalizado
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

            Assert.Contains("Placa: ", dados);// Verifica se o método ToString contém a string ""
        }


        // TESTANDO UMA EXCEÇÃO
        [Fact]
        public void TestaNomeVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "ab";
            //Assert
            Assert.Throws<System.FormatException>( //Assert.Thorws método para testar uma exceção, <System.FormatException> tipo da exceção que será testada
            //Act    
            ()=> new Veiculo(nomeProprietario)); // Passa para o construtor Veiculo a variável com o nome do proprietário
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
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

    }
}
