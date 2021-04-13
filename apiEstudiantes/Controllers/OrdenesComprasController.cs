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
    //[ApiController]
    public class OrdenesComprasController : Controller
    {
        private readonly AppDbContext context;
        public OrdenesComprasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<OrdenesComprasController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Orden_Compra.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<OrdenesComprasController>/2021-01-25/2021-02-25
        [HttpGet("{startDate}/{endDate}")]
        public ActionResult GetPurchaseOrders(DateTime startDate, DateTime endDate)
        {
            try
            {
                //var gestor = context.Orden_Compra.Where(o => o.Fecha_Orden >= startDate && o.Fecha_Orden <= endDate && o.Id_Asiento == null).ToList();
                var gestor = context.Orden_Compra.Select(x => new { numero_orden = x.No_Orden,
                    fecha = x.Fecha_Orden,
                    id_asiento = x.Id_Asiento,
                    monto_orden = x.Monto
                }).Where(o => o.fecha >= startDate && o.fecha <= endDate && o.id_asiento == null).ToList();

                var monto = context.Orden_Compra.Where(o => o.Fecha_Orden >= startDate && o.Fecha_Orden <= endDate && o.Id_Asiento == null).Sum(x => x.Monto);

                return new JsonResult(new { ordenes_compras = gestor, monto_total = monto});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // GET api/<OrdenesComprasController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.Orden_Compra.FirstOrDefault(g => g.Id_Orden_Compra == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<OrdenesComprasController>
        [HttpPost]
        public ActionResult Post([FromBody] Orden_Compra_Bd gestor)
        {
            try
            {
                context.Orden_Compra.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.Id_Orden_Compra }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrdenesComprasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Orden_Compra_Bd gestor)
        {
            try
            {
                if (gestor.Id_Orden_Compra == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id_Orden_Compra }, gestor);

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

        // DELETE api/<OrdenesComprasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.Orden_Compra.FirstOrDefault(g => g.Id_Orden_Compra == id);
                if (gestor != null)
                {
                    context.Orden_Compra.Remove(gestor);
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
