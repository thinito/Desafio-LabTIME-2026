using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;

public class PilotoNave : ICargo
{
    public string Nome => "Piloto da nave";
    public string Trabalhar(string TripulanteNome)
    {
        return $"- {TripulanteNome} está pilotando a nave.";
    }
}

