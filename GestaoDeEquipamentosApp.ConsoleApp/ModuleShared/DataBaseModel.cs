using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleShared
{
    public abstract class DataBaseModel
    {
        private List<EntityModel> Registers = new List<EntityModel>();
        private static int IndexCount = 0;

        public void addRegister(EntityModel newRegister)
        {
            newRegister.Id = IndexCount;
            Registers.Add(newRegister);
            IndexCount++;
        }

        public bool editRegister(int id, EntityModel updatedRegister)
        {
            EntityModel register = selectRegisterById(id);

            if (register == null)
                return false;

            register.updateRegister(updatedRegister);

            return true;
        }

        public bool deleteRegister(int id)
        {
            EntityModel register = selectRegisterById(id);

            if (register != null)
            {
                int index = Registers.IndexOf(register);
                Registers.RemoveAt(index);
                return true;
            }
            return false;
        }

        public List<EntityModel> selectRegister()
        {
            return Registers;
        }

        public EntityModel selectRegisterById(int id)
        {
            foreach (Manufacturer m in Registers)
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
