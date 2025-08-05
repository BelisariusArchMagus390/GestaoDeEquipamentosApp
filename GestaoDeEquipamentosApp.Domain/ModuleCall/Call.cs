using GestaoDeEquipamentosApp.Domain.ModuleEquipment;
using GestaoDeEquipamentosApp.Domain.ModuleShared;

namespace GestaoDeEquipamentosApp.Domain.ModuleCall
{
<<<<<<< HEAD:GestaoDeEquipamentosApp.Domain/ModuleCall/Call.cs
    public class Call : EntityModel<Call>
=======
    public class Call : EntityModel
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7:GestaoDeEquipamentosApp.ConsoleApp/ModuleCall/Call.cs
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

        public override void updateRegister(Call updatedRegister)
        {
            Call callUpdated = updatedRegister;

            this.Title = callUpdated.Title;
            this.Description = callUpdated.Description;
            this.EquipmentRegister = callUpdated.EquipmentRegister;
            this.OpenCallDate = callUpdated.OpenCallDate;
        }
    }
}
