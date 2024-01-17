using AutoMapper;
using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services.ProizvodiStateMachine
{
    public class InitialProductState : BaseState
    {
        public InitialProductState(IServiceProvider serviceProvider, Database.Rs2farmCommerceContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override async Task<Proizvodi> Insert(ProizvodInsertRequest request)
        {
            //TODO: EF CALL
            var set = _context.Set<Database.Proizvod>();

            Database.Proizvod entity = _mapper.Map<Database.Proizvod>(request);

            entity.StateMachine = "draft";

            set.Add(entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Insert");

            return list;
        }
    }
}
