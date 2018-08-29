using CedroRestaurante.Dominio.Entities;
using CedroRestaurante.Infra.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CedroRestaurante.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PratosController : Controller
    {
        private readonly Context _context;

        public PratosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var pratos = _context.Pratos.ToList();
            return Json(pratos);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var prato = _context.Pratos.Include(i => i.Restaurante).AsNoTracking().SingleOrDefault(w => w.Id == id);


            return Json(prato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Prato item)
        {
            var prato = _context.Pratos.Find(id);
            if (prato == null)
            {
                return NotFound();
            }

            prato.Descricao = item.Descricao;
            prato.RestauranteId = item.RestauranteId;
            _context.Pratos.Update(prato);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Prato prato)
        {
            _context.Pratos.Add(prato);
            _context.SaveChanges();
            return CreatedAtRoute("Getprato", new { id = prato.Id }, prato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prato = _context.Pratos.Find(id);
            if (prato == null)
            {
                return NotFound();
            }
            _context.Pratos.Remove(prato);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
