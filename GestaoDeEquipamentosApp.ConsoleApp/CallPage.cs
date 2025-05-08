using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp
{
    internal class CallPage
    {
        public static CallDataBase Data;
        public static Input Input;

        public CallPage(CallDataBase callData)
        {
            Data = callData;
        }
    }
}
