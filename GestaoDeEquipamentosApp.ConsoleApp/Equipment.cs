using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Manufacturer { get; set; }
    }
}
