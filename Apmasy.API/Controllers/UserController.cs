using Apmasy.API.Base;
using Apmasy.Bll.Token;
using Apmasy.Entity.Base;
using Apmasy.Entity.Dto.DtoUser;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly TokenManager tokenManager;
        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        public IResponse<DtoUserLoginResp> Login(DtoUserLoginRequest loginRequest)
        {
            try
            {
                return userService.Login(loginRequest);
                
            }
            catch (Exception ex)
            {
                return new Response<DtoUserLoginResp>
                {
                    StatusCode=StatusCodes.Status500InternalServerError,
                    Message="işlem başarısız"+ex.Message,
                    Data=null
                    
                };
                
            }
        }


        [HttpPost("InsertUser")]
        public IResponse<DtoViewUser> InsertUser(DtoInsertUser insertUser) 
        {
            return userService.InsertUser(insertUser);
            
        }

        [HttpPut("UpdateUser")]
        public IResponse<DtoViewUser> UpdateUser(DtoViewUser updateUser)
        {
            return userService.UpdateUser(updateUser);

        }

        [HttpGet("GetByIdUser")]
        public IResponse<DtoViewUser> GetById(int id)
        {
            try
            {
                return userService.GetByIdUser(id);
            }
            catch (Exception)
            {
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız",
                    Data = null
                };
            }
        }

        [HttpDelete("Delete")]
        public IResponse<bool> Delete(int id)
        {
            try
            {
                return userService.DeleteUser(id);
            }
            catch (Exception)
            {

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız",
                    Data = false

                };

            }
        }

        [HttpGet("GetList")]
        public IResponse<List<DtoViewUser>> GetList()
        {
            try
            {
                return userService.GetListUser();
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

    }
}
