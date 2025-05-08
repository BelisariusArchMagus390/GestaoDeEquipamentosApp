namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EquipmentDataBase equipmentData = new EquipmentDataBase();

            EquipmentPage ep = new EquipmentPage(equipmentData);
        }
    }
}
