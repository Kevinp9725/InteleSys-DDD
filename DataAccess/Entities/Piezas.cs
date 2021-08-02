using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Piezas
    {
        public int articuloId { get; set; }
        public string serialNo { get; set; }
        public float precioCosto { get; set; }
        public float isv { get; set; }
        public float iva { get; set; }
        public string descripcion {get; set; }
        public int modeloId { get; set; }


    }
}
