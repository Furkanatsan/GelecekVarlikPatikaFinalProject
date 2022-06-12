using Apmasy.Dal.Abstract;
using Apmasy.Entity.Dto.DtoApartment;
using Apmasy.Entity.Models;
using Apmasy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace Apmasy.Bll
{
    public class ApartmentManager:GenericManager<Apartment,DtoViewApartment>,IApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;
        public ApartmentManager(IServiceProvider service) : base(service)
        {
            apartmentRepository = service.GetService<IApartmentRepository>();
        }
    }
}
