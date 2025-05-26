namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleShared
{
    public abstract class EntityModel
    {
        public int Id { get; set; }

        public abstract void updateRegister(EntityModel updatedRegister);
        public abstract string validate();
    }
}
