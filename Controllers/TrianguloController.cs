using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GeometriaAPI.Models;
using GeometriaAPI.Service;

namespace GeometriaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TrianguloController : ControllerBase
    {
        private readonly TrianguloService _service;
        public TrianguloController(TrianguloService service) => _service = service;

        [HttpGet] public IActionResult Get() => Ok(_service.GetAll());
        [HttpGet("{id}")] public IActionResult Get(int id)
            => _service.GetById(id) is Triangulo t ? Ok(t) : NotFound();
        [HttpPost] public IActionResult Post(Triangulo t) => Ok(_service.Create(t));
        [HttpPut("{id}")] public IActionResult Put(int id, Triangulo t)
            => _service.Update(id, t) ? Ok() : NotFound();
        [HttpDelete("{id}")] public IActionResult Delete(int id)
            => _service.Delete(id) ? Ok() : NotFound();
    }
}
