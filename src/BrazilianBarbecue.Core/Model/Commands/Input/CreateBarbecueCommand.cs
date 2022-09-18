using Flunt.Notifications;
using Flunt.Validations;

namespace BrazilianBarbecue.Core.Model.Commands.Input
{  
    public class CreateBarbecueCommand : Notifiable<Notification>
    {   
        public DateTime BarbecueDate { get; set; }
        public string Description { get; set; }
        public string AdditionalObservations { get; set; }
        public decimal? SuggestedAmountDrink { get; set; }
        public decimal? SuggestedAmountFood { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateBarbecueCommand>()                
                .IsNotNullOrEmpty(AdditionalObservations, "AdditionalObservations", "O campo 'Observações' é de preenchimento obrigatório")
                .IsLowerThan(AdditionalObservations.Length, 500, "O campo 'Observações' excedeu os 500 caracteres")
                .IsNotNullOrEmpty(Description, "Description", "O campo 'Descricão' é de preenchimento obrigatório")
                .IsLowerThan(Description.Length, 50, "O campo 'Descricão' excedeu os 50 caracteres"));
        }
    }
}
