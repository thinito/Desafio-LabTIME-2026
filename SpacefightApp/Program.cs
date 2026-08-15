using System;
using System.Security.Cryptography.X509Certificates;
using Desafio_LabTIME_2026.Menus;
using Desafio_LabTIME_2026.NaveEspacial;


class Program
{
    static void Main()
    {
        var nave = new Nave();
        MenuPrincipal.Exibir(nave);
    }
}
