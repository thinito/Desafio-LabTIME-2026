namespace Desafio_LabTIME_2026.Nucleo;

using Desafio_LabTIME_2026.Sistema;
using Desafio_LabTIME_2026.Nucleo.Estados;
using System;
using System.Collections.Generic;


public class NucleoEnergia
{
    public int Energia { get; private set; }
    private IEstadoNucleo _estado;
    public string EstadoAtual => _estado.GetType().Name;

    private List<ISistema> _observers = new List<ISistema>();

    public NucleoEnergia()
    {
        Energia = 100;
        _estado = new EstadoNormal();
    }

    public void AdicionarSistema(ISistema sistema)
    {
        if (!_observers.Contains(sistema)) _observers.Add(sistema);
    }

    private void NotificarObservers(EventoNucleo evento)
    {
        foreach (var obs in _observers)
            obs.Atualizar(evento, this);
    }

    public void TomarDano(int valor)
    {
        Energia -= valor;
        _estado.RecebeDano(this, valor);
        VerificaEstado();
        NotificarObservers(EventoNucleo.DanoRecebido);
    }

    public void ReduzirEnergia()
    {
        Energia -= 20;
        _estado.RecebeDano(this, 20);
        VerificaEstado();
        NotificarObservers(EventoNucleo.EnergiaAlterada);
    }

    public void RecuperarEnergia()
    {
        Energia = 100;
        VerificaEstado();
        NotificarObservers(EventoNucleo.EnergiaRecuperada);
    }

    public void MudarEstado(IEstadoNucleo novoEstado)
    {
        _estado = novoEstado;
        _estado.NovoEstado(this);
    }

    public void VerificaEstado()
    {
        if (Energia <= 30 && !(_estado is EstadoCritico))
            MudarEstado(new EstadoCritico());
        else if (Energia > 30 && !(_estado is EstadoNormal))
            MudarEstado(new EstadoNormal());
    }
}