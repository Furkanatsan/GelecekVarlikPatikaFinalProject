using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Dto.DtoApartment
{
    public class DtoViewApartment : DtoBase
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public int ApNo { get; set; }
        public int? ResidentId { get; set; }
        public string ApType { get; set; }
        public bool IsEmpty { get; set; }
    }
}
