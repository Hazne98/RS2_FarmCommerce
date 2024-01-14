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
        public async Task<IEnumerable<Model.Korisnik>> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{id}")]
        public async Task<Model.Korisnik> GetById(int id)
        {
            return await _service.GetById(id);
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