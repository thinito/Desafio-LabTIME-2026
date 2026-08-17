using System;
using System.Collections.Generic;
using System.Text;
using Desafio_LabTIME_2026.NaveEspacial;
using Desafio_LabTIME_2026.Tripulacao;
using Desafio_LabTIME_2026.Armamento;
using Desafio_LabTIME_2026.Armamento.Armas;

namespace Desafio_LabTIME_2026.Menus;

public class MenuArmamento
{
    private static MenuArmamento? _instance;
    public static MenuArmamento Instance => _instance ??= new MenuArmamento();
    private MenuArmamento() { }

    private List<string> _mensagemBuffer = new();

    public void Exibir(Nave nave)
    {
        while (true)
        {
            ExibeMenuArmamento(nave);
            foreach (var msg in _mensagemBuffer)
            {
                Console.WriteLine(msg);
            }
            _mensagemBuffer.Clear();

            Console.Write("\narmamento> ");
            var input = Console.ReadLine();
            var entradas = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var comando = entradas is not null && entradas.Length > 0 ? entradas[0].ToLower() : null;
            var args = entradas.Length > 1 ? entradas[1..] : Array.Empty<string>();

            switch (comando)
            {
                case "equipar_arma":
                    if (args.Length != 1)
                    {
                        _mensagemBuffer.Add("- Uso correto> equipar_arma <num.Arma>");
                        break;
                    }
                    if (!int.TryParse(args[0], out int numArma))
                    {
                        _mensagemBuffer.Add("- O argumento deve ser número inteiro.");
                        break;
                    }
                    _mensagemBuffer.Add(ArmamentoManager.CriarArma(numArma, nave));
                    break;
                case "adicionar_modificador":
                    if (args.Length != 1)
                    {
                        _mensagemBuffer.Add("- Uso correto> adicionar_modificador <num.Modificador>");
                        break;
                    }
                    if (!int.TryParse(args[0], out int numMod))
                    {
                        _mensagemBuffer.Add("- O argumento deve ser um número inteiro.");
                        break;
                    }
                    _mensagemBuffer.AddRange(ArmamentoManager.AdicionarModificador(numMod, nave));
                    break;
                case "atirar":
                    _mensagemBuffer.AddRange(nave.Atirar());
                    break;
                case "status":
                    ExibeStatusArma(nave);
                    break;
                case "voltar":
                    return;
                default:
                    _mensagemBuffer.Add("- Comando inválido");
                    break;
            }
        }
    }

    public void ExibeMenuArmamento(Nave nave)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA DE ARMAMENTO ===\n");
        Console.WriteLine("Comandos: equipar_arma <num.Arma> | Atirar | adicionar_modificador <num.Modificador> | status | voltar");
        ArmamentoManager.ListarArmas();
        ArmamentoManager.ListarModificadores();
        Console.WriteLine("");
    }

    public void ExibeStatusArma(Nave nave)
    {
        _mensagemBuffer.Add("- Arma Equipada: " + (nave.Arma?.Nome ?? "Nenhuma arma equipada."));
        if (nave.Arma != null) _mensagemBuffer.Add($"- Descricao: {nave.Arma.Descricao()}");
    }
}