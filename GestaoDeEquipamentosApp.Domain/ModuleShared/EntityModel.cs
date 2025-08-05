namespace GestaoDeEquipamentosApp.Domain.ModuleShared
{
    public abstract class EntityModel<Type>
    {
        public int Id { get; set; }

        public abstract void updateRegister(Type updatedRegister);
        public abstract string validate();
    }
}
