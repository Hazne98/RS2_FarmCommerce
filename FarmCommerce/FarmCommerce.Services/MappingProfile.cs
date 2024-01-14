﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Model.Requests.KorisnikInsertRequest, Database.Korisnik>();
            CreateMap<Model.Requests.KorisnikUpdateRequest, Database.Korisnik>();

            CreateMap<Database.Proizvod, Model.Proizvodi>();
        }
    }

    //public UserProfile()
    //{
    //CreateMap<User, UserViewModel>();
    //}
}
