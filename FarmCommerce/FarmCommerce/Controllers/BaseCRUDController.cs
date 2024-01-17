using FarmCommerce.Model;
using FarmCommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmCommerce.Controllers
{
    //API CONTORLLER se nalazi direkt na odredjenom kontroleru
    [Route("[controller]")]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class
    {
        protected new readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;

        public BaseCRUDController(ILogger<BaseController<T, TSearch>> logger, ICRUDService<T, TSearch, TInsert, TUpdate> service)
            : base(logger, service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<T> Insert([FromBody] TInsert insert)
        {
            return await _service.Insert(insert);
        }

        [HttpPut("{id}")]
        public virtual async Task<T> Update(int id,[FromBody] TUpdate update)
        {
            return await _service.Update(id, update);
        }
    }
}
