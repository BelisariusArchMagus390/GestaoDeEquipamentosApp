using GestaoDeEquipamentosApp.ConsoleApp.ModuleCall;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleCall;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleManufacturer;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleShared
{
    public class MainPage
    {
        private char Option;

        private EquipmentDataBase EquipmentData;
        private EquipmentPage EquipmentPage;

        private CallDataBase CallData;
        private CallPage CallPage;

        private ManufacturerDataBase ManufacturerData;
        private ManufacturerPage ManufacturerPage;
        
        public MainPage()
        {
            ManufacturerData = new ManufacturerDataBase();
            ManufacturerPage = new ManufacturerPage(ManufacturerData);

            EquipmentData = new EquipmentDataBase();
            EquipmentPage = new EquipmentPage(EquipmentData, ManufacturerData);

            CallData = new CallDataBase();
            CallPage = new CallPage(CallData, EquipmentData, ManufacturerData);
        }

        public void showGeneralMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n SISTEMA DE GESTÃO");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine("\n 1 - Gestão de fabricantes");
            Console.WriteLine(" 2 - Gestão de equípamentos");
            Console.WriteLine(" 3 - Gestão de chamados");
            Console.WriteLine(" 4 - Sair");
            Console.Write("\n Escolha uma das opções acima: ");

            Option = Console.ReadLine()[0];
        }

        public IPage GetPage()
        {
            if (Option == '1')
                return ManufacturerPage;

            else if (Option == '2')
                return EquipmentPage;

            else if (Option == '3')
                return CallPage;

            return null;
        } 
    }
}
