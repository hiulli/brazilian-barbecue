namespace BrazilianBarbecue.Core.Model.Commands.Results
{
    public class BarbecueParticipantResult
    {
        public int Id { get; private set; }
        public int BarbecueScheduleId { get; private set; }
        public int ParticipantId { get; private set; }
        public decimal ContributionAmount { get; private set; }
        public bool Payed { get; private set; }
    }
}
