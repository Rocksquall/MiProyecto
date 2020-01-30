using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class CronogramaHasRecurso
    {
        public CronogramaHasRecurso()
        {
            Actividad = new HashSet<Actividad>();
        }

        public int IdcronogramaHasRecurso { get; set; }
        public int CronogramaIdcronograma { get; set; }
        public int RecursoIdrecurso { get; set; }

        public virtual Cronograma CronogramaIdcronogramaNavigation { get; set; }
        public virtual Recurso RecursoIdrecursoNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
