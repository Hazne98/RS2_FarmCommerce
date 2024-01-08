using FarmCommerce.Model;
using FarmCommerce.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public class ProizvodiService : IProizvodiService
    {
        Rs2farmCommerceContext _context;
        public ProizvodiService(Rs2farmCommerceContext context) {
            _context = context;
        }
        List<Model.Proizvodi> proizvodis = new List<Model.Proizvodi>()
        { 
            new Proizvodi()
            {
                ProizvodId = 1,
                Naziv = "Laptop"
            }
        };
        public IList<Model.Proizvodi> Get()
        {
            var list = _context.Proizvods.ToList();
            return proizvodis;
        }
    }
}
