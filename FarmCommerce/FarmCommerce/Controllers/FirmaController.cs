using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Model.SearchRequests;
using FarmCommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FarmCommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirmaController : BaseCRUDController<Model.Firma, FirmaSearchObject, FirmaInsertRequest, FirmaUpdateRequest>
    {
        public FirmaController(ILogger<BaseController<Model.Firma, FirmaSearchObject>> logger, IFirmaService service)
            : base(logger, service)
        {
        }

        [Authorize(Roles = "Administrator")]
        public override Task<Model.Firma> Insert([FromBody] FirmaInsertRequest insert)
        {
            return base.Insert(insert);
        }
    }
}