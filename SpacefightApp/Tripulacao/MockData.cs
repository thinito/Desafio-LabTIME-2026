using Desafio_LabTIME_2026.Tripulacao.Cargos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao;

public class MockData
{
    public static List<Tripulante> GerarTripulantes()
    {
        return new List<Tripulante>
        {
            new Tripulante("Rafael", new PilotoNave()),
            new Tripulante("Pedro", new EngenheiroEscudos()),
            new Tripulante("Luis", new OperadorCanhoes())
        };
    }
} 
