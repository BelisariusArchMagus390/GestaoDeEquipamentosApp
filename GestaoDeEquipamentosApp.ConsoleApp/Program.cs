using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            MainPage mainPage = new MainPage();

            while (true)
            {
                mainPage.showGeneralMenu();

                IPage mp = mainPage.GetPage();

                if (mp == null)
                    break;

                char option = mp.showMenu();

                if (char.ToUpper(option) == 'S')
                    break;

                switch (option)
                {
                    case '1':
                        mp.register();
                        break;

                    case '2':
                        mp.showRegisters();
                        break;

                    case '3':
                        mp.edit();
                        break;

                    case '4':
                        mp.delete();
                        break;
                    default:
                        input.showErrorMessage(" Essa opção não existe.");
                        break;
                }
            }
        }
    }
}
