using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoBase = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculosEstacionados = new List<string>();

        public Estacionamento(decimal precoBase, decimal precoPorHora)
        {
            this.precoBase = precoBase;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo:");
            string placa = Console.ReadLine();
            veiculosEstacionados.Add(placa);
            Console.WriteLine($"O veículo {placa} foi estacionado.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa para remover:");
            string placa = Console.ReadLine();

            if (veiculosEstacionados.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoBase + (precoPorHora * horas);

                veiculosEstacionados.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculosEstacionados.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculosEstacionados)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
