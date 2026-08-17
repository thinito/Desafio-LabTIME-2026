using System;
using System.Collections.Generic;
using System.Text;
using Desafio_LabTIME_2026.Armamento.Armas;
using Desafio_LabTIME_2026.Armamento.Mods;
using Desafio_LabTIME_2026.NaveEspacial;

namespace Desafio_LabTIME_2026.Armamento;
public class ArmamentoManager
{
    public static void ListarModificadores() => ArmaFactory.ListarModificadoresDisponiveis();

    public static void ListarArmas() =>ArmaFactory.ListarArmasDisponiveis();

    public static string CriarArma(int numArma, Nave nave)
    {
        try
        {
            var arma = ArmaFactory.CriarArma(numArma);
            nave.EquiparArma(arma);
            return $"- Arma '{arma.Nome}' equipada com sucesso!";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

    }

    public static string AdicionarModificador(int numModificador, Nave nave)
    {
        try
        {
            var modificador = ArmaFactory.AplicarModificador(nave.Arma, numModificador);
            nave.EquiparArma(modificador);
            return $"- Modificador '{modificador.Nome}' adicionado com sucesso!";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

}

