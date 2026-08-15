using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;

public class OperadorCanhoes : ICargo
{
    public string Nome => "Operador de canhoes";
    public string Trabalhar(string TripulanteNome)
    {
        return $"- {TripulanteNome} está atirando no inimigo.";
    }
}