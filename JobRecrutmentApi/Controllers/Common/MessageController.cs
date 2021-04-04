using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Common
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService )
        {
            _messageService = messageService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("AddNewMessage")]
        public async Task<IActionResult> AddNewMessage([FromBody] Message message)
        {
            try
            {
                var data = await _messageService.AddNewMessage(message); 
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@message} on {AddNewMessage}", message, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetCandidateListForEmployerMessageList/{companyId}")]
        public async Task<IActionResult> GetCandidateListForEmployerMessageList(int companyId)
        {
            try
            {
                var data = await _messageService.GetCandidateListForEmployerMessageList(companyId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@companyId} on {LoadCandidateListForEmployerMessageList}", companyId, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetCompanyListForCandidateMessageList/{candidateId}")]
        public async Task<IActionResult> GetCompanyListForCandidateMessageList(int candidateId)
        {
            try
            {
                var data = await _messageService.GetCompanyListForCandidateMessageList(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateId} on {GetCompanyListForCandidateMessageList}", candidateId, DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateMessageSeen")]
        public IActionResult UpdateMessageSeen([FromBody] UpdateMessageSeenBodyModel updateMessageSeenBodyModel)
        {
            try
            {
                var data =  _messageService.UpdateMessageSeen(updateMessageSeenBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@updateMessageSeenBodyModel} on {UpdateMessageSeen}", updateMessageSeenBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetMessageDetails")]
        public IActionResult GetMessageDetails([FromBody] MessageDetailsBodyModel messageDetailsBodyModell)
        {
            try
            {
                var data = _messageService.GetMessageDetails(messageDetailsBodyModell);
                return Ok(data.Result);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@messageDetailsBodyModell} on {GetMessageDetails}", messageDetailsBodyModell, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetCandidateMessageNotification/{candidateId}")]
        public async Task<IActionResult> GetCandidateMessageNotification(int candidateId)
        {
            try
            {
                var data = await _messageService.GetCandidateMessageNotification(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateId} on {GetCandidateMessageNotification}", candidateId, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetCompanyMessageNotification/{companyId}")]
        public async Task<IActionResult> GetCompanyMessageNotification(int companyId)
        {
            try
            {
                var data = await _messageService.GetCompanyMessageNotification(companyId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@companyId} on {GetCompanyMessageNotification}", companyId, DateTime.Now);
                throw exception;
            }
        }



    }
}
