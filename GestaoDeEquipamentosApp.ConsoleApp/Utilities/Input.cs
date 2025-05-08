using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp.Utilities
{
    internal class Input
    {
        // mostra mensagem de erro padrão
        public void showErrorMessage(string message)
        {
            Console.Clear();
            Console.WriteLine($"\n Erro! {message}");
            Console.WriteLine(" Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        // verifica se o input é um decimal
        public decimal verifyDecimalValue(string message)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(message);
                string value = Console.ReadLine();

                if (decimal.TryParse(value, out decimal decimalValue))
                {
                    return decimalValue;
                }
                else
                    showErrorMessage(" Esse não é um valor numérico.");
            }
        }

        // verifica se o input é um DateTime
        public DateTime verifyDateTime(string message)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(message);
                string value = Console.ReadLine();

                if (DateTime.TryParse(value, out DateTime DateTimeValue))
                {
                    return DateTimeValue;
                }
                else
                    showErrorMessage(" Esse não é um valor de data.");
            }
        }
    }
}
