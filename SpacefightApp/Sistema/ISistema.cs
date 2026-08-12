namespace Desafio_LabTIME_2026.Sistema;

using System;
using Desafio_LabTIME_2026.Nucleo;

public interface ISistema
{
    public void Atualizar(EventoNucleo evento, NucleoEnergia nucleo);
}
