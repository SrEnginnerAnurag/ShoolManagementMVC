using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolResitrationDtos;
using SchoolResitrationModel;

namespace SchoolManagementBissuness.SchoolProfile
{
    public class SchoolManagementProfile:Profile
    {
        public SchoolManagementProfile()
        {
            CreateMap<SchoolManagementModel , SchoolManagementModelDTO>().ReverseMap();

            /*
          isko jab hm program.cs me Configure karenge to builder.Services.AddAutoMapper(typeof(SchoolManagementProfile));
            
            Agar aap AddAutoMapper(typeof(SchoolManagementProfile)) ka use kar rahe hain, iska matlab hai ki aapne SchoolManagementProfile mein apni sari mappings define ki hain. Isliye jab aap ye likhte hain, toh AutoMapper uss specific profile ko dekh kar mappings apply karta hai.

           Agar aap AddAutoMapper(typeof(Program)) ka use karte hain, toh AutoMapper ko kisi specific profile ki information nahi milti, aur wo default behavior follow karta hai jo kabhi-kabhi mappings detect nahi kar pata.
             */

        }
    }
}
