using Flunt.Notifications;
using Flunt.Validations;

namespace BrazilianBarbecue.Core.Model.Commands.Input
{
    public class CreateParticipantCommand : Notifiable<Notification>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateParticipantCommand>()
                .IsNotNullOrEmpty(Name, "Name", "O campo 'Nome' é de preenchimento obrigatório")
                .IsLowerThan(Name.Length, 150, "O campo 'Name' excedeu os 150 caracteres")
                .IsEmail(Email, "Email", "O campo 'Email' de preenchimento obrigatório ou é invalido")
                .IsLowerThan(Email.Length, 200, "O campo 'Email' excedeu os 200 caracteres"));
        }
    }
}
