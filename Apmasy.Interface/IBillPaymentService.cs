using Apmasy.Entity.Dto.DtoBillPayment;
using Apmasy.Entity.IBase;
using Apmasy.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Interface
{
    public interface IBillPaymentService:IGenericService<BillPayment,DtoViewBillPayment>
    {
        public IResponse<List<DtoViewBillPayment>> GetListBillPayment( int apartmentId, bool isPaid);
        public IResponse<DtoViewBillPayment> UpdateBillPayment(int id);
    }
}
