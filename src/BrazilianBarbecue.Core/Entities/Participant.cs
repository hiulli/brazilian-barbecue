using BrazilianBarbecue.Core.Model.Commands.Input;

namespace BrazilianBarbecue.Core.Entities
{   
    public class Participant
    {
        public Participant(CreateParticipantCommand cmd)
        {
            Name = cmd.Name;
            Email = cmd.Email;
        }

        public Participant(UpdateParticipantCommand cmd)
        {
            Id = cmd.Id;
            Name = cmd.Name;
            Email = cmd.Email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
