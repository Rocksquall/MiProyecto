using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Modulo = new HashSet<Modulo>();
        }

        public int Idproyecto { get; set; }
        public string ProyectoNombre { get; set; }
        public int ClienteIdcliente { get; set; }

        public virtual Cliente ClienteIdclienteNavigation { get; set; }
        public virtual ICollection<Modulo> Modulo { get; set; }
    }
}
