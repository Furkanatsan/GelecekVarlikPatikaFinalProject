﻿using Apmasy.Entity.Base;
using Apmasy.Entity.IBase;
using Apmasy.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apmasy.API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ApiBaseController<TService,T,TDto> : ControllerBase where TService:IGenericService<T,TDto> where T:EntityBase where TDto:DtoBase
    {
        private readonly TService service;

        public ApiBaseController(TService service)
        {
            this.service = service;
        }

        [HttpGet("GetById")]
        public IResponse<TDto> GetById(int id)
        {
            try
            {
                return service.GetById(id);
            }
            catch (Exception )
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız",
                    Data = null
                };
            }
        }

        
        [HttpPost("Insert")]
        public IResponse<TDto> Insert(TDto entity)
        {
            try
            {
                return service.Insert(entity);
            }
            catch (Exception )
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = null
                };
            }
        }


        [HttpPut("Update")]
        public IResponse<TDto> Update(TDto entity)
        {
            try
            {
                return service.Update(entity);
            }
            catch (Exception )
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = null
                };
            }
        }

        [HttpGet("GetList")]
        public IResponse<List<TDto>> GetList()
        {
            try
            {
                return service.GetList();
            }
            catch (Exception )
            {
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = null
                };
            }
        }


        [HttpDelete("Delete")]
        public IResponse<bool> Delete(int id)
        {
            try
            {
                return service.Delete(id);
            }
            catch (Exception)
            {

                return new Response<bool>
                {
                   StatusCode=StatusCodes.Status500InternalServerError,
                   Message="İşlem Başarısız",
                   Data=false

                };
                    
            }
        }


    }
}
