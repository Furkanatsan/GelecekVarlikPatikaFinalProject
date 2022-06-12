using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Apmasy.Entity.Models
{
    public partial class BillPayment : EntityBase
    {
        public int Id { get; set; }
        public string BillType { get; set; }
        public decimal Price { get; set; }
        public int ApartmentId { get; set; }
        public bool IsPaid { get; set; }
        public int PayerId { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime InDateTime { get; set; } = DateTime.Now;
        public DateTime? UpDateTime { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; }

        public virtual User Payer { get; set; }
    }
}
