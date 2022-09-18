using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model.Commands.Input;
using BrazilianBarbecue.Core.Model.Commands.Results;

namespace BrazilianBarbecue.Core.Services
{
    public class BarbecueService : IBarbecueService
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IBarbecueParticipantRepository _barbecueParticipantRepository;

        public BarbecueService(IBarbecueRepository barbecueRepository
            , IBarbecueParticipantRepository barbecueParticipantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _barbecueParticipantRepository = barbecueParticipantRepository;

        }

        public CommandResult Delete(int id)
        {
            try
            {
                _barbecueParticipantRepository.DeleteAllByBarbecueId(id);
                _barbecueRepository.Delete(id);
                return new CommandResult("Churrasco excluído com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar excluir o churrasco", false, null);
            }
        }

        public CommandResult GetAll()
        {
            try
            {   
                return new CommandResult(string.Empty, true, _barbecueRepository.GetAll());
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar listar os churrasco", false, null);
            }
        }

        public CommandResult GetById(int id)
        {
            try
            {
                return new CommandResult(string.Empty, true, _barbecueRepository.GetById(id));
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar retornar o churrasco", false, null);
            }
        }

        public CommandResult GetDetailById(int id)
        {
            try
            {
                BarbecueDetailResult data = _barbecueRepository.GetDetailById(id);
                data.Participants.AddRange(_barbecueParticipantRepository.GetAllByBarbecueId(id).ToList());
                

                return new CommandResult(string.Empty, true, data);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar retornar o churrasco", false, null);
            }
        }

        public CommandResult Insert(CreateBarbecueCommand cmd)
        {
            try
            {
                cmd.Validate();
                if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

                _barbecueRepository.Insert(new Barbecue(cmd));
                return new CommandResult("Churrasco agendado com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar agendar o churrasco", false, null);
            }
        }

        public CommandResult Update(UpdateBarbecueCommand cmd)
        {
            cmd.Validate();

            if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

            try
            {
                _barbecueRepository.Update(new Barbecue(cmd));
                return new CommandResult("Churrasco agendado foi alterado com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar alterar o churrasco", false, null);
            }
        }
    }
}
