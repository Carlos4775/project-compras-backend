﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiCompras.Models
{
    public class Departamentos_Bd
    {
        [Key]
        public int Id_Departamento { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public List<Orden_Compra_Bd> Ordenes_Compras { get; set; }
    }
}
