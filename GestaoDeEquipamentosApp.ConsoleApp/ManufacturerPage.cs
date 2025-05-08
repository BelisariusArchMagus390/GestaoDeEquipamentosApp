using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class ManufacturerPage
    {
        public static ManufacturerDataBase Data;
        public static Input Input = new Input();
        private static int IndexCount = 1;

        public ManufacturerPage(ManufacturerDataBase manufacturerData)
        {
            Data = manufacturerData;
        }
    }
}
