using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Model.Commands.Results;

namespace BrazilianBarbecue.Core.Interfaces
{
    public interface IParticipantRepository: IRepository<Participant>
    {
        IEnumerable<ParticipantResult> GetAll();

        ParticipantResult GetById(int id);

        ParticipantResult GetByEmail(string email);
    }
}
