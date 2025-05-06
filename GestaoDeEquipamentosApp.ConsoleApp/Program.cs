namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase data = new DataBase();

            EquipmentPage ep = new EquipmentPage();
            ep.Data = data;
        }
    }
}
