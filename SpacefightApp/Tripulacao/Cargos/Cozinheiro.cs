using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;

public class Cozinheiro : ICargo
{
    public string Nome => "Cozinheiro";
    public string Trabalhar(string TripulanteNome)
    {
        return $"- {TripulanteNome} está preparando a comida para a tripulação.";
    }
}

