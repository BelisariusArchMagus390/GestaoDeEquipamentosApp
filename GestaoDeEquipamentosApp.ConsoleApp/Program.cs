using GestaoDeEquipamentosApp.ConsoleApp.ModuleCall;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Program
    {
        static Input input = new Input();

        static EquipmentDataBase equipmentData = new EquipmentDataBase();
        static EquipmentPage ep = new EquipmentPage(equipmentData);

        static CallDataBase callData = new CallDataBase();
        static CallPage cp = new CallPage(callData, equipmentData);

        static ManufacturerDataBase manufacturerData = new ManufacturerDataBase();
        static ManufacturerPage mp = new ManufacturerPage();
        
        
        static void Main(string[] args)
        {
            mp.setData(manufacturerData);

            bool ifExit = false;
            while (ifExit == false)
            {
                Console.Clear();

                char option = showGeneralMenu();

                switch (option)
                {
                    case '1':
                        manufacturerOperations();
                        break;

                    case '2':
                        equipmentOperations();
                        break;

                    case '3':
                        callOperations();
                        break;

                    case '4':
                        ifExit = true;
                        break;

                    default:
                        input.showErrorMessage(" Essa opção não existe.");
                        break;
                }
            }
        }

        static char showGeneralMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n SISTEMA DE GESTÃO");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine("\n 1 - Gestão de fabricantes");
            Console.WriteLine(" 2 - Gestão de equípamentos");
            Console.WriteLine(" 3 - Gestão de chamados");
            Console.WriteLine(" 4 - Sair");
            Console.Write("\n Escolha uma das opções acima: ");

            char option = Console.ReadLine()[0];

            return option;
        }

        static void equipmentOperations()
        {
            bool ifExit = false;
            while (ifExit == false)
            {
                Console.Clear();

                char option = ep.showMenu();

                switch (option)
                {
                    case '1':
                        Console.Clear();
                        ep.register();
                        break;

                    case '2':
                        Console.Clear();
                        ep.showEquipments();
                        break;

                    case '3':
                        Console.Clear();
                        ep.edit();
                        break;

                    case '4':
                        Console.Clear();
                        ep.delete();
                        break;

                    case '5':
                        ifExit = true;
                        break;

                    default:
                        input.showErrorMessage(" Essa opção não existe.");
                        break;
                }
            }
        }

        static void callOperations()
        {
            bool ifExit = false;
            while (ifExit == false)
            {
                Console.Clear();

                char option = cp.showMenu();

                switch (option)
                {
                    case '1':
                        Console.Clear();
                        cp.register();
                        break;

                    case '2':
                        Console.Clear();
                        cp.showCalls();
                        break;

                    case '3':
                        Console.Clear();
                        cp.edit();
                        break;

                    case '4':
                        Console.Clear();
                        cp.delete();
                        break;

                    case '5':
                        ifExit = true;
                        break;

                    default:
                        input.showErrorMessage(" Essa opção não existe.");
                        break;
                }
            }
        }

        static void manufacturerOperations()
        {
            bool ifExit = false;
            while (ifExit == false)
            {
                Console.Clear();

                char option = mp.showMenu();

                switch (option)
                {
                    case '1':
                        Console.Clear();
                        mp.register();
                        break;

                    case '2':
                        Console.Clear();
                        mp.showManufacturers();
                        break;

                    case '3':
                        Console.Clear();
                        mp.edit();
                        break;

                    case '4':
                        Console.Clear();
                        mp.delete();
                        break;

                    case '5':
                        ifExit = true;
                        break;

                    default:
                        input.showErrorMessage(" Essa opção não existe.");
                        break;
                }
            }
        }
    }
}
