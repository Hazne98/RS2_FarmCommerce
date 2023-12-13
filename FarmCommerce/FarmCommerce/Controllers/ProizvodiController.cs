using FarmCommerce.Model;
using FarmCommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmCommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : ControllerBase
    {
      
        private readonly IProizvodiService _proizvodiService;

        public ProizvodiController(IProizvodiService proizvodiService)
        {
            _proizvodiService = proizvodiService;
        }

        [HttpGet()]
        public IEnumerable<Proizvodi> Get()
        {
            return _proizvodiService.Get();
        }
    }
}