using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoBillPayment
{
    public class DtoViewBillPayment : DtoBase
    {
        public int Id { get; set; }
        public string BillType { get; set; }
        public decimal Price { get; set; }
        public int ApartmentId { get; set; }
        public bool IsPaid { get; set; }
        public int PayerId { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

    }
}
