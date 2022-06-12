using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoUser
{
    public class DtoUserLoginRequest:DtoBase
    {
        [Required(ErrorMessage = "Email boş geçilemez.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
