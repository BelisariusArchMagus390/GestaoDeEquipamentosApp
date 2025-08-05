namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleShared
{
    public interface IPage
    {
        char showMenu();
        void register();
        void edit();
        void delete();
        void showRegisters();
    }
}
