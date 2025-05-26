using GestaoDeEquipamentosApp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleShared
{
    public abstract class PageModel
    {
        protected string EntityName;
        protected DataBaseModel DataBase;
        static Input InputVer;

        protected PageModel(string entityName, DataBaseModel dataBase)
        {
            this.EntityName = entityName;
            this.DataBase = dataBase;
        }

        public char showMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE {EntityName.ToUpper()}");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine($"\n 1 - Registrar novo {EntityName}");
            Console.WriteLine($" 2 - Mostrar {EntityName}s");
            Console.WriteLine($" 3 - Atualizar registro de {EntityName}");
            Console.WriteLine($" 4 - Excluir registro de {EntityName}");
            Console.WriteLine(" 5 - Sair");

            Console.Write("\n Escolha uma das opções acima: ");
            char option = Console.ReadLine()[0];

            return option;
        }

        public void register()
        {
            EntityModel newRegister = getDate();

            string errors = newRegister.validate();

            if (errors.Length > 0)
            {
                Console.Clear();

                Console.WriteLine(errors);

                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();

                register();

                return;
            }

            DataBase.addRegister(newRegister);

            Console.Clear();
            Console.WriteLine($"\n {EntityName} registrado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void edit()
        {
            showRegisters();

            int id = InputVer.verifyIntValue("\n Entre com o ID do registro que deseja: ");

            EntityModel updatedRegister = getDate();

            Console.Clear();

            if (DataBase.editRegister(id, updatedRegister))
                Console.WriteLine($"\n {EntityName} atualizado com sucesso!");
            else
                Console.WriteLine($"\n Erro! Não foi encontrado o ID desejado.");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void delete()
        {
            showRegisters();

            int id = InputVer.verifyIntValue("\n Entre com o ID do registro que deseja: ");

            Console.Clear();

            if (DataBase.deleteRegister(id))
                Console.WriteLine($"\n {EntityName} apagado com sucesso!");
            else
                Console.WriteLine($"\n Erro! Não foi encontrado o ID desejado.");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public abstract void showRegisters(bool showForSelection = false);

        protected abstract EntityModel getDate();
    }
}
