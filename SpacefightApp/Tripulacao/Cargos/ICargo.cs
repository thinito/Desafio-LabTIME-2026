using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;

public interface ICargo
{
    string Nome { get; }
    string Trabalhar(string TripulanteNome);
}