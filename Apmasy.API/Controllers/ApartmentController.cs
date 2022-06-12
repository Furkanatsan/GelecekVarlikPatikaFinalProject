using Apmasy.API.Base;
using Apmasy.Entity.Dto.DtoApartment;
using Apmasy.Entity.Models;
using Apmasy.Interface;
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
    public class ApartmentController : ApiBaseController<IApartmentService, Apartment, DtoViewApartment>
    {
        private readonly IApartmentService apartmentService;
        public ApartmentController(IApartmentService apartmentService) : base(apartmentService)
        {
            this.apartmentService = apartmentService;
        }
    }
}
