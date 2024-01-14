using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public interface IKorisniciService : IService<Model.Korisnik, KorisnikSearchObject>
    {
        Task<List<Model.Korisnik>> Get();
        Model.Korisnik Insert(KorisnikInsertRequest request);
        Model.Korisnik Update(int id, KorisnikUpdateRequest request);
    }
}
