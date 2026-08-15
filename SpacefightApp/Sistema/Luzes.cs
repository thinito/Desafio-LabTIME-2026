namespace Desafio_LabTIME_2026.Sistema;

using System;
using Desafio_LabTIME_2026.Nucleo;

public class Luzes : ISistema
{
	public void Atualizar(EventoNucleo evento, NucleoEnergia nucleo)
	{
		if (nucleo.Energia <= 30)
		{
			Console.WriteLine("- Luzes da sala foram apagadas.");
        } else if (evento == EventoNucleo.EnergiaRecuperada)
		{ 
			Console.WriteLine("- Luzes da sala foram reestabelecidas.");
        }
	}
}
