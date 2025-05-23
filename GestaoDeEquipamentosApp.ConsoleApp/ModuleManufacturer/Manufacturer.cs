using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer
{
    internal class Manufacturer : EntityModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
