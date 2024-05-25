using AutoMapper;
using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Model.SearchRequests;
using FarmCommerce.Services.Database;
using FarmCommerce.Services.ProizvodiStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FarmCommerce.Services
{
    public class FirmaService : BaseCRUDService<Model.Firma, Database.Firma, FirmaSearchObject, FirmaInsertRequest, FirmaUpdateRequest>, IFirmaService
    {
        public BaseState _baseState { get; set; }
        public FirmaService(BaseState baseState, Rs2farmCommerceContext context, IMapper mapper)
            : base(context, mapper)
        {
            _baseState = baseState;
        }

        public override IQueryable<Database.Firma> AddFilter(IQueryable<Database.Firma> query, FirmaSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.Naziv) || x.Naziv.Contains(search.Naziv));
            }

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv == search.Naziv);
            }

            return filteredQuery;
        }
    }
}

