using GestaoDeEquipamentosApp.ConsoleApp.ModuleShared;
using System.Net.Mail;
using System.Xml.Linq;

namespace GestaoDeEquipamentosApp.ConsoleApp.ModuleManufacturer;

public class Manufacturer : EntityModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }

    public override string validate()
    {
        string errors = "";

        if (string.IsNullOrWhiteSpace(Name))
            errors += "O nome é obrigatório!\n";

        else if (Name.Length < 2)
            errors += "O nome deve conter mais que 1 caractere!\n";

        if (!MailAddress.TryCreate(Email, out _))
            errors += "O email deve conter um formato válido \"nome@provedor.com\"!\n";

        if (string.IsNullOrWhiteSpace(Telephone))
            errors += "O telefone é obrigatório!\n";

        else if (Telephone.Length < 9)
            errors += "O telefone deve conter no mínimo 9 caracteres!\n";

        return errors;
    }

    public override void updateRegister(EntityModel updatedRegister)
    {
        Manufacturer manufacturerUpdated = (Manufacturer)updatedRegister;

        this.Name = manufacturerUpdated.Name;
        this.Email = manufacturerUpdated.Email;
        this.Telephone = manufacturerUpdated.Telephone;
    }
}