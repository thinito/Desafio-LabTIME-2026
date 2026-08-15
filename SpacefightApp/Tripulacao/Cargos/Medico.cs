using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;

public class Medico : ICargo
{
    public string Nome => "Medico";
    public string Trabalhar(string TripulanteNome)
    {
        return $"- {TripulanteNome} está atendendo um paciente.";
    }
}