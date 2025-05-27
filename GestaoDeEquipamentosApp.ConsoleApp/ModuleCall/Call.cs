using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleCall
{
    public class Call : EntityModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Equipment EquipmentRegister { get; set; }
        public DateTime OpenCallDate { get; set; }

        public override string validate()
        {
            string errors = "";

            if (string.IsNullOrWhiteSpace(Title))
                errors += "O campo \"Título\" é obrigatório.\n";

            else if (Title.Length < 3)
                errors += "O campo \"Título\" precisa conter ao menos 3 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Description))
                errors += "O campo \"Descrição\" é obrigatório.\n";

            if (EquipmentRegister == null)
                errors += "O campo \"Equipamento\" é obrigatório.\n";

            return errors;
        }

        public override void updateRegister(EntityModel updatedRegister)
        {
            Call callUpdated = (Call)updatedRegister;

            this.Title = callUpdated.Title;
            this.Description = callUpdated.Description;
            this.EquipmentRegister = callUpdated.EquipmentRegister;
            this.OpenCallDate = callUpdated.OpenCallDate;
        }
    }
}
