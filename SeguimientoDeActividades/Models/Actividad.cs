using System;
using System.Collections.Generic;

namespace SeguimientoDeActividades.Models
{
    public partial class Actividad
    {
        public int IdActividad { get; set; }
        public DateTime ActividadFecha { get; set; }
        public string ActividadPredispuesta { get; set; }
        public int ActividadHoras { get; set; }
        public int CronogramaHasRecursoIdcronogramaHasRecurso { get; set; }
        public int FaseIdfase { get; set; }

        public virtual CronogramaHasRecurso CronogramaHasRecursoIdcronogramaHasRecursoNavigation { get; set; }
        public virtual Fase FaseIdfaseNavigation { get; set; }
    }
}
