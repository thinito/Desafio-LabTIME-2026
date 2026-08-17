using Desafio_LabTIME_2026.Armamento.Armas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Armamento.Mods;

public class DanoFogo : ModificadorArma
{
    public DanoFogo(IArma arma) : base(arma) { }

    public override string Nome => "Dano de Fogo";

    public override List<string> Atirar()
    {
        var mensagem = new List<string>();
        mensagem.Add("- [Dano de Fogo] Aplica queimadura ( 1 dano /turno)");
        mensagem.AddRange(_arma.Atirar());
        return mensagem;
    }
}

