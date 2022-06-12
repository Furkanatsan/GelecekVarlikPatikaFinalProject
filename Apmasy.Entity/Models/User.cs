using Apmasy.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Apmasy.Entity.Models
{
    public partial class User : EntityBase
    {
        public User()
        {
            Apartments = new HashSet<Apartment>();
            BillPayments = new HashSet<BillPayment>();
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string IdentificationNumber { get; set; }
        public string VehiclePlate { get; set; }
        public int? ApartmentId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime InDateTime { get; set; } = DateTime.Now;
        public DateTime? UpDateTime { get; set; } 
        public bool IsAdmin { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<BillPayment> BillPayments { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
    }
}
