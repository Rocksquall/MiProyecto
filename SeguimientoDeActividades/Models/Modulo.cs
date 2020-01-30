using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Estimacion = new HashSet<Estimacion>();
        }

        public int Idmodulo { get; set; }
        public string Modulonombre { get; set; }
        public int ModuloPrioridad { get; set; }
        public int ProyectoIdproyecto { get; set; }
        public int RecursoIdrecurso { get; set; }

        public virtual Proyecto ProyectoIdproyectoNavigation { get; set; }
        public virtual Recurso RecursoIdrecursoNavigation { get; set; }
        public virtual ICollection<Estimacion> Estimacion { get; set; }
    }
}
