using BrazilianBarbecue.Core.Entities.Model.Result;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model.Commands.Input;
using Microsoft.AspNetCore.Mvc;

namespace BrazilianBarbecue.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BarbecueController : ControllerBase
    {
        readonly IBarbecueParticipantService _barbecueParticipantService;
        readonly IBarbecueService _barbecueService;

        public BarbecueController(IBarbecueParticipantService barbecueParticipantService, IBarbecueService barbecueService)
        {
            _barbecueParticipantService = barbecueParticipantService;
            _barbecueService = barbecueService;
        }

        #region Barbecue
        [HttpPost]
        public CommandResult Insert([FromBody] CreateBarbecueCommand cmd) => _barbecueService.Insert(cmd);

        [HttpDelete("{id:int}")]
        public CommandResult Delete([FromRoute] int id) => _barbecueService.Delete(id);

        [HttpPut]
        public CommandResult Update([FromBody] UpdateBarbecueCommand cmd) => _barbecueService.Update(cmd);

        [HttpGet("all")]
        public CommandResult GetAll() => _barbecueService.GetAll();

        [HttpGet("{id:int}")]
        public CommandResult GetById([FromRoute] int id) => _barbecueService.GetById(id);

        [HttpGet("{id:int}/detail")]
        public CommandResult GetDetailById([FromRoute] int id) => _barbecueService.GetDetailById(id);
        #endregion

        #region BarbecueParticipant
        [HttpPost("participant")]
        public CommandResult InsertParticipant([FromBody] CreateBarbecueParticipantCommand cmd) => _barbecueParticipantService.Insert(cmd);

        [HttpPut("participant")]
        public CommandResult UpdateParticipant([FromBody] UpdateBarbecueParticipantCommand cmd) => _barbecueParticipantService.Update(cmd);

        [HttpDelete("participant/{id:int}")]
        public CommandResult DeleteParticipant([FromRoute] int id) => _barbecueParticipantService.Delete(id);

        [HttpGet("/{id:int}/participant")]
        public CommandResult GetAllByBarbecueId([FromRoute] int id) => _barbecueParticipantService.GetAllByBarbecueId(id);

        [HttpPost("/participant/{id:int}/confirm-payment")]
        public CommandResult ConfirmPayment([FromRoute] int id) => _barbecueParticipantService.ConfirmPayment(id);
        #endregion
    }
}
