using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Recurso
    {
        public Recurso()
        {
            CronogramaHasRecurso = new HashSet<CronogramaHasRecurso>();
            Modulo = new HashSet<Modulo>();
        }

        public int Idrecurso { get; set; }
        public string RecursoNombre { get; set; }
        public int Recursodisponibilidad { get; set; }
        public string Recursocorreo { get; set; }

        public virtual ICollection<CronogramaHasRecurso> CronogramaHasRecurso { get; set; }
        public virtual ICollection<Modulo> Modulo { get; set; }
    }
}
