namespace Desafio_LabTIME_2026.Nucleo.Estados;

using System;

public class EstadoCritico : IEstadoNucleo
{
	public void NovoEstado(NucleoEnergia nucleo)
	{
		Console.WriteLine("Escudos entraram em niveis criticos");
    }

	public void RecebeDano(NucleoEnergia nucleo, int dano)
	{
		Console.WriteLine($"Escudo reduzido em: {dano}");
    }	
}
