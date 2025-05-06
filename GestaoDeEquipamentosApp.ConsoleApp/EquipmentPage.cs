using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class EquipmentPage
    {
        public DataBase Data;
        /*
        public EquipmentPage()
        {
            Data = new DataBase();
        }
        */

        private int createId()
        {
            Random randomId = new Random();
            int id = 0;

            while (true)
            {
                id = randomId.Next(100, 200);

                bool equal = false;
                foreach (var i in Data.Equipments)
                {
                    if (i.Id == id)
                        equal = true;
                }

                if (equal == false)
                    break;
            }
            return id;
        }

        public char showMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE EQUIPAMENTOS");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine("\n 1 - Registrar novo equipamento");
            Console.WriteLine(" 2 - Mostrar equipamentos");
            Console.WriteLine(" 3 - Atualizar registro de equipamento");
            Console.WriteLine(" 4 - Excluir equipamentos");
            Console.WriteLine(" 5 - Sair");

            char option = Console.ReadLine()[0];

            return option;
        }

        public void createEquipment()
        {
            EquipmentBack equipment = new EquipmentBack();

            equipment.Id = createId();

            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n REGISTRO DE EQUIPAMENTO");
            Console.WriteLine("\n --------------------------------------------");

            Console.Write("\n Digite seu nome: ");
            equipment.Name = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Digite o seu preço de aquisição: ");
            equipment.PurchasePrice = Decimal.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write(" Digite o número de série: ");
            equipment.SerialNumber = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Digite a data de fabricação: ");
            equipment.ManufactureDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write(" Digite o nome do fabricante: ");
            equipment.Manufacturer = Console.ReadLine();

            Data.Equipments.Add(equipment);

            Console.WriteLine("\n Equipamento registrado com sucesso!");
        }

        public void showEquipments()
        {
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            foreach (EquipmentBack e in Data.Equipments)
            {
                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -15}",
                    e.Id, e.Name, e.PurchasePrice.ToString("C2"), e.SerialNumber, e.Manufacturer, e.ManufactureDate.ToShortDateString()
                );
            }
        }
    }
}
