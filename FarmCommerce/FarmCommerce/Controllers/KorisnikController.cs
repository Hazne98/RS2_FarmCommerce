using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmCommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : ControllerBase
    {

        private readonly IKorisniciService _service;

        public KorisnikController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet()]
        public IEnumerable<Model.Korisnik> Get()
        {
            return _service.Get();
        }

        [HttpPost]
        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut()]
        public Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}