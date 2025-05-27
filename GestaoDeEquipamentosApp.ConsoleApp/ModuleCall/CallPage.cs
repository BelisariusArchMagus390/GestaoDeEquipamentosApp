using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleCall
{
    public class CallPage : PageModel
    {
        static Input Input;
        private CallDataBase CallData;
        private EquipmentDataBase EquipmentData;

        public CallPage(
            CallDataBase CallData,
            EquipmentDataBase EquipmentData
        ) : base("Chamado", CallData)
        {
            this.CallData = CallData;
            this.EquipmentData = EquipmentData;
        }

        public override void showRegisters(bool showForSelection = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
                " Id", "Título", "Descrição", "Equipamento", "Data Abertura"
            );

            foreach (Call c in CallData.selectRegister())
            {
                if (c == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
                    " " + c.Id, c.Title, c.Description, c.EquipmentRegister.Name, c.OpenCallDate.ToShortDateString()
                );
            }

            if (showForSelection == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        protected override Call getDate()
        {
            Call call = new Call();

            Console.Clear();
            Console.Write("\n Digite o título do chamado: ");
            call.Title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n Digite a descrição do chamado: ");
            call.Description = Console.ReadLine();

            Equipment equipment;
            int id;

            while (true)
            {
                Console.Clear();
                id = Input.verifyIntValue("\n Entre com o ID do equipamento que deseja: ");

                equipment = (Equipment)EquipmentData.selectRegisterById(id);

                if (equipment == null)
                    Console.WriteLine($"\n Erro! Não foi encontrado o ID desejado.");
                else
                    break;
            }
            call.EquipmentRegister = equipment;

            call.OpenCallDate = Input.verifyDateTime("\n Digite a data do chamado: ");

            return call;
        }
    }
}
