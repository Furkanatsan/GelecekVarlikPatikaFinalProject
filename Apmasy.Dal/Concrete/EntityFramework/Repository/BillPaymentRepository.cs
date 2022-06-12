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
    public class BillPaymentRepository:GenericRepository<BillPayment>,IBillPaymentRepository
    {
        public BillPaymentRepository(DbContext context):base(context)
        {

        }

        public List<BillPayment> GetListBillPayment()
        {
            return dbset.ToList();
        }

        public bool UpdateBillPayment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
