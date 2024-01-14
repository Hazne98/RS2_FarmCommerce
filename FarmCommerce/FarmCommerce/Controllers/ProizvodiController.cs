using FarmCommerce.Model;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmCommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : BaseController<Model.Proizvodi, ProizvodSearchObject>
    {
        public ProizvodiController(ILogger<BaseController<Proizvodi, ProizvodSearchObject>> logger, IService<Proizvodi, ProizvodSearchObject> service)
        : base(logger, service)
        { 

        }
    }
}