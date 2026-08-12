using System;
using Desafio_LabTIME_2026.Nucleo;
using Desafio_LabTIME_2026.Comandos;
using Desafio_LabTIME_2026.Sistema;


class Program
{
    static void Main()
    {
        var nucleo = new NucleoEnergia(100);
        nucleo.AdicionarSistema(new Escudo());
        nucleo.AdicionarSistema(new PainelNavegacao());
        nucleo.AdicionarSistema(new Luzes());

        ExibeMenu(nucleo);

        while (true)
        {
            Console.Write("\n> ");
            var input = Console.ReadLine();

            var entradas = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var comando = entradas is not null && entradas.Length > 0 ? entradas[0].ToLower() : null;
            var args = entradas.Length > 1 ? entradas[1..] : Array.Empty<string>();

            IComando? comando1 = null;
            ExibeMenu(nucleo);

            switch (comando)
            {
                case "tomar_dano":
                    if (args.Length == 1 && int.TryParse(args[0], out int valor))
                    {
                        comando1 = new ComandoTomarDano(nucleo, valor);
                    }
                    else
                    {
                        Console.WriteLine("Comando 'tomar_dano' com valor inválido");
                    }
                    break;
                case "reduzir_energia":
                    comando1 = new ComandoReduzirEnergia(nucleo);
                    break;
                case "recuperar_energia":
                    comando1 = new ComandoRecuperarEnergia(nucleo);
                    break;
                case "status":
                    Console.WriteLine("==== Status da Nave ====");
                    Console.WriteLine($"| Energia da nave: {nucleo.Energia} |\n| Estado da nave: {nucleo.EstadoAtual} |");
                    Console.WriteLine("========================\n");
                    break;
                case "sair":
                    Console.WriteLine("Nave retornando a base!");
                    return;
                default:
                    Console.WriteLine("Comando inválido");
                    break;
            }

            comando1?.Executar();

        }
    }
    public static void ExibeMenu(NucleoEnergia nucleo)
    {
        Console.Clear();
        Console.WriteLine("Bem Vindo ao Space Fight!\n\n");
        Console.WriteLine("=== SISTEMA DA NAVE ===\n");
        Console.WriteLine("Comandos: tomar_dano <valor> | reduzir_energia | recuperar_energia | status | sair\n");
    }
}
