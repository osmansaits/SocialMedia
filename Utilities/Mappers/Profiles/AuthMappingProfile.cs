using AutoMapper;
using Dto.Request;
using Dto.Response;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Utilities.Mappers.Profiles
{
    public class AuthMappingProfile:Profile
    {
        public AuthMappingProfile()
        {
            //Dest hedef Src kaynak belirtir.
            CreateMap<Auth, AuthResponseDto>()
                .ForMember(dest=>dest.email, opt=>opt.MapFrom(src=> src.email))
                .ForMember(dest=>dest.role, opt=> opt.MapFrom(src=> src.role));
            CreateMap<AuthAddRequestDto, Auth>()
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password));
        }
    }
}
