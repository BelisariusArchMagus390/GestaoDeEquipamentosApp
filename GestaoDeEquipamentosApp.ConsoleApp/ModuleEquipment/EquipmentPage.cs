using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public override void showRegisters(bool showForSelection = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -20}",
                " Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            foreach (Equipment e in EquipmentData.selectRegister())
            {
                if (e == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20} | {5, -15}",
                    " " + e.Id, e.Name, e.PurchasePrice.ToString("C2"), e.SerialNumber, e.Manufacturer.Name, e.ManufactureDate.ToShortDateString()
                );
            }

            if (showForSelection == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
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

            Manufacturer manufacturer;
            int id;

            while (true)
            {
                Console.Clear();
                id = Input.verifyIntValue("\n Entre com o ID do fornecedor que deseja: ");

                manufacturer = (Manufacturer)ManufacturerData.selectRegisterById(id);

                if (manufacturer == null)
                    Console.WriteLine($"\n Erro! Não foi encontrado o ID desejado.");
                else
                    break;
            }

            equipment.Manufacturer = manufacturer;

            return equipment;
        }
    }
}
