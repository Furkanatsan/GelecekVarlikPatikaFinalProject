using Apmasy.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Dal.Abstract
{
    public interface IMessageRepository
    {
        public List<Message> GetDetail();
        public bool InsertMessage(Message newMessage);
    }
}
