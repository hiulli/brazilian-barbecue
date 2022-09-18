using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Entities
{
    public class BarbecueParticipant
    {
        public BarbecueParticipant(CreateBarbecueParticipantCommand cmd)
        {
            BarbecueScheduleId = cmd.BarbecueScheduleId;
            ParticipantId = cmd.ParticipantId;
            ContributionAmount = cmd.ContributionAmount;
            Payed = cmd.Payed;
        }

        public BarbecueParticipant(UpdateBarbecueParticipantCommand cmd)
        {
            Id = cmd.Id;
            BarbecueScheduleId = cmd.BarbecueScheduleId;
            ParticipantId = cmd.ParticipantId;
            ContributionAmount = cmd.ContributionAmount;
            Payed = cmd.Payed;
        }

        public int Id { get; private set; }
        public int BarbecueScheduleId { get; private set; }
        public int ParticipantId { get; private set; }
        public decimal ContributionAmount { get; private set; }
        public bool Payed { get; private set; }
    }
}
