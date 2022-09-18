using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IBarbecueScheduleService
    {
        CommandResult Insert(CreateBarbecueScheduleCommand cmd);

        CommandResult Update(UpdateBarbecueScheduleCommand cmd);

        CommandResult Delete(int id);

        CommandResult GetAll();

        CommandResult GetById(int id);
    }
}
