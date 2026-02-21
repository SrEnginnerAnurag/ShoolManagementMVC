using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using model.StdModel;

namespace BussinessLogic.StudentMapperProfile
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Studentmodel, StudentDto>()
                .ForMember(dest => dest.stid, act => act.MapFrom(src => src.id))
                .ForMember(dest => dest.stname, act => act.MapFrom(src => src.name))
                .ForMember(dest => dest.stage, act => act.MapFrom(src => src.age))
                .ForMember(dest => dest.staddress, act => act.MapFrom(src => src.address)).ReverseMap();
        }
    }
}
