using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> AddNewMessage(Message message)
        {
            try
            {
                message.SendingTime = DateTime.Now;
                return await _messageRepository.AddNewMessage(message);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<MessageUserViewModel>> GetCandidateListForEmployerMessageList(int companyId)
        {
            try
            {
                
                var data= await _messageRepository.GetCandidateListForEmployerMessageList(companyId);

                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<MessageUserViewModel>> GetCompanyListForCandidateMessageList(int candidateId)
        {
            try
            {
                
                return await _messageRepository.GetCompanyListForCandidateMessageList(candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateMessageSeen(UpdateMessageSeenBodyModel updateMessageSeenBodyModel)
        {
            try
            {

                return  _messageRepository.UpdateMessageSeen(updateMessageSeenBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<MessageDetailsViewModel>> GetMessageDetails(MessageDetailsBodyModel messageDetailsBodyModel)
        {
            try
            {

                return await _messageRepository.GetMessageDetails(messageDetailsBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<MessageNotificationViewModel> GetCandidateMessageNotification(int candidateId)
        {
            try
            {
                return await _messageRepository.GetCandidateMessageNotification(candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<MessageNotificationViewModel> GetCompanyMessageNotification(int companyId)
        {
            try
            {
                return await _messageRepository.GetCompanyMessageNotification(companyId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
