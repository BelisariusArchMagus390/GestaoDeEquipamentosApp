using GestaoDeEquipamentosApp.Domain.ModuleShared;

namespace GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleShared
{
    public abstract class DataBaseModel<Type> where Type : EntityModel<Type>
    {
        private List<Type> Registers = new List<Type>();
        private static int IndexCount = 0;

        public void addRegister(Type newRegister)
        {
            newRegister.Id = IndexCount;
            Registers.Add(newRegister);
            IndexCount++;
        }

        public bool editRegister(int id, Type updatedRegister)
        {
            Type register = selectRegisterById(id);

            if (register == null)
                return false;

            register.updateRegister(updatedRegister);

            return true;
        }

        public bool deleteRegister(int id)
        {
            Type register = selectRegisterById(id);

            if (register != null)
            {
                int index = Registers.IndexOf(register);
                Registers.RemoveAt(index);
                return true;
            }
            return false;
        }

        public List<Type> selectRegister()
        {
            return Registers;
        }

        public Type selectRegisterById(int id)
        {
            foreach (Type m in Registers)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }
    }
}