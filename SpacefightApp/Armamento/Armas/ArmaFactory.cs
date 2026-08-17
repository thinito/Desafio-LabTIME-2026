using System;
using System.Collections.Generic;
using System.Text;
using Desafio_LabTIME_2026.Armamento;
using Desafio_LabTIME_2026.Armamento.Armas;
using Desafio_LabTIME_2026.Armamento.Mods;

namespace Desafio_LabTIME_2026.Armamento.Armas;

public class ArmaFactory
{
    public static IArma CriarArma(int tipo)
    {
        return tipo switch
        {
            1 => new LaserContinuo(),
            2 => new EnxameMisseis(),
            _ => throw new ArgumentException("- Tipo de arma inválido.")
        };
    }

    public static void ListarArmasDisponiveis()
    {
        Console.WriteLine("\nArmas disponíveis:");
        Console.WriteLine("1- Laser Contínuo\n2- Enxame de Mísseis");
    }

    public static void ListarModificadoresDisponiveis()
    {
        Console.WriteLine("\nModificadores disponíveis:");
        Console.WriteLine("1- Dano de Fogo\n2- Perfuração de Blindagem");
    }

    public static IArma AplicarModificador(IArma arma, int modificador)
    {
        return modificador switch
        {
            1 => new DanoFogo(arma),
            2 => new PerfuracaoBlindagem(arma),
            _ => throw new ArgumentException("- Modificador inválido.")
        };
    }
}
