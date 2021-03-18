using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiCompras.Models;
using apiCompras.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiCompras.Controllers
{
    [Route("api/[controller]")]
    public class ArticulosController : Controller
    {
        private readonly AppDbContext context;
        public ArticulosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ArticulosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Articulos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ArticulosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.Articulos.FirstOrDefault(g => g.Id_Articulo == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ArticulosController>
        [HttpPost]
        public ActionResult Post([FromBody]Articulos_Bd gestor)
        {
            try
            {
                context.Articulos.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.Id_Articulo }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ArticulosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Articulos_Bd gestor)
        {
            try
            {
                if (gestor.Id_Articulo == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id_Articulo }, gestor);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ArticulosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.Articulos.FirstOrDefault(g => g.Id_Articulo == id);
                if (gestor != null)
                {
                    context.Articulos.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
