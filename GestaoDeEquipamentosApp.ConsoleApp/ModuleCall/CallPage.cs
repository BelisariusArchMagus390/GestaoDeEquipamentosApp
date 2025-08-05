using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using GestaoDeEquipamentosApp.Domain.ModuleCall;
using GestaoDeEquipamentosApp.Domain.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleCall;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleEquipment;
using GestaoDeEquipamentosApp.Infrastructure.Memory.ModuleManufacturer;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleCall
{
    public class CallPage : PageModel
    {
        static Input Input = new Input();
        private CallDataBase CallData;
        private EquipmentDataBase EquipmentData;

<<<<<<< HEAD
        public CallPage(CallDataBase callData, EquipmentDataBase equipmentData, ManufacturerDataBase manufacturerData)
        {
            Data = callData;
            Ep = new EquipmentPage(equipmentData, manufacturerData);
            Input = new Input();
            IndexCount = 1;
        }

        public char showMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE CHAMADOS");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine("\n 1 - Registrar novo chamado");
            Console.WriteLine(" 2 - Mostrar chamados");
            Console.WriteLine(" 3 - Atualizar registro de chamado");
            Console.WriteLine(" 4 - Excluir chamado");
            Console.WriteLine(" 5 - Sair");

            Console.Write("\n Escolha uma das opções acima: ");
            char option = Console.ReadLine()[0];

            return option;
        }

        private Equipment findEquipment()
        {
            Equipment equipment = new Equipment();
            EquipmentDataBase dataEquipment = Ep.getData();

            while (true)
            {
                Console.Clear();

                Ep.showEquipments();

                Console.Write("\n Entre com o ID do equipamento: ");
                int id = int.Parse(Console.ReadLine());

                bool equipmentFound = false;
                foreach (Equipment e in dataEquipment.selectRegister())
                {
                    if (e.Id == id)
                    {
                        equipment = e;
                        equipmentFound = true;
                        break;
                    }
                }

                if (equipmentFound == true)
                    break;
                else
                    Input.showErrorMessage("Esse equipamento não existe.");
            }
            return equipment;
        }

        public void register()
        {
            Call call = new Call();

            call.Id = IndexCount;

            Console.Clear();
            Console.Write("\n Digite o título do chamado: ");
            call.Title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n Digite a descrição do chamado: ");
            call.Description = Console.ReadLine();

            Console.WriteLine();
            call.EquipmentRegister = findEquipment();

            call.OpenCallDate = Input.verifyDateTime("\n Digite a data do chamado: ");

            Data.selectRegister().Add(call);
            IndexCount++;

            Console.Clear();
            Console.WriteLine("\n Chamado registrado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        private int findIndexCall()
        {
            int index = 0;

            while (true)
            {
                Console.Clear();
                Console.Write("\n Entre com o ID do chamado: ");
                int id = int.Parse(Console.ReadLine());

                bool callFound = false;
                foreach (Call c in Data.selectRegister())
                {
                    if (c.Id == id)
                    {
                        Data.selectRegister().IndexOf(c);
                        callFound = true;
                        break;
                    }
                }

                if (callFound == true)
                    break;
                else
                    Input.showErrorMessage("Esse chamado não existe.");
            }
            return index;
        }

        public void edit()
        {
            int callIndex = findIndexCall();

            Console.Clear();
            Console.Write("\n Digite o título do chamado: ");
            Data.selectRegister()[callIndex].Title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n Digite a descrição do chamado: ");
            Data.selectRegister()[callIndex].Description = Console.ReadLine();

            Data.selectRegister()[callIndex].EquipmentRegister = findEquipment();

            Console.WriteLine();
            Data.selectRegister()[callIndex].OpenCallDate = Input.verifyDateTime(" Digite a data do chamado: ");

            Console.Clear();
            Console.WriteLine("\n Registro de chamado atualizado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void delete()
        {
            int callIndex = findIndexCall();

            Data.selectRegister().RemoveAt(callIndex);

            Console.Clear();
            Console.WriteLine("\n Registro de chamado removido com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void showCalls(bool showForSelection = false)
=======
        public CallPage(
            CallDataBase CallData,
            EquipmentDataBase EquipmentData
        ) : base("Chamado", CallData)
        {
            this.CallData = CallData;
            this.EquipmentData = EquipmentData;
        }

        public override void showRegisters(bool showForSelection = false)
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
        {
            Console.WriteLine(
                " {0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
                " Id", "Título", "Descrição", "Equipamento", "Data Abertura"
            );

<<<<<<< HEAD
            foreach (Call c in Data.selectRegister())
=======
            foreach (Call c in CallData.selectRegister())
>>>>>>> d2d24aefd89f1124d39ccbd6da024df386285cb7
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
