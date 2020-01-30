using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Cronograma
    {
        public Cronograma()
        {
            CronogramaHasRecurso = new HashSet<CronogramaHasRecurso>();
        }

        public int Idcronograma { get; set; }
        public DateTime CronogramaFechaPlan { get; set; }
        public string CronogramaHorasPlan { get; set; }

        public virtual ICollection<CronogramaHasRecurso> CronogramaHasRecurso { get; set; }
    }
}
