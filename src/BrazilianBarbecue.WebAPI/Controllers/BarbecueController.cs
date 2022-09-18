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
        readonly IBarbecueScheduleService _barbecueScheduleService;

        public BarbecueController(IBarbecueParticipantService barbecueParticipantService, IBarbecueScheduleService barbecueScheduleService)
        {
            _barbecueParticipantService = barbecueParticipantService;
            _barbecueScheduleService = barbecueScheduleService;
        }

        #region BarbecueSchedule
        [HttpPost("scheduling")]
        public CommandResult Scheduling([FromBody] CreateBarbecueScheduleCommand cmd) => _barbecueScheduleService.Insert(cmd);

        [HttpDelete("{id:int}")]
        public CommandResult RemoveBarbecueSchedule([FromRoute] int id) => _barbecueScheduleService.Delete(id);

        [HttpPut]
        public CommandResult Update([FromBody] UpdateBarbecueScheduleCommand cmd) => _barbecueScheduleService.Update(cmd);

        [HttpGet("all")]
        public CommandResult GetAll() => _barbecueScheduleService.GetAll();

        [HttpGet("{id:int}")]
        public CommandResult GetById([FromRoute] int id) => _barbecueScheduleService.GetById(id);
        #endregion

        #region BarbecueParticipant
        [HttpPost("scheduling/participant")]
        public CommandResult InsertParticipant([FromBody] CreateBarbecueParticipantCommand cmd) => _barbecueParticipantService.Insert(cmd);

        [HttpPut("scheduling/participant")]
        public CommandResult UpdateParticipant([FromBody] UpdateBarbecueParticipantCommand cmd) => _barbecueParticipantService.Update(cmd);

        [HttpDelete("scheduling/participant/{id:int}")]
        public CommandResult RemoveBarbecueParticipant([FromRoute] int id) => _barbecueParticipantService.Delete(id);

        [HttpGet("/scheduling/{id:int}/participant")]
        public CommandResult GetAllByBarbecueId([FromRoute] int id) => _barbecueParticipantService.GetAllByBarbecueId(id);

        [HttpPost("/scheduling/participant/{id:int}/confirm-payment")]
        public CommandResult ConfirmPayment([FromRoute] int id) => _barbecueParticipantService.ConfirmPayment(id);
        #endregion
    }
}
