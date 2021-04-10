using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiCompras.Models
{
    public class Unidades_Medida_Bd
    {
        [Key]
        public int Id_Unidad_Medida { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public List<Articulos_Bd> Articulos { get; set; }
        public List<Orden_Compra_Bd> Ordenes_Compras { get; set; }
    }
}
