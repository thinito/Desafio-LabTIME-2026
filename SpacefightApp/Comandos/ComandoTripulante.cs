namespace Desafio_LabTIME_2026.Comandos;

using System;
using Desafio_LabTIME_2026.Tripulacao;
using Desafio_LabTIME_2026.NaveEspacial;


public class ComandoTripulante : IComando
{
    private readonly Nave _nave;

    private readonly TripulacaoManager _tripulacaoManager;

    public ComandoTripulante( Nave nave)
	{

		_nave = nave;
		_tripulacaoManager = new TripulacaoManager();
	}

    public void Executar()
    {
        TripulacaoManager.ListarTripulantes(_nave.tripulantes);
        TripulacaoManager.ListarCargos();
    }

}
