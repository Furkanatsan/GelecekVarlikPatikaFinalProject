using Apmasy.Dal.Abstract;
using Apmasy.Entity.Dto.DtoMessage;
using Apmasy.Entity.Dto.DtoUser;
using Apmasy.Entity.IBase;
using Apmasy.Entity.Models;
using Apmasy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Apmasy.Entity.Base;
using Microsoft.AspNetCore.Http;
using Apmasy.Bll.Token;
using Microsoft.Extensions.Configuration;

namespace Apmasy.Bll
{
    public class UserManager : GenericManager<User, DtoViewUser>, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IGenericRepository<Apartment> apartmentRepo;
        private IConfiguration configuration;
        public UserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            apartmentRepo = service.GetService<IGenericRepository<Apartment>>();
            this.configuration = configuration;
        }

        public IResponse<bool> DeleteUser(int id, bool saveChanges = true)
        {
            try
            {
                userRepository.DeleteUser(id);
                if (saveChanges)
                {
                    Save();
                }

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Kullanıcı Silindi.",
                    Data = true
                };
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = false
                };


            }
        }

        public IResponse<DtoViewUser> GetByIdUser(int id)
        {
            try
            {
                var result = ObjectMapper.Mapper.Map<DtoViewUser>(userRepository.GetByIdUser(id));

                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "İşlem Başarılı",
                    Data = result
                };
            }
            catch (Exception)
            {
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = null
                };

            }
        }

        public IResponse<List<DtoViewUser>> GetListUser()
        {
            try
            {
                var list = userRepository.GetListUser();
                var result = list.Select(x => ObjectMapper.Mapper.Map<DtoViewUser>(x)).ToList();
                return new Response<List<DtoViewUser>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "İşlem Başarılı",
                    Data = result
                };


            }
            catch (Exception)
            {

                return new Response<List<DtoViewUser>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = null
                };
            }
        }

        public IResponse<DtoViewUser> InsertUser(DtoInsertUser insertUser, bool saveChanges = true)
        {
            try
            {
                var result = userRepository.InsertUser(ObjectMapper.Mapper.Map<User>(insertUser));
               
                    //repository.Insert(ObjectMapper.Mapper.Map<T>(item));//DTO yu T ye dönüştürüp ekleme yapıyoruz.
                if (saveChanges)
                {
                    result.InDateTime = DateTime.Now;
                    result.IsActive = true;
                    result.IsDeleted = false;
                    result.Password = Extensions.Extension.GeneratePassword(8);
                    Save();
                }
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Kullanıcı Ekleme İşlemi Başarılı.",
                    Data = ObjectMapper.Mapper.Map<DtoViewUser>(result)
                };
            }
            catch (Exception)
            {

                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = null
                };
            }

        }


        public IResponse<DtoUserLoginResp> Login(DtoUserLoginRequest loginUser)
        {
            var user = userRepository.Login(ObjectMapper.Mapper.Map<User>(loginUser));
            if (user !=null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLogin>(user);
                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);
                
                var userToken = new DtoUserLoginResp()
                {
                    DtoLogin=dtoUser,
                    AccessToken=token
                };

                return new Response<DtoUserLoginResp>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "İşlem başarılı.",
                    Data=userToken
                    
                };


            }
            else
            {
                return new Response<DtoUserLoginResp>
                {
                    Message = "Email veya parola yanlış."
                };
            }
        }

        public IResponse<DtoViewUser> UpdateUser(DtoViewUser updateUser, bool saveChanges = true)
        {
            try
            {
                var result = userRepository.UpdateUser(ObjectMapper.Mapper.Map<User>(updateUser));
                if (saveChanges)
                {
                    Save();
                }
                if (result is null)
                {
                    return new Response<DtoViewUser>
                    {
                        Message = "Kullanıcı bulunamadı"
                    };
                }
                if (result.ApartmentId is not null && updateUser.ApartmentId == null)
                {
                    var apartment = apartmentRepo.GetById((int)result.ApartmentId);
                    apartment.IsEmpty = true;
                    apartment.ResidentId = null;
                }

                result.UpDateTime = DateTime.Now;
                
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "İşlem Başarılı.",
                    Data = ObjectMapper.Mapper.Map<DtoViewUser>(result)
                };
            }
            catch 
            {

                throw;
            }
            
        }
    }
}
