using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiCompras.Models
{
    public class Proveedores_Bd
    {
        [Key]
        public int Id_Proveedor { get; set; }
        public string Cedula_RNC { get; set; }
        public string Nombre_Comercial { get; set; }
        public bool Estado { get; set; }
        public List<Orden_Compra_Bd> Ordenes_Compras { get; set; }
    }
}
