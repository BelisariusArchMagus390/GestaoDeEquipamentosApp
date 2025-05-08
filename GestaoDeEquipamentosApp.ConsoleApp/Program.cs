namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Program
    {
        static Input input = new Input();

        static EquipmentDataBase equipmentData = new EquipmentDataBase();
        static EquipmentPage ep = new EquipmentPage(equipmentData);

        static CallDataBase callData = new CallDataBase();
        static CallPage cp = new CallPage(callData);

        static ManufacturerDataBase manufacturerData = new ManufacturerDataBase();
        static ManufacturerPage mp = new ManufacturerPage(manufacturerData);

        static void Main(string[] args)
        {
            bool ifExit = false;
            while (ifExit == false)
            {
                char option = showGeneralMenu();

                switch (option)
                {
                    case '1':
                        equipmentOperations();
                        break;

                    case '2':
                        callOperations();
                        break;

                    case '3':
                        manufacturerOperations();
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

            Console.WriteLine("\n 1 - Gestão de equípamentos");
            Console.WriteLine(" 2 - Gestão de chamados");
            Console.WriteLine(" 3 - Gestão de fabricantes");
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
                char option = ep.showMenu();

                switch (option)
                {
                    case '1':
                        ep.register();
                        break;

                    case '2':
                        ep.showEquipments();
                        break;

                    case '3':
                        ep.edit();
                        break;

                    case '4':
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
                char option = cp.showMenu();

                switch (option)
                {
                    case '1':
                        cp.register();
                        break;

                    case '2':
                        cp.showCalls();
                        break;

                    case '3':
                        cp.edit();
                        break;

                    case '4':
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
                char option = cp.showMenu();

                switch (option)
                {
                    case '1':
                        mp.register();
                        break;

                    case '2':
                        mp.showManufacturers();
                        break;

                    case '3':
                        mp.edit();
                        break;

                    case '4':
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
