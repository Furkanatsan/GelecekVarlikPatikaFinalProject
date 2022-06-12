using Apmasy.Dal.Abstract;
using Apmasy.Entity.Dto.DtoMessage;
using Apmasy.Entity.IBase;
using Apmasy.Entity.Models;
using Apmasy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Apmasy.Entity.Base;
using Microsoft.AspNetCore.Http;

namespace Apmasy.Bll
{
    public class MessageManager : GenericManager<Message, DtoViewMessage>, IMessageService
    {
        private readonly IMessageRepository messageRepository;
        public MessageManager(IServiceProvider service) : base(service)
        {
            messageRepository = service.GetService<IMessageRepository>();
        }
        public IResponse<List<DtoViewMessage>> GetDetail(int receiverId, int senderId)
        {
            try
            {
                
                var data = messageRepository.GetDetail();                                            //iki mesajıda getirmek istediğimiz için sender-reciever,receiver-sender  
                var result = data.Where(x => (x.SenderId == senderId && x.ReceiverId == receiverId) || (x.ReceiverId == senderId && x.SenderId == receiverId)).OrderBy(y => y.InDateTime);
                var rr = result.Select(z => ObjectMapper.Mapper.Map<DtoViewMessage>(z)).ToList();
                return new Response<List<DtoViewMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "İşlem Başarılı",
                    Data = rr
                };
            }
            catch (Exception)
            {

                return new Response<List<DtoViewMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "İşlem Başarısız",
                    Data = null
                };
            }
        }

        public IResponse<bool> InsertMessage(DtoInsertMessage newMessage, bool saveChanges = true)
        {
            try
            {
                var result = messageRepository.InsertMessage( ObjectMapper.Mapper.Map<Message>(newMessage));
                if (saveChanges)
                {
                    Save();
                }
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "İşlem Başarılı",
                    Data = true
                };
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = false
                };

            }
        }
    }
}
