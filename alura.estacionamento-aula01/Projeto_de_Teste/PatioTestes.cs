using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Projeto_de_Teste
{
    public class PatioTestes
    {

        // Configuração do Setup - preparação do cenário de testes
        private Patio estacionamento;
        private Veiculo veiculo;
        public ITestOutputHelper saidaDadosConcole;//atributo para mensagem de teste no gerenciador de testes 
        public PatioTestes(ITestOutputHelper _saidaDadosConcole)//Construtor
        {
            this.saidaDadosConcole = _saidaDadosConcole;
            saidaDadosConcole.WriteLine("Construtor Invocado!!!!");
            estacionamento = new Patio();
            veiculo = new Veiculo();
        }
        [Fact]
        public void ValidaFaturamentoDoEstacionamento()
        {
            // Padrão AAA

            // Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Rafael Henrique";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Prata";
            veiculo.Modelo = "Onix";
            veiculo.Placa = "ABC-1324";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2,faturamento);

        }
        [Theory] // Anotação que permite trabalhar com um grande conjunto de dados e testar vários métodos ao mesmo tempo 

        [InlineData("André Gomes", "FGA-1325", "Preto", "Versa")]// InlineData passa os valores para os parâmetros do método que será testado
        [InlineData("Joao Macedo", "JKK-4564", "Prata", "Voiage")]
        [InlineData("Olivia Souza", "HUJ-5642", "Preto", "Onix")]
        [InlineData("Jennyfer Cabral", "WER-7897", "Branco", "Amarok")]

        
        public void ValidaFaturamentoDeVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrenge
           // var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            //var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);


            //Act
            var faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory(DisplayName ="Teste nº 4")]
        [InlineData("Rogerio Lisboa", "PYO-4566", "Vermelho", "Tiguan")]
        public void LocalizaVeiculoEstacionadoComBaseNoIdDoTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrenge
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            //var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consulta = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consulta.Ticket);
        }

        [Fact]
        public void AlteraDadosDoVeiculo()
        {
            // Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Roger Guedes";
            veiculo.Placa = "QWE-7894";
            veiculo.Cor = "Prata";
            veiculo.Modelo = "Gol";
            veiculo.Largura = 2.0;

            //Patio estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Roger Matias";
            veiculoAlterado.Placa = "QWE-7894";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Prisma";
            veiculoAlterado.Largura = 2.5;

            //Act 
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Placa, veiculoAlterado.Placa);

        }

    }
}
