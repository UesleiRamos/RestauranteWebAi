using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CedroRestaurante.Dominio.Entities;
using CedroRestaurante.Infra.Contexto;

namespace CedroRestaurante.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurantes")]
    public class RestaurantesController : Controller
    {
        private readonly Context _context;

        public RestaurantesController(Context context)
        {
            _context = context;

            if (_context.Restaurantes.Count() == 0) {
                _context.Restaurantes.Add(new Restaurante { Descricao = "Restaurante_1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            var restaurantes = _context.Restaurantes.ToList();
            return Json(restaurantes);
        }

        [HttpGet("{id}", Name ="GetRestaurante")]
        public ActionResult Get(int id)
        {
            var restaurante = _context.Restaurantes.Find(id);
            if (restaurante == null) {
                return NotFound();

            }
            return Json(restaurante);
        }

        [HttpPost("{Nome}")]
        public ActionResult GetByName(string Nome)
        {
            var restaurante = _context.Restaurantes.SingleOrDefault(w => w.Descricao.Equals(Nome));
            if (restaurante == null)
            {
                return NotFound();
            }
            return Json(restaurante);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Restaurante item)
        {
            var restaurante = _context.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }
            restaurante.Descricao = item.Descricao;
            _context.Restaurantes.Update(restaurante);
            _context.SaveChanges();
            return Json(restaurante);
        }

        [HttpPost]
        public IActionResult Create(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();

            return Json(restaurante);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var restaurante = _context.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(restaurante);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
