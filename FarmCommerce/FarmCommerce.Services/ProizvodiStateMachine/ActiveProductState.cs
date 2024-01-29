using AutoMapper;
using FarmCommerce.Model;
using FarmCommerce.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services.ProizvodiStateMachine
{
    public class ActiveProductState : BaseState
    {
        public ActiveProductState(IServiceProvider serviceProvider, Database.Rs2farmCommerceContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        //public override Task<Proizvod> Activate(int id)
        //{
        //    return base.Activate(id);
        //}

        public override async Task<Proizvodi> Hide(int id)
        {
            var set = _context.Set<Proizvod>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Hide");

            return list;
        }
    }
}
