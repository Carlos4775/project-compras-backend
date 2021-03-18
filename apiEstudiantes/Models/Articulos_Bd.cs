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
        public string Unidad_Medida { get; set; }
        public int Existencia { get; set; }
        public bool Estado { get; set; }
    }
}
