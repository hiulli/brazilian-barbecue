using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IParticipantService
    {
        CommandResult Insert(CreateParticipantCommand cmd);

        CommandResult Update(UpdateParticipantCommand cmd);

        CommandResult Delete(int id);

        CommandResult GetAll();

        CommandResult GetById(int id);
    }
}
