using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Estimacion
    {
        public Estimacion()
        {
            Fase = new HashSet<Fase>();
        }

        public int Idestimacion { get; set; }
        public DateTime EstimacionFechaInicio { get; set; }
        public DateTime EstimacionFechaFin { get; set; }
        public int ModuloIdmodulo { get; set; }

        public virtual Modulo ModuloIdmoduloNavigation { get; set; }
        public virtual ICollection<Fase> Fase { get; set; }
    }
}
