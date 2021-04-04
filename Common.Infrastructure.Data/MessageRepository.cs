using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Common.Domain.Entities.BodyModel;

namespace Common.Infrastructure.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public MessageRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<Message> AddNewMessage(Message message)
        {
            try
            {
                await _sqlServerContext.Message.AddAsync(message);
                await _sqlServerContext.SaveChangesAsync();

                return message;
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
                var query = await (from m in _sqlServerContext.Message
                                  join c in _sqlServerContext.Candidates on m.CandidateId equals c.CandidateId
                                  join j in _sqlServerContext.Jobs on m.JobId equals j.JobId
                                  join a in _sqlServerContext.AppliedJob on m.CandidateId equals a.CandidateId 
                                  where a.JobId == m.JobId && m.CompanyId == companyId && m.IsDelete==false
                                  orderby m.SendingTime descending
                                  select new MessageUserViewModel
                                  {
                                      CandidateId=m.CandidateId,
                                      CandidateName=c.CandidateName,
                                      JobId=m.JobId,
                                      JobTitle=j.JobTitle,
                                      CompanyId=m.CompanyId,
                                      StatusId = (from s in _sqlServerContext.AppliedJob
                                                  where s.CandidateId == m.CandidateId
                                                             && s.JobId == m.JobId
                                                             && s.CompanyId == m.CompanyId
                                                  orderby s.ApplicationId descending
                                                  select s.StatusId).FirstOrDefault(),
                                      ApplicationId = a.ApplicationId,
                                      IsReceivedCandidate = (from sm in _sqlServerContext.Message
                                                             where sm.CandidateId == m.CandidateId
                                                             && sm.JobId == m.JobId
                                                             && sm.CompanyId == m.CompanyId
                                                             orderby sm.SendingTime descending
                                                             select sm.IsReceivedCandidate).FirstOrDefault(),
                                      IsReceivedEmploye = (from sm in _sqlServerContext.Message
                                                           where sm.CandidateId == m.CandidateId
                                                           && sm.JobId == m.JobId
                                                           && sm.CompanyId == m.CompanyId
                                                           orderby sm.SendingTime descending
                                                           select sm.IsReceivedEmploye).FirstOrDefault(),
                                      LastSendingTime =(from sm in _sqlServerContext.Message
                                                       where sm.CandidateId== m.CandidateId 
                                                       && sm.JobId == m.JobId 
                                                       && sm.CompanyId == m.CompanyId
                                                       orderby sm.SendingTime descending
                                                       select sm.SendingTime).FirstOrDefault(),
                                      LastSendingMessage= (from sm in _sqlServerContext.Message
                                                           where sm.CandidateId == m.CandidateId
                                                           && sm.JobId == m.JobId
                                                           && sm.CompanyId == m.CompanyId
                                                           && sm.IsDelete==false
                                                           orderby sm.SendingTime descending
                                                           select sm.MessageBody).FirstOrDefault()
                                  }).Distinct().ToListAsync();

                var data = query.Select(x => x).OrderByDescending(x => x.LastSendingTime);

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
                var query = await (from m in _sqlServerContext.Message
                                  join c in _sqlServerContext.Companies on m.CompanyId equals c.CompanyId
                                  join j in _sqlServerContext.Jobs on m.JobId equals j.JobId
                                  join a in _sqlServerContext.AppliedJob on m.CompanyId equals a.CompanyId
                                  where a.JobId == m.JobId && m.CandidateId == candidateId && m.IsDelete == false && a.CandidateId== candidateId
                                  orderby m.SendingTime descending
                                  select new MessageUserViewModel
                                  {
                                      CandidateId = m.CandidateId,
                                      JobId = m.JobId,
                                      JobTitle = j.JobTitle,
                                      CompanyId = m.CompanyId,
                                      CompanyName = c.CompanyName,
                                      StatusId = (from s in _sqlServerContext.AppliedJob
                                                  where s.CandidateId == m.CandidateId
                                                             && s.JobId == m.JobId
                                                             && s.CompanyId == m.CompanyId orderby s.ApplicationId descending
                                                  select s.StatusId).FirstOrDefault(),
                                      ApplicationId = a.ApplicationId,
                                      IsReceivedCandidate = (from sm in _sqlServerContext.Message
                                                             where sm.CandidateId == m.CandidateId
                                                             && sm.JobId == m.JobId
                                                             && sm.CompanyId == m.CompanyId
                                                             orderby sm.SendingTime descending
                                                             select sm.IsReceivedCandidate).FirstOrDefault(),
                                      IsReceivedEmploye = (from sm in _sqlServerContext.Message
                                                           where sm.CandidateId == m.CandidateId
                                                           && sm.JobId == m.JobId
                                                           && sm.CompanyId == m.CompanyId
                                                           orderby sm.SendingTime descending
                                                           select sm.IsReceivedEmploye).FirstOrDefault(),
                                      LastSendingTime = (from sm in _sqlServerContext.Message
                                                         where sm.CandidateId == m.CandidateId
                                                         && sm.JobId == m.JobId
                                                         && sm.CompanyId == m.CompanyId
                                                         orderby sm.SendingTime descending
                                                         select sm.SendingTime).FirstOrDefault(),
                                      LastSendingMessage = (from sm in _sqlServerContext.Message
                                                            where sm.CandidateId == m.CandidateId
                                                            && sm.JobId == m.JobId
                                                            && sm.CompanyId == m.CompanyId
                                                            && sm.IsDelete == false
                                                            orderby sm.SendingTime descending
                                                            select sm.MessageBody).FirstOrDefault()
                                  }).Distinct().ToListAsync();

                var data = query.Select(x => x).OrderByDescending(x => x.LastSendingTime);
                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateMessageSeen( UpdateMessageSeenBodyModel updateMessageSeenBodyModel)
        {
            try
            {
                var entity = _sqlServerContext.Message.Where(x => x.CompanyId == updateMessageSeenBodyModel.CompanyId 
                                                            && x.CandidateId == updateMessageSeenBodyModel.CandidateId 
                                                            && x.JobId== updateMessageSeenBodyModel.JobId
                                                            ).ToList();
                if(entity !=null)
                {
                    if (updateMessageSeenBodyModel.SenderType=="candidate")
                    {
                        foreach(var i in entity)
                        {
                            i.IsReceivedCandidate = true;
                        }
                    }
                    if (updateMessageSeenBodyModel.SenderType == "company")
                    {
                        foreach (var i in entity)
                        {
                            i.IsReceivedEmploye = true;
                        }
                    }

                    _sqlServerContext.SaveChanges();


                    return true;

                }
                else
                {
                    return false;
                }

                
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
                var data = await (from m in _sqlServerContext.Message
                                  where m.CandidateId == messageDetailsBodyModel.CandidateId
                                  && m.CompanyId == messageDetailsBodyModel.CompanyId
                                  && m.JobId == messageDetailsBodyModel.JobId
                                  group m by new { y = m.SendingTime.Year, m = m.SendingTime.Month, d = m.SendingTime.Day } into groupDate
                                  
                                  select new MessageDetailsViewModel
                                  {
                                      SendingDate= groupDate.FirstOrDefault().SendingTime.Date,
                                      Messages = _sqlServerContext.Message.Where(w => w.CandidateId == messageDetailsBodyModel.CandidateId
                                      && w.CompanyId == messageDetailsBodyModel.CompanyId
                                      && w.JobId == messageDetailsBodyModel.JobId
                                      && w.SendingTime.Date == groupDate.FirstOrDefault().SendingTime.Date
                                      )
                                      .GroupBy(g => g.MessageId).Select(sm => new Message
                                      {
                                          MessageId = sm.FirstOrDefault().MessageId,
                                          CandidateId = sm.FirstOrDefault().CandidateId,
                                          CompanyId = sm.FirstOrDefault().CompanyId,
                                          IsReceivedCandidate = sm.FirstOrDefault().IsReceivedCandidate,
                                          JobId = sm.FirstOrDefault().JobId,
                                          SenderType = sm.FirstOrDefault().SenderType,
                                          MessageBody = sm.FirstOrDefault().MessageBody,
                                          IsReceivedEmploye = sm.FirstOrDefault().IsReceivedEmploye,
                                          IsDelete = sm.FirstOrDefault().IsDelete,
                                          SendingTime = sm.FirstOrDefault().SendingTime
                                      })
                                  }).Distinct().ToListAsync();

                return data;
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
                var query = await (from m in _sqlServerContext.Message
                                   join c in _sqlServerContext.Candidates on m.CandidateId equals c.CandidateId
                                   join j in _sqlServerContext.Jobs on m.JobId equals j.JobId
                                   join a in _sqlServerContext.AppliedJob on m.CandidateId equals a.CandidateId
                                   where a.JobId == m.JobId && m.CompanyId == companyId && m.IsDelete == false && m.IsReceivedEmploye == false
                                   orderby m.SendingTime descending
                                   select new MessageNotificationViewModel
                                   {
                                       CandidateId = m.CandidateId,
                                       CompanyId = m.CompanyId,
                                       IsReceivedEmploye = m.IsReceivedEmploye,
                                   }).FirstOrDefaultAsync();
                

                return query;
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
                var query = await (from m in _sqlServerContext.Message
                                   join c in _sqlServerContext.Companies on m.CompanyId equals c.CompanyId
                                   join j in _sqlServerContext.Jobs on m.JobId equals j.JobId
                                   join a in _sqlServerContext.AppliedJob on m.CompanyId equals a.CompanyId
                                   where a.JobId == m.JobId && m.CandidateId == candidateId && m.IsDelete == false && a.CandidateId == candidateId && m.IsReceivedCandidate == false
                                   select new MessageNotificationViewModel
                                   {
                                       CandidateId = m.CandidateId,
                                       CompanyId = m.CompanyId,
                                       IsReceivedCandidate = m.IsReceivedCandidate
                                   }).FirstOrDefaultAsync();
                
                return query;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
