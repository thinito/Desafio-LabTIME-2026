using Desafio_LabTIME_2026.NaveEspacial;
using Desafio_LabTIME_2026.Nucleo;
using Desafio_LabTIME_2026.Comandos;
using Desafio_LabTIME_2026.Sistema;
using Desafio_LabTIME_2026.Tripulacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Menus;

public class MenuPrincipal
{
    private static MenuPrincipal? _instance;
    public static MenuPrincipal Instance => _instance ??= new MenuPrincipal();
    private MenuPrincipal() { }

    public void Exibir(Nave nave)
    {
        ExibeMenu();
        while (true)
        {
            Console.Write("\n> ");
            var input = Console.ReadLine();

            var entradas = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var comando = entradas is not null && entradas.Length > 0 ? entradas[0].ToLower() : null;
            var args = entradas.Length > 1 ? entradas[1..] : Array.Empty<string>();

            IComando? comando1 = null;

            switch (comando)
            {
                case "tomar_dano":
                    if (args.Length == 1 && int.TryParse(args[0], out int valor))
                    {
                        comando1 = new ComandoTomarDano(nave.nucleo, valor);
                    }
                    else
                    {
                        Console.WriteLine("- Comando 'tomar_dano' com valor inválido");
                    }
                    break;
                case "reduzir_energia":
                    comando1 = new ComandoReduzirEnergia(nave.nucleo);
                    break;
                case "recuperar_energia":
                    comando1 = new ComandoRecuperarEnergia(nave.nucleo);
                    break;
                case "status":
                    ExibirStatus(nave);
                    break;
                case "tripulacao":
                    MenuTripulacao.Instance.Exibir(nave);
                    ExibeMenu();
                    break;
                case "armamento":
                    MenuArmamento.Instance.Exibir(nave);
                    ExibeMenu();
                    break;
                case "sair":
                    Console.WriteLine("- Nave retornando a base!");
                    return;
                default:
                    Console.WriteLine("- Comando inválido");
                    break;
            }

            comando1?.Executar();
        }
    }

    public void ExibeMenu()
    {
        Console.Clear();
        Console.WriteLine("Bem Vindo ao Space Fight!\n");
        Console.WriteLine("=== SISTEMA DA NAVE ===\n");
        Console.WriteLine("Comandos: tomar_dano <valor> | reduzir_energia | recuperar_energia | tripulacao | armamento | status | sair\n");
    }

    public void ExibirStatus(Nave nave)
    {
        Console.WriteLine("==== Status da Nave ====");
        Console.WriteLine($"| Energia da nave: {nave.nucleo.Energia} |\n| Estado da nave: {nave.nucleo.EstadoAtual} |");
        Console.WriteLine("========================\n");
    }
}