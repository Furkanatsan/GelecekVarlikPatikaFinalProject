using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoMessage
{
    public class DtoViewMessage : DtoBase
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public bool IsRead { get; set; }
        public DateTime InDateTime { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
