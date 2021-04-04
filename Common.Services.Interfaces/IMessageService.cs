using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message> AddNewMessage(Message message);
        Task<IEnumerable<MessageUserViewModel>> GetCandidateListForEmployerMessageList(int companyId);
        Task<IEnumerable<MessageUserViewModel>> GetCompanyListForCandidateMessageList(int candidateId);
        bool UpdateMessageSeen(UpdateMessageSeenBodyModel updateMessageSeenBodyModel);
        Task<IEnumerable<MessageDetailsViewModel>> GetMessageDetails(MessageDetailsBodyModel messageDetailsBodyModel);
        Task<MessageNotificationViewModel> GetCompanyMessageNotification(int companyId);
        Task<MessageNotificationViewModel> GetCandidateMessageNotification(int candidateId);
    }
}
