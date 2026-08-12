namespace Desafio_LabTIME_2026.Sistema;

using System;
using Desafio_LabTIME_2026.Nucleo;

public class PainelNavegacao : ISistema
{
	public void Atualizar(EventoNucleo evento, NucleoEnergia nucleo)
    {
        if (nucleo.Energia <= 30)
        {
            Console.WriteLine("[ALERTA] Energia em niveis criticos!");
        } else if (evento == EventoNucleo.EnergiaRecuperada)
        {
            Console.WriteLine("Energia da nave reestabelicida.");
        }
    }
}
