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
    [Route("[controller]")]
    public class UnidadesMedidasController : Controller
    {
        private readonly AppDbContext context;
        public UnidadesMedidasController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<UnidadesMedidasController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Unidades_Medidas.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<UnidadesMedidasController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.Unidades_Medidas.FirstOrDefault(g => g.Id_Unidad_Medida == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UnidadesMedidasController>
        [HttpPost]
        public ActionResult Post([FromBody] Unidades_Medida_Bd gestor)
        {
            try
            {
                context.Unidades_Medidas.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.Id_Unidad_Medida }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UnidadesMedidasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Unidades_Medida_Bd gestor)
        {
            try
            {
                if (gestor.Id_Unidad_Medida == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id_Unidad_Medida }, gestor);

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

        // DELETE api/<UnidadesMedidasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.Unidades_Medidas.FirstOrDefault(g => g.Id_Unidad_Medida == id);
                if (gestor != null)
                {
                    context.Unidades_Medidas.Remove(gestor);
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
