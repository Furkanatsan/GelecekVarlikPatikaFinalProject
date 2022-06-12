using Apmasy.Entity.Dto.DtoMessage;
using Apmasy.Entity.IBase;
using Apmasy.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Interface
{
    public interface IMessageService:IGenericService<Message,DtoViewMessage>
    {
        public IResponse<List<DtoViewMessage>> GetDetail(int receiverId, int senderId);
        public IResponse<bool> InsertMessage(DtoInsertMessage newMessage, bool saveChanges = true);
    }
}
