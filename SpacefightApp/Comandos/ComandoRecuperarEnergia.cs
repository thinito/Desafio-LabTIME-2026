namespace Desafio_LabTIME_2026.Comandos;

using System;
using Desafio_LabTIME_2026.Nucleo;

public class ComandoRecuperarEnergia : IComando
{
    private readonly NucleoEnergia _nucleo;
    public ComandoRecuperarEnergia(NucleoEnergia nucleo)
    {
        _nucleo = nucleo;
    }

    public void Executar()
    {
        _nucleo.RecuperarEnergia();
    }

}
