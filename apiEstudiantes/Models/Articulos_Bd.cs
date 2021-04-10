using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiCompras.Models
{
    public class Articulos_Bd
    {
        [Key]
        public int Id_Articulo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Existencia { get; set; }
        public bool Estado { get; set; }
        public int Id_Unidad_Medida { get; set; }
        public Unidades_Medida_Bd Unidad_Medida { get; set; }
        public List<Orden_Compra_Bd> Ordenes_Compras { get; set; }
    }
}
