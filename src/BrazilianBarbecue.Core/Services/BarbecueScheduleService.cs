using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model.Commands.Input;


namespace BrazilianBarbecue.Core.Services
{
    public class BarbecueScheduleService : IBarbecueScheduleService
    {
        private readonly IBarbecueScheduleRepository _barbecueScheduleRepository;

        public BarbecueScheduleService(IBarbecueScheduleRepository barbecueScheduleRepository)
        {
            _barbecueScheduleRepository = barbecueScheduleRepository;

        }

        public CommandResult Delete(int id)
        {
            try
            {
                _barbecueScheduleRepository.Delete(id);
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
                return new CommandResult(string.Empty, true, _barbecueScheduleRepository.GetAll());
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
                return new CommandResult(string.Empty, true, _barbecueScheduleRepository.GetById(id));
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar retornar o churrasco", false, null);
            }
        }

        public CommandResult Insert(CreateBarbecueScheduleCommand cmd)
        {
            try
            {
                cmd.Validate();
                if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

                _barbecueScheduleRepository.Insert(new BarbecueSchedule(cmd));
                return new CommandResult("Churrasco agendado com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar agendar o churrasco", false, null);
            }
        }

        public CommandResult Update(UpdateBarbecueScheduleCommand cmd)
        {
            cmd.Validate();

            if (!cmd.IsValid) return new CommandResult("Error", false, cmd.Notifications);

            try
            {
                _barbecueScheduleRepository.Update(new BarbecueSchedule(cmd));
                return new CommandResult("Churrasco agendado foi alterado com sucesso", true, null);
            }
            catch
            {
                return new CommandResult("Ocorreu um erro ao tentar alterar o churrasco", false, null);
            }
        }
    }
}
