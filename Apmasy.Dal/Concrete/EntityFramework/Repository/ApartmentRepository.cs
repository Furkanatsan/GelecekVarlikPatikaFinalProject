using Apmasy.Dal.Abstract;
using Apmasy.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Dal.Concrete.EntityFramework.Repository
{
    public class ApartmentRepository:GenericRepository<Apartment>,IApartmentRepository
    {
        public ApartmentRepository(DbContext context):base(context)
        {

        }
        
    }
}
