namespace Desafio_LabTIME_2026.Comandos;

using System;
using Desafio_LabTIME_2026.Nucleo;

public class ComandoReduzirEnergia : IComando
{
    private readonly NucleoEnergia _nucleo;
    public ComandoReduzirEnergia( NucleoEnergia nucleo)
	{
		_nucleo = nucleo;
	}

    public void Executar()
    {
        _nucleo.ReduzirEnergia();
    }

}
