using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Entities
{
    public class Barbecue
    {
        public Barbecue(CreateBarbecueCommand cmd)
        {
            BarbecueDate = cmd.BarbecueDate;
            Description = cmd.Description;
            AdditionalObservations = cmd.AdditionalObservations;
            SuggestedAmountDrink = cmd.SuggestedAmountDrink;
            SuggestedAmountFood = cmd.SuggestedAmountFood;
        }

        public Barbecue(UpdateBarbecueCommand cmd)
        {
            Id = cmd.Id;         
            BarbecueDate = cmd.BarbecueDate;
            Description = cmd.Description;
            AdditionalObservations = cmd.AdditionalObservations;
            SuggestedAmountDrink = cmd.SuggestedAmountDrink;
            SuggestedAmountFood = cmd.SuggestedAmountFood;
        }

        public int Id { get; private set; }        
        public DateTime BarbecueDate { get; private set; }
        public string Description { get; private set; }
        public string AdditionalObservations { get; private set; }
        public decimal? SuggestedAmountDrink { get; private set; }
        public decimal? SuggestedAmountFood { get; private set; }
    }
}
