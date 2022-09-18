using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IBarbecueParticipantService
    {
        CommandResult Insert(CreateBarbecueParticipantCommand cmd);

        CommandResult Update(UpdateBarbecueParticipantCommand cmd);

        CommandResult Delete(int id);

        CommandResult GetAllByBarbecueId(int id);

        CommandResult GetById(int id);

        CommandResult ConfirmPayment(int id);
    }
}
