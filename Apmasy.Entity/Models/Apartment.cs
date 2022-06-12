using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Apmasy.Entity.Models
{
    public partial class Apartment:EntityBase
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public int ApNo { get; set; }
        public int? ResidentId { get; set; }
        public string ApType { get; set; }
        public bool IsEmpty { get; set; }
        public DateTime InDateTime { get; set; } = DateTime.Now;
        public DateTime? UpDateTime { get; set; }= DateTime.Now;
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User Resident { get; set; }
    }
}
