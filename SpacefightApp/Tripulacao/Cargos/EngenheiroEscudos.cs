using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;

public class EngenheiroEscudos : ICargo
{
    public string Nome => "Engenheiro de escudos";
    public string Trabalhar(string TripulanteNome)
    {
        return $"- {TripulanteNome} está consertando os escudos.";
    }
}

