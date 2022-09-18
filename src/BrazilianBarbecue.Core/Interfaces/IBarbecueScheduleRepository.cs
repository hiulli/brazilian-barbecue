using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Model.Commands.Results;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IBarbecueScheduleRepository : IRepository<BarbecueSchedule>
    {
        IEnumerable<BarbecueScheduleResult> GetAll();

        BarbecueScheduleResult GetById(int id);

        BarbecueDetailResult GetDetailById(int id);
    }
}
