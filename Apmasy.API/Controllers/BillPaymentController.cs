using Apmasy.API.Base;
using Apmasy.Entity.Dto.DtoBillPayment;
using Apmasy.Entity.IBase;
using Apmasy.Entity.Models;
using Apmasy.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apmasy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillPaymentController : ApiBaseController<IBillPaymentService, BillPayment, DtoViewBillPayment>
    {
        private readonly IBillPaymentService billPaymentService;
        public BillPaymentController(IBillPaymentService billPaymentService) : base(billPaymentService)
        {
            this.billPaymentService = billPaymentService;
        }

        
        [HttpGet("GetListBillPayment")]
        public IResponse<List<DtoViewBillPayment>> GetListBillPayment(int apartmentId, bool isPaid)
        {
                return billPaymentService.GetListBillPayment(apartmentId,isPaid);
        }




    }
}
