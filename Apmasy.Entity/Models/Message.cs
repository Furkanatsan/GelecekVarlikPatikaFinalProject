using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Apmasy.Entity.Models
{
    public partial class Message : EntityBase
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public bool IsRead { get; set; }
        public DateTime InDateTime { get; set; } = DateTime.Now;
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
    }
}
