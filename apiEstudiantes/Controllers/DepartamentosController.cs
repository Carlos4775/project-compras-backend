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
    [Route("[controller]")]
    public class DepartamentosController : Controller
    {
        private readonly AppDbContext context;
        public DepartamentosController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<DepartamentosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Departamentos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.Departamentos.FirstOrDefault(g => g.Id_Departamento == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public ActionResult Post([FromBody] Departamentos_Bd gestor)
        {
            try
            {
                context.Departamentos.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.Id_Departamento }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Departamentos_Bd gestor)
        {
            try
            {
                if (gestor.Id_Departamento == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id_Departamento }, gestor);

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

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.Departamentos.FirstOrDefault(g => g.Id_Departamento == id);
                if (gestor != null)
                {
                    context.Departamentos.Remove(gestor);
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
