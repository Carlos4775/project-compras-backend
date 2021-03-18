using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiCompras.Context;
using apiCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiCompras.Controllers
{
    [Route("api/[controller]")]
    public class ProveedoresController : Controller
    {
        private readonly AppDbContext context;
        public ProveedoresController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ProveedoresController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Proveedores.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<ProveedoresController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.Proveedores.FirstOrDefault(g => g.Id_Proveedores == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProveedoresController>
        [HttpPost]
        public ActionResult Post([FromBody] Proveedores_Bd gestor)
        {
            try
            {
                context.Proveedores.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.Id_Proveedores }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProveedoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Proveedores_Bd gestor)
        {
            try
            {
                if (gestor.Id_Proveedores == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id_Proveedores }, gestor);
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

        // DELETE api/<ProveedoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.Proveedores.FirstOrDefault(g => g.Id_Proveedores == id);
                if (gestor != null)
                {
                    context.Proveedores.Remove(gestor);
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
