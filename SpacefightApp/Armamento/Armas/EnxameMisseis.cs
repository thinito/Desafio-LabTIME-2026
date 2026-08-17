using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Armamento.Armas;

public class EnxameMisseis : IArma
{
    public string Nome { get; } = "Enxame de Mísseis";

    public string Descricao()
    {
        return $"Um enxame de mísseis que pode causar grande dano ao inimigo.";
    }

    public EnxameMisseis()
    {
        // Construtor da classe EnxameMisseis
    }
    public List<string> Atirar()
    {
        //Conle.WriteLine("Enxame de mísseis lançado!");
        return new List<string> { "Uma saraivada de mísseis foi lançada!" };
    }
}
