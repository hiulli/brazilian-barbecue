using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Model.Commands.Results;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IBarbecueParticipantRepository : IRepository<BarbecueParticipant>
    {
        IEnumerable<BarbecueParticipantResult> GetAllByBarbecueId(int id);

        BarbecueParticipantResult GetById(int id);

        void ConfirmPayment(int id);
    }
}
