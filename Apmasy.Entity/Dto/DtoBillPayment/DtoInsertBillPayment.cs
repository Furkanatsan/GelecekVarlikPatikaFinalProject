using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoBillPayment
{
    public class DtoInsertBillPayment : DtoBase
    {
        [Required(ErrorMessage = "Boş Geçilemez.")]
        public string BillType { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez.")]
        public int ApartmentId { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez.")]
        public int PayerId { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez.")]
        public DateTime PaymentDueDate { get; set; }
    }
}
