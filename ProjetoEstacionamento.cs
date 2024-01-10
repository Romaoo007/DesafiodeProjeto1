using System;
using System.Collections.Generic;
using System.Linq;

class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<Veiculo> veiculosEstacionados = new List<Veiculo>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo:");
        string placa = Console.ReadLine();

        if (!VeiculoExiste(placa))
        {
            Veiculo veiculo = new Veiculo(placa);
            veiculosEstacionados.Add(veiculo);
            Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
        }
        else
        {
            Console.WriteLine("Veículo já estacionado.");
        }
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");
        string placa = Console.ReadLine();

        Veiculo veiculo = veiculosEstacionados.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper());

        if (veiculo != null)
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            int horas = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal = precoInicial + (precoPorHora * horas);

            veiculosEstacionados.Remove(veiculo);

            Console.WriteLine($"O veículo com placa {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado no estacionamento.");
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

        decimal precoInicial = 0;
        decimal precoPorHora = 0;

        Console.WriteLine("Bem-vindo ao sistema de estacionamento!\n" +
                          "Digite o preço inicial:");
        precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Agora, digite o preço por hora:");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());

        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

        string opcao = string.Empty;
        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
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
