using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto_de_Teste
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            // Padrão AAA

            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
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

        
        public void ValidaFaturamentoVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrenge
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);


            //Act
            var faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
    }
}
