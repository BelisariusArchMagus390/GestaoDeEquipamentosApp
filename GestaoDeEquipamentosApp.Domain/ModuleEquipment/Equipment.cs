using GestaoDeEquipamentosApp.Domain.ModuleManufacturer;
using GestaoDeEquipamentosApp.Domain.ModuleShared;

namespace GestaoDeEquipamentosApp.Domain.ModuleEquipment
{
    public class Equipment : EntityModel<Equipment>
    {
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public override string validate()
        {
            string errors = "";

            if (string.IsNullOrWhiteSpace(Name))
                errors += "O campo \"Nome\" é obrigatório.\n";

            else if (Name.Length < 3)
                errors += "O campo \"Nome\" precisa conter ao menos 3 caracteres.\n";

            if (PurchasePrice <= 0)
                errors += "O campo \"Preço de Aquisição\" deve ser maior que zero.\n";

            if (ManufactureDate > DateTime.Now)
                errors += "O campo \"Data de Fabricação\" deve conter uma data passada.\n";

            return errors;
        }

        public override void updateRegister(Equipment updatedRegister)
        {
            Equipment equipmentUpdated = updatedRegister;

            this.Name = equipmentUpdated.Name;
            this.PurchasePrice = equipmentUpdated.PurchasePrice;
            this.SerialNumber = equipmentUpdated.SerialNumber;
            this.ManufactureDate = equipmentUpdated.ManufactureDate;
            this.Manufacturer = equipmentUpdated.Manufacturer;
        }
    }
}
