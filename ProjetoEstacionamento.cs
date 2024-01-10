using System;
using System.Collections.Generic;
using System.Linq;

class Estacionamento
{
    private decimal valorInicial = 0;
    private decimal valorPorHora = 0;
    private List<Veiculo> veiculosEstacionados = new List<Veiculo>();

    public Estacionamento(decimal valorInicial, decimal valorPorHora)
    {
        this.valorInicial = valorInicial;
        this.valorPorHora = valorPorHora;
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Informe a placa do veículo:");
        string placa = Console.ReadLine();

        if (!VeiculoExiste(placa))
        {
            Veiculo veiculo = new Veiculo(placa);
            veiculosEstacionados.Add(veiculo);
            Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
        }
        else
        {
            Console.WriteLine("Veículo já está estacionado.");
        }
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Informe a placa do veículo para remover:");
        string placa = Console.ReadLine();

        Veiculo veiculo = veiculosEstacionados.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper());

        if (veiculo != null)
        {
            Console.WriteLine("Tempo de permanência:");
            int horas = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal = valorInicial + (valorPorHora * horas);

            veiculosEstacionados.Remove(veiculo);

            Console.WriteLine($"O veículo com placa {placa} foi removido e o valor total é: R$ {valorTotal}");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado.");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculosEstacionados.Any())
        {
            Console.WriteLine("Veículos estacionados:");

            foreach (var veiculo in veiculosEstacionados)
            {
                Console.WriteLine($"Placa: {veiculo.Placa}");
            }
        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }

    private bool VeiculoExiste(string placa)
    {
        return veiculosEstacionados.Any(v => v.Placa.ToUpper() == placa.ToUpper());
    }
}

class Veiculo
{
    public string Placa { get; set; }

    public Veiculo(string placa)
    {
        Placa = placa;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        decimal valorInicial = 0;
        decimal valorPorHora = 0;

        Console.WriteLine("Bem-vindo ao sistema de estacionamento!\n" +
                          "Informe o valor inicial:");
        valorInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Valor por hora:");
        valorPorHora = Convert.ToDecimal(Console.ReadLine());

        Estacionamento estacionamento = new Estacionamento(valorInicial, valorPorHora);

        string escolha = string.Empty;
        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("Informe a sua escolha:");
            Console.WriteLine("1 - Adicionar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            switch (Console.ReadLine())
            {
                case "1":
                    estacionamento.AdicionarVeiculo();
                    break;

                case "2":
                    estacionamento.RemoverVeiculo();
                    break;

                case "3":
                    estacionamento.ListarVeiculos();
                    break;

                case "4":
                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("inválido");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa encerrou");
    }
}

