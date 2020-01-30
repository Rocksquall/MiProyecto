using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int Idcliente { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteNit { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
