using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleCall
{
    internal class Call
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Equipment EquipmentRegister { get; set; }
        public DateTime OpenCallDate { get; set; }
    }
}
