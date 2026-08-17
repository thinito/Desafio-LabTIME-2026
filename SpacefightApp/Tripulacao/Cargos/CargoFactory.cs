using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_LabTIME_2026.Tripulacao.Cargos;
public static class CargoFactory
{
    public static ICargo Criar(int numeroCargo)
    {
        return numeroCargo switch
        {
            1 => new PilotoNave(),
            2 => new Medico(),
            3 => new OperadorCanhoes(),
            4 => new EngenheiroEscudos(),
            5 => new MecanicoMotor(),
            6 => new Cozinheiro(),
            _ => throw new ArgumentException("\n- Cargo inválido")
        };
    }

    public static void ListarCargos()
    {
        Console.WriteLine("Cargos disponíveis:");
        Console.WriteLine("1: PilotoNave\n2: Medico\n3: OperadorCanhoes\n4: EngenheiroEscudos\n5: MecanicoMotor\n6: Cozinheiro\n");
    }
}