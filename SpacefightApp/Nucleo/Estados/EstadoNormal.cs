namespace Desafio_LabTIME_2026.Nucleo.Estados;

using System;

public class EstadoNormal : IEstadoNucleo
{
    public void Entrar(NucleoEnergia nucleo)
    {
        Console.WriteLine("Escudos se recuperaram a niveis seguros");
    }

    public void Sair(NucleoEnergia nucleo)
    {
        Console.WriteLine("Escudos foram afetados");
    }

    public void RecebeDano(NucleoEnergia nucleo, int dano)
    {
        Console.WriteLine($"Escudo reduzido em: {dano}");
    }
}
