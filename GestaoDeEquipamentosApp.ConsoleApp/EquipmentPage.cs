using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class EquipmentPage
    {
        public static EquipmentDataBase Data;
        public static Input Input = new Input();
        
        public EquipmentPage(EquipmentDataBase equipmentData)
        {
            Data = equipmentData;
        }

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

        public void register()
        {
            Equipment equipment = new Equipment();

            equipment.Id = createId();

            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n REGISTRO DE EQUIPAMENTO");
            Console.WriteLine("\n --------------------------------------------");

            Console.Write("\n Digite seu nome: ");
            equipment.Name = Console.ReadLine();

            Console.WriteLine();

            equipment.PurchasePrice = Input.verifyDecimalValue(" Digite o seu preço de aquisição: ");

            Console.WriteLine();

            Console.Write(" Digite o número de série: ");
            equipment.SerialNumber = Console.ReadLine();

            Console.WriteLine();

            equipment.ManufactureDate = Input.verifyDateTime(" Digite a data de fabricação: ");

            Console.WriteLine();

            Console.Write(" Digite o nome do fabricante: ");
            equipment.Manufacturer = Console.ReadLine();

            Data.Equipments.Add(equipment);

            Console.WriteLine("\n Equipamento registrado com sucesso!");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void showEquipments()
        {
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            foreach (Equipment e in Data.Equipments)
            {
                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -15}",
                    e.Id, e.Name, e.PurchasePrice.ToString("C2"), e.SerialNumber, e.Manufacturer, e.ManufactureDate.ToShortDateString()
                );
            }
        }

        private int findIndexEquipment()
        {
            int index = 0;

            while (true)
            {
                Console.Clear();
                Console.Write("\n Entre com o ID do equipamento: ");
                int id = int.Parse(Console.ReadLine());

                bool equipmentFound = false;
                foreach (Equipment e in Data.Equipments)
                {
                    if (e.Id == id)
                    {
                        Data.Equipments.IndexOf(e);
                        break;
                    }
                }

                if (equipmentFound == true)
                    break;
                else
                    Input.showErrorMessage(" Esse equipamento não existe.");
            }
            return index;
        }

        public void edit()
        {
            int equipmentIndex = findIndexEquipment();

            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n EDIÇÃO DE REGISTRO DE EQUIPAMENTO");
            Console.WriteLine("\n --------------------------------------------");

            Console.Write("\n Digite seu novo nome: ");
            Data.Equipments[equipmentIndex].Name = Console.ReadLine();

            Console.WriteLine();

            Data.Equipments[equipmentIndex].PurchasePrice = Input.verifyDecimalValue(" Digite o seu novo preço de aquisição: ");

            Console.WriteLine();

            Console.Write(" Digite o seu novo número de série: ");
            Data.Equipments[equipmentIndex].SerialNumber = Console.ReadLine();

            Console.WriteLine();

            Data.Equipments[equipmentIndex].ManufactureDate = Input.verifyDateTime(" Digite a novo data de fabricação: ");

            Console.WriteLine();

            Console.Write(" Digite o novo nome do fabricante: ");
            Data.Equipments[equipmentIndex].Manufacturer = Console.ReadLine();

            Console.WriteLine("\n Registro de equipamento atualizado com sucesso!");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void delete()
        {
            int equipmentIndex = findIndexEquipment();

            Data.Equipments.RemoveAt(equipmentIndex);

            Console.WriteLine("\n Registro de equipamento removido com sucesso!");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
