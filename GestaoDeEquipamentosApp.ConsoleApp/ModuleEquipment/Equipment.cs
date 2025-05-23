using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment
{
    internal class Equipment : EntityModel
    {
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
