using Apmasy.Entity.Dto.DtoApartment;
using Apmasy.Entity.Dto.DtoBillPayment;
using Apmasy.Entity.Dto.DtoMessage;
using Apmasy.Entity.Dto.DtoUser;
using Apmasy.Entity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Entity.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DtoInsertUser>().ReverseMap();
            CreateMap<User, DtoViewUser>().ReverseMap();
            CreateMap<User, DtoUserLoginRequest>().ReverseMap();
            CreateMap<User, DtoUserLoginResp>().ReverseMap();
            CreateMap<User, DtoLogin>().ReverseMap();
            CreateMap<Apartment, DtoInsertApartment>().ReverseMap();
            CreateMap<Apartment, DtoViewApartment>().ReverseMap();
            CreateMap<Message, DtoInsertMessage>().ReverseMap();
            CreateMap<Message, DtoViewMessage>().ReverseMap();
            CreateMap<BillPayment, DtoInsertBillPayment>().ReverseMap();
            CreateMap<BillPayment, DtoViewBillPayment>().ReverseMap();

        }

    }
}
