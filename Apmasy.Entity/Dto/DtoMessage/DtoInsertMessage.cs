using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoMessage
{
    public class DtoInsertMessage : DtoBase
    {
        [Required(ErrorMessage = "Boş Geçilemez.")]
        [StringLength(250, ErrorMessage = "250 karakterrden daha uzun mesaj atamazsınız.")]
        public string MessageContent { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez.")]
        public int SenderId { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez.")]
        public int ReceiverId { get; set; }
    }
}
