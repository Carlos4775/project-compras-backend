using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiCompras.Models
{
    public class Asientos_Contables_Bd
    {
        [Key]
        public int Id_Asiento { get; set; }
        public string Descripcion { get; set; }
        public int Id_Auxiliar { get; set; }
        public string Cuenta_Contable { get; set; }
        public string Tipo_Movimiento { get; set; }
        public DateTime Fecha_Asiento { get; set; }
        public decimal Monto_Asiento { get; set; }
        public bool Estado { get; set; }
        public int Id_Orden_Compra { get; set; }
        public virtual Orden_Compra_Bd Orden_Compra { get; set; }
    }
}
