namespace BrazilianBarbecue.Core.Model.Commands.Results
{
    public class BarbecueParticipantResult
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int BarbecueId { get; private set; }
        public int ParticipantId { get; private set; }
        public decimal ContributionAmount { get; private set; }
        public bool Payed { get; private set; }
    }
}
