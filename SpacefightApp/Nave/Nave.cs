using Desafio_LabTIME_2026.Nucleo;
using Desafio_LabTIME_2026.Comandos;
using Desafio_LabTIME_2026.Sistema;
using Desafio_LabTIME_2026.Tripulacao;
using System;
using System.Collections.Generic;
using System.Text;
using Desafio_LabTIME_2026.Armamento.Armas;

namespace Desafio_LabTIME_2026.NaveEspacial;

public class Nave
{
    public NucleoEnergia nucleo;

    public List<Tripulante> tripulantes = new List<Tripulante>();

    public IArma Arma { get; set; }

    public List<string> Atirar()
    {
        return Arma?.Atirar() ?? new List<string> { "Nenhuma arma equipada." };
    }

    public Nave()
    {
        nucleo = new NucleoEnergia();
        nucleo.AdicionarSistema(new Escudo());
        nucleo.AdicionarSistema(new PainelNavegacao());
        nucleo.AdicionarSistema(new Luzes());
        tripulantes = MockData.GerarTripulantes();
    }

}
