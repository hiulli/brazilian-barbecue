using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model.Commands.Input;
using Microsoft.AspNetCore.Mvc;

namespace BrazilianBarbecue.WebAPI.Controllers
{
    [Route("api/[controller]")]    
    public class ParticipantController : ControllerBase
    {
        readonly IParticipantService _participantService;
        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public CommandResult Insert([FromBody] CreateParticipantCommand cmd) =>   _participantService.Insert(cmd);

        [HttpDelete("{id:int}")]
        public CommandResult Delete([FromRoute] int id) => _participantService.Delete(id);

        [HttpPut]
        public CommandResult Update([FromBody] UpdateParticipantCommand cmd) => _participantService.Update(cmd);
        
        [HttpGet("all")]
        public CommandResult GetAll() => _participantService.GetAll();
                
        [HttpGet("{id:int}")]
        public CommandResult GetById([FromRoute] int id) => _participantService.GetById(id);
    }
}
