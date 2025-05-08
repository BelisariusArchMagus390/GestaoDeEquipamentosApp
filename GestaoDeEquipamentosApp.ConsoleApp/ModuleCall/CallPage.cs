using GestaoDeEquipamentosApp.ConsoleApp.ModuleEquipment;
using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleCall
{
    internal class CallPage
    {
        public static CallDataBase Data;
        public static Input Input = new Input();
        private static int IndexCount = 1;

        public CallPage(CallDataBase callData)
        {
            Data = callData;
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
            EquipmentDataBase dataEquipment = new EquipmentDataBase();

            while (true)
            {
                Console.Clear();
                Console.Write("\n Entre com o ID do equipamento: ");
                int id = int.Parse(Console.ReadLine());

                bool equipmentFound = false;
                foreach (Equipment e in dataEquipment.Equipments)
                {
                    if (e.Id == id)
                    {
                        equipment = e;
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

            Data.Calls.Add(call);
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
                foreach (Call c in Data.Calls)
                {
                    if (c.Id == id)
                    {
                        Data.Calls.IndexOf(c);
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
            Data.Calls[callIndex].Title = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n Digite a descrição do chamado: ");
            Data.Calls[callIndex].Description = Console.ReadLine();

            Data.Calls[callIndex].EquipmentRegister = findEquipment();

            Console.WriteLine();
            Data.Calls[callIndex].OpenCallDate = Input.verifyDateTime(" Digite a data do chamado: ");

            Console.Clear();
            Console.WriteLine("\n Registro de chamado atualizado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void delete()
        {
            int callIndex = findIndexCall();

            Data.Calls.RemoveAt(callIndex);

            Console.WriteLine("\n Registro de chamado removido com sucesso!");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void showCalls()
        {
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
                "Id", "Título", "Descrição", "Equipamento", "Data Abertura"
            );

            foreach (Call c in Data.Calls)
            {
                if (c == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -20}",
                    c.Id, c.Title, c.Description, c.EquipmentRegister.Name, c.OpenCallDate.ToShortDateString()
                );
            }

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
