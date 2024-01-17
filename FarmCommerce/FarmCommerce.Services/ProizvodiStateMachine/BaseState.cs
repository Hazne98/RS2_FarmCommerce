using AutoMapper;
using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services.ProizvodiStateMachine
{
    public class BaseState
    {
        public IMapper _mapper { get; set; }

        protected Rs2farmCommerceContext _context;

        public IServiceProvider _serviceProvider { get; set; }
        public BaseState(IServiceProvider serviceProvider, Rs2farmCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public virtual Task<Model.Proizvodi> Insert(ProizvodInsertRequest request)
        {
            throw new UserException("Not allowed");
        }
        public virtual Task<Model.Proizvodi> Update(int id, ProizvodUpdateRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Proizvodi> Activate(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Proizvodi> Hide(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Proizvodi> Delete(int id)
        {
            throw new UserException("Not allowed");
        }

        public BaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return _serviceProvider.GetService<InitialProductState>();
                    break;
                case "draft":
                    return _serviceProvider.GetService<DraftProductState>();
                    break;
                case "active":
                    return _serviceProvider.GetService<ActiveProductState>();
                    break;

                default:
                    throw new Exception("Not allowed");
            }
        }

        public virtual async Task<List<string>> AllowedActions()
        {
            return new List<string>();
        }
    }
}
