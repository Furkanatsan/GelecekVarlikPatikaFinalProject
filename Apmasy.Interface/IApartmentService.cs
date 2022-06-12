using Apmasy.Entity.Dto.DtoApartment;
using Apmasy.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Interface
{
    public interface IApartmentService:IGenericService<Apartment,DtoViewApartment>
    {
    }
}
