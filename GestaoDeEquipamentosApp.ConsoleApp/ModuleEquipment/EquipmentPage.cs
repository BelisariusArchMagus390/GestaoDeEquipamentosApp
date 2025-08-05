using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using GestaoDeEquipamentosApp.Domain.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleManufacturer;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment
{
    internal class EquipmentPage
    {
        private static EquipmentDataBase Data;
        public static Input Input = new Input();
        public static ManufacturerPage Mp;

        public EquipmentDataBase getData()
        {
            return Data;
        }

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
            {
                id = randomId.Next(100, 200);

                bool equal = false;
                foreach (var i in Data.selectRegister())
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

            Console.Write("\n Escolha uma das opções acima: ");
            char option = Console.ReadLine()[0];

            return option;
        }

        public void register()
        {
            Equipment equipment = new Equipment();

            equipment.Id = createId();

            Console.Clear();
            Console.Write("\n Digite o nome do equipamento: ");
            equipment.Name = Console.ReadLine();

            equipment.PurchasePrice = Input.verifyDecimalValue("\n Digite o seu preço de aquisição: ");

            Console.Clear();
            Console.Write("\n Digite o número de série do equipamento: ");
            equipment.SerialNumber = Console.ReadLine();

            equipment.ManufactureDate = Input.verifyDateTime("\n Digite a data de fabricação: ");

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

            while (true)
            {
                Console.Clear();

                showEquipments();

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
                else
                    Input.showErrorMessage("Esse equipamento não existe.");
            }
            return index;
        }

        public void edit()
        {
            int equipmentIndex = findIndexEquipment();

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
        }
    }
}
