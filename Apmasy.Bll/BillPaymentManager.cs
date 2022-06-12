using Apmasy.Dal.Abstract;
using Apmasy.Entity.Dto.DtoBillPayment;
using Apmasy.Entity.IBase;
using Apmasy.Entity.Models;
using Apmasy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Apmasy.Entity.Base;
using Microsoft.AspNetCore.Http;

namespace Apmasy.Bll
{
    public class BillPaymentManager : GenericManager<BillPayment, DtoViewBillPayment>, IBillPaymentService
    {
        private readonly IBillPaymentRepository billPaymentRepository;
        public BillPaymentManager(IServiceProvider service) : base(service)
        {
            billPaymentRepository = service.GetService<IBillPaymentRepository>();
        }
        //ıbillpaymentrepo
        public IResponse<List<DtoViewBillPayment>> GetListBillPayment(int apartmentId, bool isPaid)
        {
            var data = billPaymentRepository.GetListBillPayment();
            //ödenmiş faturalar
            if (isPaid)
            {
                data = data.Where(b => b.IsPaid).ToList();
            }
           
            //Apatmana Ait faturalar
            if (apartmentId >0)
            {
                data=data.Where(b => b.ApartmentId == apartmentId).ToList();
            }
         

            if (!data.Any())
            {
                return new Response<List<DtoViewBillPayment>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "fatura bulunamadı.",
                    Data = null
                };
            }

            var resultList = ObjectMapper.Mapper.Map<List<DtoViewBillPayment>>(data.OrderBy(p => p.Id));

            return new Response<List<DtoViewBillPayment>>
            {
                StatusCode=StatusCodes.Status200OK,
                Message="İşlem Başarılı",
                Data=resultList
            };
        }

        public IResponse<DtoViewBillPayment> UpdateBillPayment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
