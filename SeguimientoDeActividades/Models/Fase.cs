using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Fase
    {
        public Fase()
        {
            Actividad = new HashSet<Actividad>();
        }

        public int Idfase { get; set; }
        public string FaseNombre { get; set; }
        public int EstimacionIdestimacion { get; set; }

        public virtual Estimacion EstimacionIdestimacionNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
