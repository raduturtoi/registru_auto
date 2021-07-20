using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Entities.Owners, ExternalModels.OwnerDTO>();
            CreateMap<ExternalModels.OwnerDTO, Entities.Owners>();

            CreateMap<Entities.Cars, ExternalModels.CarDTO>();
            CreateMap<ExternalModels.CarDTO, Entities.Cars>();

        }
    }
}
