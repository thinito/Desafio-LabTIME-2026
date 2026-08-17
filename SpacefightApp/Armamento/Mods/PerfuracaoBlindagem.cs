using System;
using System.Collections.Generic;
using System.Text;
using Desafio_LabTIME_2026.Armamento.Armas;

namespace Desafio_LabTIME_2026.Armamento.Mods;

public class PerfuracaoBlindagem : ModificadorArma
{
    public PerfuracaoBlindagem(IArma arma) : base(arma) { }
    public override string Nome => "Perfuração de Blindagem";
    public override List<string> Atirar()
    {
        var mensagem = new List<string>();
        mensagem.Add("- [Perfuração de Blindagem] Ignora 50% da blindagem do alvo");
        mensagem.AddRange(_arma.Atirar());
        return mensagem;
    }
}