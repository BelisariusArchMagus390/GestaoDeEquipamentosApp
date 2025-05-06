using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Front
    {
        public char showMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE EQUIPAMENTOS");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine("\n 1 - Registrar novo equipamento");
            Console.WriteLine(" 2 - Mostrar equipamentos");
            Console.WriteLine(" 3 - Atualizar registro de equipamento");
            Console.WriteLine(" 4 - Excluir equipamentos");
            Console.WriteLine(" 5 - Sair");

            char option = Console.ReadLine()[0];

            return option;
        }
    }
}
