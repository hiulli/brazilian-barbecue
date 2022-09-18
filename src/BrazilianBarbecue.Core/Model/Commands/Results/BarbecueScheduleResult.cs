namespace BrazilianBarbecue.Core.Model.Commands.Results
{
    public class BarbecueScheduleResult
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public DateTime BarbecueDate { get; set; }
        public string Description { get; set; }
        public string AdditionalObservations { get; set; }
        public decimal? SuggestedAmountDrink { get; set; }
        public decimal? SuggestedAmountFood { get; set; }
    }
}
