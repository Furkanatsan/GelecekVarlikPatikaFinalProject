using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoUser
{
    public class DtoInsertUser : DtoBase
    {
        [Required(ErrorMessage = "Boş Geçilemez.")]
        [StringLength(50, ErrorMessage = "50 Karakterden Büyük olamaz")]
        public string FullName { get; set; }
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez.")]
        [StringLength(50, ErrorMessage = "150 Karakterden Büyük olamaz.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Boş Geçilemez.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Hatalı giriş yaptınız.")]
        public string IdentificationNumber { get; set; }

        [RegularExpression("^([0-9]{2})([A-Z]{1,3})([0-9]{2,4})$", ErrorMessage = "Hatalı giriş yaptınız.")]
        public string VehiclePlate { get; set; }
        public int? ApartmentId { get; set; }
        [Required(ErrorMessage ="Boş Geçilemez.")]
        public bool IsAdmin { get; set; }
    }
}
