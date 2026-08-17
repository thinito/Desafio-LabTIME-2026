using Desafio_LabTIME_2026.Tripulacao.Cargos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao;

public class TripulacaoManager
{
    public static string SelecionarCargo(Tripulante tripulante, int numeroCargo)
    {
        try
        {
            var cargoNovo = CargoFactory.Criar(numeroCargo);
            tripulante.CargoAtual = cargoNovo;
            return $"- {tripulante.Nome} agora é {cargoNovo.Nome}.";
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }

    public static void ListarCargos() => CargoFactory.ListarCargos();

    public static void ListarTripulantes(IReadOnlyList<Tripulante> tripulantes)
    {
        int c = 0;
        Console.WriteLine("Tripulantes:");
        foreach (var tripulante in tripulantes)
        {
            Console.WriteLine($"{c}: {tripulante.Nome} - {tripulante.CargoAtual.Nome}");
            c++;
        }
        Console.WriteLine("");
    }

    public static Tripulante? ObterTripulante(IReadOnlyList<Tripulante> tripulantes, int indice)
    {
        if (indice >= 0 && indice < tripulantes.Count)
            return tripulantes[indice];
        return null;
    }

    public static string Trabalhar(Tripulante tripulante)
    {
        return tripulante.CargoAtual?.Trabalhar(tripulante.Nome) ?? "Cargo inválido.";
    }

}  