using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class CallPage
    {
        public static CallDataBase Data;
        public static Input Input;
        private static int IndexCount = 0;

        public CallPage(CallDataBase callData)
        {
            Data = callData;
        }

        public char showMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE CHAMADOS");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine("\n 1 - Registrar novo chamado");
            Console.WriteLine(" 2 - Mostrar chamados");
            Console.WriteLine(" 3 - Atualizar registro de chamado");
            Console.WriteLine(" 4 - Excluir chamado");
            Console.WriteLine(" 5 - Sair");

            char option = Console.ReadLine()[0];

            return option;
        }
    }
}
