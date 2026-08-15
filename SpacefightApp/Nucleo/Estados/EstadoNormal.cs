namespace Desafio_LabTIME_2026.Nucleo.Estados;

using System;

public class EstadoNormal : IEstadoNucleo
{
    public void NovoEstado(NucleoEnergia nucleo)
    {
        Console.WriteLine("Escudos se recuperaram a niveis seguros");
    }

    public void RecebeDano(NucleoEnergia nucleo, int dano)
    {
        Console.WriteLine($"Escudo reduzido em: {dano}");
    }
}
