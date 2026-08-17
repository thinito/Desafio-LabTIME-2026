using Desafio_LabTIME_2026.Armamento.Armas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Armamento.Mods;
public abstract class ModificadorArma : IArma
{

    public abstract string Nome { get; }
    public virtual string Descricao()
    {
        return _arma.Descricao();
    }
    protected readonly IArma _arma;

    public abstract List<string> Atirar();

    public ModificadorArma(IArma arma)
    {
        _arma = arma;
    }

}
