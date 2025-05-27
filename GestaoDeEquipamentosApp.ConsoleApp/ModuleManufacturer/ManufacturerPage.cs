using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer
{
    public class ManufacturerPage : PageModel
    {
        private ManufacturerDataBase Data;
    
        public ManufacturerPage(ManufacturerDataBase Data)
            : base("Fabricante", Data)
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

        protected override EntityModel getDate()
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

            return manufacturer;
        }
    }
}
