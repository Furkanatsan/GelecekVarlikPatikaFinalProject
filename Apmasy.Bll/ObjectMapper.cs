using Apmasy.Entity.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Bll
{
    //mapper, bll katmanında ObjectMapper olarak çalışıcak.
    internal class ObjectMapper//Sadece bll katmanında kullanılabilir yaptık(Internal).
    {
        //Entity katmanımızda bulunan mappingProfile sınıfını mapperconfiguration da ekledik.
        //lazy yapısı sayesinde proje ayaga kalktığında yok ama ihtiyaç olduğunda oluşacak.
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile<MappingProfile>();

              });
            return config.CreateMapper();
        }
        );
        public static IMapper Mapper => lazy.Value;
    }
}
