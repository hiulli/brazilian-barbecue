using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Model.Commands.Results;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IBarbecueRepository : IRepository<Barbecue>
    {
        IEnumerable<BarbecueResult> GetAll();

        BarbecueResult GetById(int id);

        BarbecueDetailResult GetDetailById(int id);
    }
}
