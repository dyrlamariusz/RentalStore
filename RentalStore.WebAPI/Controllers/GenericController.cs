using Microsoft.AspNetCore.Mvc;
using RentalStore.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly GenericService<TEntity> _service;

        public GenericController(GenericService<TEntity> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> GetAll()
        {
            var entities = _service.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> Get(int id)
        {
            var entity = _service.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<TEntity> Post([FromBody] TEntity entity)
        {
            _service.Insert(entity);
            return CreatedAtAction("Get", new { id = ((dynamic)entity).Id }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TEntity entity)
        {
            if (id != ((dynamic)entity).Id)
            {
                return BadRequest();
            }
            _service.Update(entity); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _service.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            _service.Delete(entity);
            return NoContent();
        }
    }
}