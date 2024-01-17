using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public interface IProizvodiService : ICRUDService<Model.Proizvodi, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        Task<Proizvodi> Activate(int id);
        Task<Proizvodi> Hide(int id);
        Task<List<string>> AllowedActions(int id);
    }
}
