using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;

public class MecanicoMotor : ICargo
{
    public string Nome => "Mecânico do motor";
    public string Trabalhar(string TripulanteNome)
    {
        return $"- {TripulanteNome} está consertando o motor da nave.";
    }
}

