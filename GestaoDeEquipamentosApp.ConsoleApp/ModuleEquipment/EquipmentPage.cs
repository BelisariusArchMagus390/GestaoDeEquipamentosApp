<<<<<<< HEAD
﻿using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using GestaoDeEquipamentosApp.Domain.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleManufacturer;
=======
﻿using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using static System.Runtime.InteropServices.JavaScript.JSType;
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment
{
    public class EquipmentPage : PageModel
    {
        static Input Input = new Input();
        private EquipmentDataBase EquipmentData;
        private ManufacturerDataBase ManufacturerData;

        public EquipmentPage(
            EquipmentDataBase EquipmentData,
            ManufacturerDataBase ManufacturerData
        ) : base("Equipamento", EquipmentData)
        {
            this.EquipmentData = EquipmentData;
            this.ManufacturerData = ManufacturerData;
        }

<<<<<<< HEAD
        public EquipmentPage(EquipmentDataBase equipmentData, ManufacturerDataBase manufacturerData)
        {
            Data = equipmentData;
            Mp = new ManufacturerPage(manufacturerData);
        }

        private int createId()
        {
            Random randomId = new Random();
            int id = 0;

            while (true)
=======
        public override void showRegisters(bool showForSelection = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
                " Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            foreach (Equipment e in EquipmentData.selectRegister())
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
            {
                if (e == null)
                    continue;

<<<<<<< HEAD
                bool equal = false;
                foreach (var i in Data.selectRegister())
                {
                    if (i.Id == id)
                        equal = true;
                }

                if (equal == false)
                    break;
=======
                Console.WriteLine(
                    " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -15}",
                    " " + e.Id, e.Name, e.PurchasePrice.ToString("C2"), e.SerialNumber, e.Manufacturer.Name, e.ManufactureDate.ToShortDateString()
                );
            }

            if (showForSelection == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
            }
        }

        protected override Equipment getDate()
        {
            Equipment equipment = new Equipment();

            Console.Clear();
            Console.Write("\n Digite o nome do equipamento: ");
            equipment.Name = Console.ReadLine();

            equipment.PurchasePrice = Input.verifyDecimalValue("\n Digite o seu preço de aquisição: ");

            Console.Clear();
            Console.Write("\n Digite o número de série do equipamento: ");
            equipment.SerialNumber = Console.ReadLine();

            equipment.ManufactureDate = Input.verifyDateTime("\n Digite a data de fabricação: ");

<<<<<<< HEAD
            int manufacturerIndex = Mp.findIndexManufacturer();
            equipment.Manufacturer = Mp.getData().selectRegister()[manufacturerIndex];

            Data.selectRegister().Add(equipment);

            Console.Clear();
            Console.WriteLine("\n Equipamento registrado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void showEquipments(bool showForSelection = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
                " Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            foreach (Equipment e in Data.selectRegister())
            {
                if (e == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -15}",
                    " "+e.Id, e.Name, e.PurchasePrice.ToString("C2"), e.SerialNumber, e.Manufacturer.Name, e.ManufactureDate.ToShortDateString()
                );
            }

            if (showForSelection == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        private int findIndexEquipment()
        {
            int index = 0;
=======
            Manufacturer manufacturer;
            int id;
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7

            while (true)
            {
                Console.Clear();
                id = Input.verifyIntValue("\n Entre com o ID do fornecedor que deseja: ");

                manufacturer = (Manufacturer)ManufacturerData.selectRegisterById(id);

<<<<<<< HEAD
                Console.Write("\n Entre com o ID do equipamento: ");
                int id = int.Parse(Console.ReadLine());

                bool equipmentFound = false;
                foreach (Equipment e in Data.selectRegister())
                {
                    if (e.Id == id)
                    {
                        Data.selectRegister().IndexOf(e);
                        equipmentFound = true;
                        break;
                    }
                }

                if (equipmentFound == true)
                    break;
=======
                if (manufacturer == null)
                    Console.WriteLine($"\n Erro! Não foi encontrado o ID desejado.");
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
                else
                    break;
            }

            equipment.Manufacturer = manufacturer;

<<<<<<< HEAD
            Console.Clear();
            Console.Write("\n Digite seu novo nome: ");
            Data.selectRegister()[equipmentIndex].Name = Console.ReadLine();

            Data.selectRegister()[equipmentIndex].PurchasePrice = Input.verifyDecimalValue("\n Digite o seu novo preço de aquisição: ");

            Console.Clear();
            Console.Write("\n Digite o seu novo número de série: ");
            Data.selectRegister()[equipmentIndex].SerialNumber = Console.ReadLine();

            Data.selectRegister()[equipmentIndex].ManufactureDate = Input.verifyDateTime("\n Digite a novo data de fabricação: ");

            Console.Clear();
            Console.Write("\n Digite o novo nome do fabricante: ");
            Data.selectRegister()[equipmentIndex].Manufacturer.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n Registro de equipamento atualizado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void delete()
        {
            int equipmentIndex = findIndexEquipment();

            Data.selectRegister().RemoveAt(equipmentIndex);

            Console.Clear();
            Console.WriteLine("\n Registro de equipamento removido com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
=======
            return equipment;
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
        }
    }
}
