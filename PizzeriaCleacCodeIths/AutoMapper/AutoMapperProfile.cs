using AutoMapper;
using PizzeriaCleacCodeIths.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<string[], PlacedPizzaOrder>();
            });
        }
 
    }
}
