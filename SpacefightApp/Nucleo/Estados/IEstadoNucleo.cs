namespace Desafio_LabTIME_2026.Nucleo.Estados;
using System;

public interface IEstadoNucleo
{
    void NovoEstado(NucleoEnergia nucleo);
    void RecebeDano(NucleoEnergia nucleo, int dano);
}