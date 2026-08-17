using System;
using System.Collections.Generic;
using System.Text;
using Desafio_LabTIME_2026.NaveEspacial;
using Desafio_LabTIME_2026.Tripulacao;

namespace Desafio_LabTIME_2026.Menus;

public class MenuTripulacao
{
    private static MenuTripulacao? _instance;
    public static MenuTripulacao Instance => _instance ??= new MenuTripulacao();
    private MenuTripulacao() { }

    private List<string> _mensagemBuffer = new();

    public void Exibir(Nave nave)
    {
        while (true)
        {
            ExibeMenuTripulacao(nave);
            foreach (var msg in _mensagemBuffer)
            {
                Console.WriteLine(msg);
            }
            _mensagemBuffer.Clear();

            Console.Write("\ntripulacao> ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }
            var entradas = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var comando = entradas is not null && entradas.Length > 0 ? entradas[0].ToLower() : null;
            var args = entradas.Length > 1 ? entradas[1..] : Array.Empty<string>();

            switch (comando)
            {
                case "mudar_cargo":
                    if (args.Length != 2)
                    {
                        _mensagemBuffer.Add("- Uso correto> mudar_cargo <num.Tripulante> <num.Cargo>");
                        break;
                    }
                    if (!int.TryParse(args[0], out int numTripulante) || !int.TryParse(args[1], out int numCargo))
                    {
                        _mensagemBuffer.Add("- Os argumentos devem ser números inteiros.");
                        break;
                    }
                    var t1 = TripulacaoManager.ObterTripulante(nave.Tripulantes, numTripulante);
                    if (t1 == null)
                    {
                        _mensagemBuffer.Add("- Tripulante não encontrado.");
                        break;
                    }
                    _mensagemBuffer.Add(TripulacaoManager.SelecionarCargo(t1, numCargo));
                    break;
                case "trabalhar":
                    if (args.Length != 1)
                    {
                        _mensagemBuffer.Add("- Uso correto> trabalhar <num.Tripulante>");
                        break;
                    }
                    if (!int.TryParse(args[0], out int numTripulanteTrabalho))
                    {
                        _mensagemBuffer.Add("- O argumento deve ser um número inteiro.");
                        break;
                    }
                    var t2 = TripulacaoManager.ObterTripulante(nave.Tripulantes, numTripulanteTrabalho);
                    if (t2 == null)
                    {
                        _mensagemBuffer.Add("- Tripulante não encontrado.");
                        break;
                    }
                    _mensagemBuffer.Add(TripulacaoManager.Trabalhar(t2));
                    break;

                case "voltar":
                    return;

                default:
                    _mensagemBuffer.Add("Comando inválido");
                    break;
            }
        }
    }

    public void ExibeMenuTripulacao(Nave nave)
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
        Console.WriteLine("=== SISTEMA DE TRIPULACAO ===\n");
        Console.WriteLine("Comandos: mudar_cargo <num.Tripulante> <num.Cargo> | trabalhar <num.Tripulante> | voltar\n");
        TripulacaoManager.ListarTripulantes(nave.Tripulantes);
        TripulacaoManager.ListarCargos();
    }
}