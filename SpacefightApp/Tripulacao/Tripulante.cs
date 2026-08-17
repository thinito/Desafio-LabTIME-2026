using Desafio_LabTIME_2026.Tripulacao.Cargos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao;

public class Tripulante 
{
    public string Nome { get; set; }
    public ICargo CargoAtual { get; set; }


    public Tripulante(string nome, ICargo cargoAtual)
    {
        Nome = nome;
        CargoAtual = cargoAtual;
    }

    public void MudarCargo(ICargo novoCargo)
    {
        CargoAtual = novoCargo;
        Console.WriteLine($"{Nome} mudou para o cargo de {CargoAtual.Nome}.");
    }

}
