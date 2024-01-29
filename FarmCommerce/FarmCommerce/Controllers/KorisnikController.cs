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
    public class KorisnikController : BaseCRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        public KorisnikController(ILogger<BaseController<Model.Korisnik, KorisnikSearchObject>> logger, IKorisniciService service)
            : base(logger, service)
        {
        }

        [Authorize(Roles = "Administrator")]
        public override Task<Model.Korisnik> Insert([FromBody] KorisnikInsertRequest insert)
        {
            return base.Insert(insert);
        }
    }
}