namespace Desafio_LabTIME_2026.Armamento.Armas;

public interface IArma
{
    string Nome { get; }
    string Descricao();
    List<string> Atirar();
}
    