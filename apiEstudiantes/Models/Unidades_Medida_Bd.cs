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
    }
}
