using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IBarbecueService
    {
        CommandResult Insert(CreateBarbecueCommand cmd);

        CommandResult Update(UpdateBarbecueCommand cmd);

        CommandResult Delete(int id);

        CommandResult GetAll();

        CommandResult GetById(int id);

        CommandResult GetDetailById(int id);
    }
}
