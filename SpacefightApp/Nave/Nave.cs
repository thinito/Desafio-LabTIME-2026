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
    public NucleoEnergia Nucleo { get; }
    private readonly List<Tripulante> _tripulantes = new();
    public IReadOnlyList<Tripulante> Tripulantes => _tripulantes;

    public IArma? Arma { get; private set; }
    public void EquiparArma(IArma arma) => Arma = arma ?? throw new ArgumentNullException(nameof(arma));

    public List<string> Atirar()
    {
        return Arma?.Atirar() ?? new List<string> { "Nenhuma arma equipada." };
    }

    public Nave()
    {
        Nucleo = new NucleoEnergia();
        Nucleo.AdicionarSistema(new Escudo());
        Nucleo.AdicionarSistema(new PainelNavegacao());
        Nucleo.AdicionarSistema(new Luzes());
        _tripulantes.AddRange(MockData.GerarTripulantes());
    }

}
