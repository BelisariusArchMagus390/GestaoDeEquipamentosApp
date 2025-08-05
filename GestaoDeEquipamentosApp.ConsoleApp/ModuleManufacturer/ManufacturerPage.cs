<<<<<<< HEAD
﻿using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using GestaoDeEquipamentosApp.Domain.ModuleEquipment;
using GestaoDeEquipamentosApp.Domain.ModuleManufacturer;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleManufacturer;
=======
﻿using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer
{
    public class ManufacturerPage : PageModel
    {
<<<<<<< HEAD
        private static ManufacturerDataBase Data;
        public static Input Input = new Input();
        private static int IndexCount = 1;

        public ManufacturerPage(ManufacturerDataBase data)
=======
        private ManufacturerDataBase Data;
    
        public ManufacturerPage(ManufacturerDataBase Data)
            : base("Fabricante", Data)
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
        {
            this.Data = Data;
        }

        public override void showRegisters(bool showForSelection = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -20} | {2, -10} | {3, -10} ",
                " Id", "Nome", "E-mail", "Telefone"
            );

            foreach (Manufacturer m in Data.selectRegister())
            {
                if (m == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -20} | {2, -10} | {3, -10} ",
                    " "+m.Id, m.Name, m.Email, m.Telephone
                );
            }

            if (showForSelection == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        protected override Manufacturer getDate()
        {
            Manufacturer manufacturer = new Manufacturer();

            Console.Clear();
            Console.Write("\n Digite o nome do fabricante: ");
            manufacturer.Name = Console.ReadLine();

            Console.Clear();
            Console.Write("\n Digite o e-mail do fabricante: ");
            manufacturer.Email = Console.ReadLine();

            Console.Clear();
            Console.Write("\n Digite o telefone do fabricante: ");
            manufacturer.Telephone = Console.ReadLine();

<<<<<<< HEAD
            Data.selectRegister().Add(manufacturer);
            IndexCount++;

            Console.Clear();
            Console.WriteLine("\n Fabricante registrado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public int findIndexManufacturer()
        {
            int index = 0;

            while (true)
            {
                Console.Clear();

                showManufacturers();

                Console.Write("\n Entre com o ID do fabricante: ");
                int id = int.Parse(Console.ReadLine());

                bool manufacturerFound = false;
                foreach (Manufacturer m in Data.selectRegister())
                {
                    if (m.Id == id)
                    {
                        Data.selectRegister().IndexOf(m);
                        manufacturerFound = true;
                        break;
                    }
                }

                if (manufacturerFound == true)
                    break;
                else
                    Input.showErrorMessage("Esse fabricante não existe.");
            }
            return index;
        }

        public void edit()
        {
            int manufacturerIndex = findIndexManufacturer();

            Console.Clear();
            Console.Write("\n Digite o nome do fabricante: ");
            Data.selectRegister()[manufacturerIndex].Name = Console.ReadLine();

            Console.Clear();
            Console.Write("\n Digite o e-mail do fabricante: ");
            Data.selectRegister()[manufacturerIndex].Email = Console.ReadLine();

            Console.Clear();
            Console.Write("\n Digite o telefone do fabricante: ");
            Data.selectRegister()[manufacturerIndex].Telephone = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n Registrado de fabricante atualizado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void delete()
        {
            int manufacturerIndex = findIndexManufacturer();

            Data.selectRegister().RemoveAt(manufacturerIndex);

            Console.Clear();
            Console.WriteLine("\n Registro de fabricante removido com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void showManufacturers(bool showForSelection = false)
        {
            EquipmentDataBase equipmentData = new EquipmentDataBase();
            List<Equipment> equipmentsList = equipmentData.selectRegister();

            Console.WriteLine(
                " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
                " Id", "Nome", "E-mail", "Telefone", "Quantidade de equipamentos"
            );

            foreach (Manufacturer m in Data.selectRegister())
            {
                if (m == null)
                    continue;

                int contEquipment = 0;

                for (int i = 0; i < equipmentsList.Count; i++)
                {
                    if (m.Name == equipmentsList[i].Manufacturer.Name)
                        contEquipment++;
                }

                Console.WriteLine(
                    " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
                    " "+m.Id, m.Name, m.Email, m.Telephone, contEquipment
                );
            }

            if (showForSelection == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
=======
            return manufacturer;
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
        }
    }
}
