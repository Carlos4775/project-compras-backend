using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace apiCompras.Models
{
    public class Orden_Compra_Bd
    {
        [Key]
        public int No_Orden { get; set; }
        public DateTime Fecha_Orden { get; set; }
        public bool Estado { get; set; }
        public int Id_Articulo { get; set; }
        public int Cantidad { get; set; }
        public int Id_Unidad_Medida { get; set; }
        public decimal Costo_Unitario { get; set; }
        public int Id_Proveedores { get; set; }
    }
}
