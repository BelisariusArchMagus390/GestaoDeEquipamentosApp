using GestaoDeEquipamentosApp.ConsoleApp.ModuleCall;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Program
    {
        static Input input = new Input();

        static ManufacturerDataBase manufacturerData = new ManufacturerDataBase();
        static EquipmentDataBase equipmentData = new EquipmentDataBase();
        static CallDataBase callData = new CallDataBase();

        static ManufacturerPage mp = new ManufacturerPage(manufacturerData);

        static EquipmentPage ep = new EquipmentPage(
            equipmentData, 
            manufacturerData
        );

        static CallPage cp = new CallPage(
            callData,
            equipmentData
        );

        static void Main(string[] args)
        {
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
                        ep.showRegisters();
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
                        cp.showRegisters();
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
                        mp.showRegisters();
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
