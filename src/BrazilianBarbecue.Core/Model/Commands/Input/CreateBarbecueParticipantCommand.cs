using Flunt.Notifications;
using Flunt.Validations;

namespace BrazilianBarbecue.Core.Model.Commands.Input
{
    public class CreateBarbecueParticipantCommand : Notifiable<Notification>
    {   
        public int BarbecueId { get; set; }
        public int ParticipantId { get; set; }
        public decimal ContributionAmount { get; set; }
        public bool Payed { get; set; } = false;

        public void Validate()
        {
            AddNotifications(new Contract<CreateBarbecueParticipantCommand>()
                .IsGreaterThan(BarbecueId, 0, "Precisa selecionar um churrasco")
                .IsGreaterThan(ParticipantId, 0, "Precisa selecionar um Participante")
                .IsGreaterThan(ContributionAmount, 0, "Precisa informar um valor de contribuição"));
        }
    }
}
