using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class ManufacturerPage
    {
        public static ManufacturerDataBase Data;
        public static Input Input = new Input();
        private static int IndexCount = 1;

        public ManufacturerPage(ManufacturerDataBase manufacturerData)
        {
            Data = manufacturerData;
        }

        public char showMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE FABRICANTES");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine("\n 1 - Registrar novo fabricante");
            Console.WriteLine(" 2 - Mostrar fabricantes");
            Console.WriteLine(" 3 - Atualizar registro de fabricante");
            Console.WriteLine(" 4 - Excluir registro de fabricante");
            Console.WriteLine(" 5 - Sair");

            char option = Console.ReadLine()[0];

            return option;
        }

        public void register()
        {
            Manufacturer manufacturer = new Manufacturer();

            manufacturer.Id = IndexCount;

            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n REGISTRO DE FABRICANTE");
            Console.WriteLine("\n --------------------------------------------");

            Console.Write("\n Digite o nome do fabricante: ");
            manufacturer.Name = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Digite o e-mail do fabricante: ");
            manufacturer.Email = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Digite o telefone do fabricante: ");
            manufacturer.Telephone = Console.ReadLine();

            Data.Manufacturers.Add(manufacturer);
            IndexCount++;

            Console.WriteLine("\n Fabricante registrado com sucesso!");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        private int findIndexManufacturer()
        {
            int index = 0;

            while (true)
            {
                Console.Clear();
                Console.Write("\n Entre com o ID do fabricante: ");
                int id = int.Parse(Console.ReadLine());

                bool manufacturerFound = false;
                foreach (Manufacturer m in Data.Manufacturers)
                {
                    if (m.Id == id)
                    {
                        Data.Manufacturers.IndexOf(m);
                        break;
                    }
                }

                if (manufacturerFound == true)
                    break;
                else
                    Input.showErrorMessage(" Esse fabricante não existe.");
            }
            return index;
        }

        public void edit()
        {
            int manufacturerIndex = findIndexCall();

            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n REGISTRO DE FABRICANTE");
            Console.WriteLine("\n --------------------------------------------");

            Console.Write("\n Digite o nome do fabricante: ");
            Data.Manufacturers[manufacturerIndex].Name = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Digite o e-mail do fabricante: ");
            Data.Manufacturers[manufacturerIndex].Email = Console.ReadLine();

            Console.WriteLine();

            Console.Write(" Digite o telefone do fabricante: ");
            Data.Manufacturers[manufacturerIndex].Telephone = Console.ReadLine();

            Console.WriteLine("\n Registrado de fabricante atualizado com sucesso!");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
