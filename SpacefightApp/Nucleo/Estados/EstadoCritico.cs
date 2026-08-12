namespace Desafio_LabTIME_2026.Nucleo.Estados;

using System;

public class EstadoCritico : IEstadoNucleo
{
	public void Entrar(NucleoEnergia nucleo)
	{
		Console.WriteLine("Escudos entraram em niveis criticos");
    }

	public void Sair(NucleoEnergia nucleo)
	{
		Console.WriteLine("Escudos se recuperando.");
    }

	public void RecebeDano(NucleoEnergia nucleo, int dano)
	{
		Console.WriteLine($"Escudo reduzido em: {dano}");
    }	
}
