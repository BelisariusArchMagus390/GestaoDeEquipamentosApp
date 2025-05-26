using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment
{
    public class Equipment : EntityModel
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

        public override void updateRegister(EntityModel updatedRegister)
        {
            Equipment equipmentUpdated = (Equipment)updatedRegister;

            this.Name = equipmentUpdated.Name;
            this.PurchasePrice = equipmentUpdated.PurchasePrice;
            this.SerialNumber = equipmentUpdated.SerialNumber;
            this.ManufactureDate = equipmentUpdated.ManufactureDate;
            this.Manufacturer = equipmentUpdated.Manufacturer;
        }
    }
}
