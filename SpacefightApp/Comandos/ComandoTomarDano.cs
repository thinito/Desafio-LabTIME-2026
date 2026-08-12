namespace Desafio_LabTIME_2026.Comandos;

using System;
using Desafio_LabTIME_2026.Nucleo;

public class ComandoTomarDano : IComando
{
    private readonly NucleoEnergia _nucleo;
    private readonly int _dano;

    public ComandoTomarDano(NucleoEnergia nucleo, int dano)
    {
        _nucleo = nucleo;
        _dano = dano;
    }

    public void Executar()
	{
        _nucleo.TomarDano(_dano);
	}
}
