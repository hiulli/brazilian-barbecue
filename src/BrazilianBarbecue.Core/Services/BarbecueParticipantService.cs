using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Services
{
    public class BarbecueParticipantService : IBarbecueParticipantService
    {   
        private readonly IBarbecueParticipantRepository _barbecueParticipantRepository;

        public BarbecueParticipantService(IBarbecueParticipantRepository barbecueParticipantRepository)
        {
            _barbecueParticipantRepository = barbecueParticipantRepository;         
        }

        public CommandResult ConfirmPayment(int id)
        {
            try
            {
                _barbecueParticipantRepository.ConfirmPayment(id);
                return new CommandResult("Pagamento confirmado", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar confirmar o pagamento do churrasco", false, null);
            }
        }

        public CommandResult Delete(int id)
        {
            try
            {
                _barbecueParticipantRepository.Delete(id);
                return new CommandResult("Participante excluido do churrasco com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar excluir o participante do churrasco", false, null);
            }
        }

        public CommandResult GetAllByBarbecueId(int id)
        {
            try
            {
                return new CommandResult(string.Empty, true, _barbecueParticipantRepository.GetAllByBarbecueId(id));
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao listar os participantes do churraco", false, null);
            }
        }

        public CommandResult GetById(int id)
        {
            try
            {
                return new CommandResult(string.Empty, true, _barbecueParticipantRepository.GetById(id));
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar retonar o participante do churraco", false, null);
            }
        }

        public CommandResult Insert(CreateBarbecueParticipantCommand cmd)
        {
            try
            {
                cmd.Validate();

                if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

                _barbecueParticipantRepository.Insert(new BarbecueParticipant(cmd));

                return new CommandResult("Participante incluído com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar incluir o participante", false, null);
            }
        }

        public CommandResult Update(UpdateBarbecueParticipantCommand cmd)
        {
            try
            {
                cmd.Validate();

                if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

                _barbecueParticipantRepository.Update(new BarbecueParticipant(cmd));
                return new CommandResult("Participante alterado com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar alterar o participante", false, null);
            }
        }
    }
}
