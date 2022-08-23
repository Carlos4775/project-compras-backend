using System;
using System.ComponentModel.DataAnnotations;
namespace apiCompras.Models
{
    public class Orden_Compra_Bd
    {
        [Key]
        public int Id_Orden_Compra { get; set; }
        public int No_Orden { get; set; }
        public DateTime Fecha_Orden { get; set; }
        public bool Estado { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo_Unitario { get; set; }
        public decimal Monto { get; set; }
        public  int? Id_Asiento { get; set; }
        public int Id_Articulo { get; set; }
        public virtual Articulos_Bd Articulo { get; set; }
        public int Id_Unidad_Medida { get; set; }
        public virtual Unidades_Medida_Bd Unidad_Medida { get; set; }
        public int Id_Proveedor { get; set; }
        public virtual Proveedores_Bd Proveedor { get; set; }
        public int Id_Departamento { get; set; }
        public virtual Departamentos_Bd Departamento { get; set; }
    }
}
