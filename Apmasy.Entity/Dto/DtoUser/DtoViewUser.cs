using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoUser
{
    public class DtoViewUser : DtoBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public string VehiclePlate { get; set; }
        public int? ApartmentId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
