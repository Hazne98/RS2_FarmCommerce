using AutoMapper;
using FarmCommerce.Model;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public class ProizvodiService : BaseService<Model.Proizvodi, Database.Proizvod, ProizvodSearchObject>, IProizvodiService
    {
        public ProizvodiService(Rs2farmCommerceContext context, IMapper mapper)
            : base(context, mapper) 
        {

        }
    }
}
