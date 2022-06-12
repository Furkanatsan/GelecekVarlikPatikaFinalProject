using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoApartment
{
    public class DtoInsertApartment:DtoBase
    {
        [Required(ErrorMessage = "Boş Geçilemez.")]
        [RegularExpression("^([A-Z]{1})$", ErrorMessage = "A ile Z arasında olmalı")]
        public string Block { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez.")]
        [Range(1, 100, ErrorMessage = "Daire no 1 ile 100 arasında olmalı")]
        public int ApNo { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Daire Sakini id si 1 den küçük olamaz ")]
        public int? ResidentId { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez.")]
        [RegularExpression("^([0-6]{1})[+]([1-2]{1})$", ErrorMessage = "Böyle bir daire tipi yok")]
        public string ApType { get; set; }
        public bool IsEmpty { get; set; }
    }
}
