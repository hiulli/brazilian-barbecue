using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Services
{
    public class ParticipantService : IParticipantService
    {   
        private readonly IParticipantRepository _participantRepository;

        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;     
        }

        public CommandResult Insert(CreateParticipantCommand cmd)
        {
            try
            {
                cmd.Validate();

                if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

                _participantRepository.Insert(new Participant(cmd));

                return new CommandResult("Participante incluído com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar gravar participante", false, null);
            }
        }

        public CommandResult Update(UpdateParticipantCommand cmd)
        {
            try
            {
                cmd.Validate();

                if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

                _participantRepository.Update(new Participant(cmd));
                return new CommandResult("Participante alterado com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar alterar o participante", false, null);
            }
        }

        public CommandResult Delete(int id)
        {
            try
            {
                _participantRepository.Delete(id);
                return new CommandResult("Participante excluido com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar excluir o participante", false, null);
            }
        }

        public CommandResult GetAll()
        {
            try
            {   
                return new CommandResult(string.Empty, true, _participantRepository.GetAll());
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar listar os participantes", false, null);
            }
        }

        public CommandResult GetById(int id)
        {
            try
            {
                return new CommandResult(string.Empty, true, _participantRepository.GetById(id));
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar retornar o participante", false, null);
            }
        }
    }
}
