namespace Desafio_LabTIME_2026.Sistema;

using System;
using Desafio_LabTIME_2026.Nucleo;

public class Escudo : ISistema
{
	public void Atualizar(EventoNucleo evento, NucleoEnergia nucleo)
    {
		if (nucleo.Energia <= 30)
		{
			Console.WriteLine("- Escudos em modo de defesa.");
        } else if (evento == EventoNucleo.EnergiaRecuperada)
        {
			Console.WriteLine("- Escudos em modo de ataque.");
        }
	}
}
