using Flunt.Notifications;
using Flunt.Validations;

namespace BrazilianBarbecue.Core.Model.Commands.Input
{
    public class UpdateBarbecueParticipantCommand : Notifiable<Notification>
    {
        public int Id { get; set; }        
        public int BarbecueId { get; set; }
        public int ParticipantId { get; set; }
        public decimal ContributionAmount { get; set; }
        public bool Payed { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateBarbecueParticipantCommand>()
                .IsGreaterThan(Id, 0, "O campo 'Id' é de preenchimento obrigatório")
                .IsGreaterThan(BarbecueId, 0, "Precisa selecionar um churrasco")
                .IsGreaterThan(ParticipantId, 0, "Precisa selecionar um Participante")
                .IsGreaterThan(ContributionAmount, 0, "Precisa informar um valor de contribuição"));
        }
    }
}
