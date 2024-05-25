using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public interface IFirmaService : ICRUDService<Model.Firma, FirmaSearchObject, FirmaInsertRequest, FirmaUpdateRequest>
    {
    }
}
