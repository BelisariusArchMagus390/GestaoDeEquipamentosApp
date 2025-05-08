namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EquipmentDataBase data = new EquipmentDataBase();

            EquipmentPage ep = new EquipmentPage();
            ep.Data = data;
        }
    }
}
