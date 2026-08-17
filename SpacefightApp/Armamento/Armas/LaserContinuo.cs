using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Armamento.Armas;
public  class LaserContinuo : IArma
{
    public string Nome => "Laser Continuo";
    public string Descricao() => $"Um feixe de laser contínuo que causa dano constante ao inimigo.";

    public LaserContinuo() { }

    public List<string> Atirar()
    {
        return new List<string> { "Laser continuo foi disparado!" };
    }
}
