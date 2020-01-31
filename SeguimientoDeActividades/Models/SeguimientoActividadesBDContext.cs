using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SeguimientoDeActividades.Models
{
    public partial class SeguimientoActividadesBDContext : DbContext
    {
        public SeguimientoActividadesBDContext()
        {
        }

        public SeguimientoActividadesBDContext(DbContextOptions<SeguimientoActividadesBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cronograma> Cronogramas { get; set; }
        public virtual DbSet<CronogramaHasRecurso> CronogramaHasRecursos { get; set; }
        public virtual DbSet<Estimacion> Estimaciones { get; set; }
        public virtual DbSet<Fase> Fases { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Recurso> Recursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MPC-5CG9253RTM\\SQLEXPRESS;Initial catalog=SeguimientoActividadesBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(e => e.IdActividad)
                    .HasName("PK_actividad_idActividad");

                entity.ToTable("actividad", "seguimiento_actividades_bd");

                entity.HasIndex(e => e.CronogramaHasRecursoIdcronogramaHasRecurso)
                    .HasName("fk_actividad_cronograma_has_recurso1_idx");

                entity.HasIndex(e => e.FaseIdfase)
                    .HasName("fk_actividad_fase1_idx");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.ActividadFecha)
                    .HasColumnName("actividadFecha")
                    .HasColumnType("date");

                entity.Property(e => e.ActividadHoras).HasColumnName("actividadHoras");

                entity.Property(e => e.ActividadPredispuesta)
                    .IsRequired()
                    .HasColumnName("actividadPredispuesta")
                    .HasMaxLength(45);

                entity.Property(e => e.CronogramaHasRecursoIdcronogramaHasRecurso).HasColumnName("cronograma_has_recurso_idcronograma_has_recurso");

                entity.Property(e => e.FaseIdfase).HasColumnName("fase_idfase");

                entity.HasOne(d => d.CronogramaHasRecursoIdcronogramaHasRecursoNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.CronogramaHasRecursoIdcronogramaHasRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("actividad$fk_actividad_cronograma_has_recurso1");

                entity.HasOne(d => d.FaseIdfaseNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.FaseIdfase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("actividad$fk_actividad_fase1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK_cliente_idcliente");

                entity.ToTable("cliente", "seguimiento_actividades_bd");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.ClienteNit)
                    .IsRequired()
                    .HasColumnName("clienteNit")
                    .HasMaxLength(11);

                entity.Property(e => e.ClienteNombre)
                    .IsRequired()
                    .HasColumnName("clienteNombre")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Cronograma>(entity =>
            {
                entity.HasKey(e => e.Idcronograma)
                    .HasName("PK_cronograma_idcronograma");

                entity.ToTable("cronograma", "seguimiento_actividades_bd");

                entity.Property(e => e.Idcronograma).HasColumnName("idcronograma");

                entity.Property(e => e.CronogramaFechaPlan)
                    .HasColumnName("cronogramaFechaPlan")
                    .HasColumnType("date");

                entity.Property(e => e.CronogramaHorasPlan)
                    .IsRequired()
                    .HasColumnName("cronogramaHorasPlan")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<CronogramaHasRecurso>(entity =>
            {
                entity.HasKey(e => e.IdcronogramaHasRecurso)
                    .HasName("PK_cronograma_has_recurso_idcronograma_has_recurso");

                entity.ToTable("cronograma_has_recurso", "seguimiento_actividades_bd");

                entity.HasIndex(e => e.CronogramaIdcronograma)
                    .HasName("fk_cronograma_has_recurso_cronograma2_idx");

                entity.HasIndex(e => e.RecursoIdrecurso)
                    .HasName("fk_cronograma_has_recurso_recurso2_idx");

                entity.Property(e => e.IdcronogramaHasRecurso).HasColumnName("idcronograma_has_recurso");

                entity.Property(e => e.CronogramaIdcronograma).HasColumnName("cronograma_idcronograma");

                entity.Property(e => e.RecursoIdrecurso).HasColumnName("recurso_idrecurso");

                entity.HasOne(d => d.CronogramaIdcronogramaNavigation)
                    .WithMany(p => p.CronogramaHasRecurso)
                    .HasForeignKey(d => d.CronogramaIdcronograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cronograma_has_recurso$fk_cronograma_has_recurso_cronograma2");

                entity.HasOne(d => d.RecursoIdrecursoNavigation)
                    .WithMany(p => p.CronogramaHasRecurso)
                    .HasForeignKey(d => d.RecursoIdrecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cronograma_has_recurso$fk_cronograma_has_recurso_recurso2");
            });

            modelBuilder.Entity<Estimacion>(entity =>
            {
                entity.HasKey(e => e.Idestimacion)
                    .HasName("PK_estimacion_idestimacion");

                entity.ToTable("estimacion", "seguimiento_actividades_bd");

                entity.HasIndex(e => e.ModuloIdmodulo)
                    .HasName("fk_estimacion_modulo1_idx");

                entity.Property(e => e.Idestimacion).HasColumnName("idestimacion");

                entity.Property(e => e.EstimacionFechaFin)
                    .HasColumnName("estimacionFechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.EstimacionFechaInicio)
                    .HasColumnName("estimacionFechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.ModuloIdmodulo).HasColumnName("modulo_idmodulo");

                entity.HasOne(d => d.ModuloIdmoduloNavigation)
                    .WithMany(p => p.Estimacion)
                    .HasForeignKey(d => d.ModuloIdmodulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estimacion$fk_estimacion_modulo1");
            });

            modelBuilder.Entity<Fase>(entity =>
            {
                entity.HasKey(e => e.Idfase)
                    .HasName("PK_fase_idfase");

                entity.ToTable("fase", "seguimiento_actividades_bd");

                entity.HasIndex(e => e.EstimacionIdestimacion)
                    .HasName("fk_fase_estimacion1_idx");

                entity.Property(e => e.Idfase).HasColumnName("idfase");

                entity.Property(e => e.EstimacionIdestimacion).HasColumnName("estimacion_idestimacion");

                entity.Property(e => e.FaseNombre)
                    .IsRequired()
                    .HasColumnName("faseNombre")
                    .HasMaxLength(45);

                entity.HasOne(d => d.EstimacionIdestimacionNavigation)
                    .WithMany(p => p.Fase)
                    .HasForeignKey(d => d.EstimacionIdestimacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fase$fk_fase_estimacion1");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.Idmodulo)
                    .HasName("PK_modulo_idmodulo");

                entity.ToTable("modulo", "seguimiento_actividades_bd");

                entity.HasIndex(e => e.ProyectoIdproyecto)
                    .HasName("fk_modulo_proyecto1_idx");

                entity.HasIndex(e => e.RecursoIdrecurso)
                    .HasName("fk_modulo_recurso1_idx");

                entity.Property(e => e.Idmodulo).HasColumnName("idmodulo");

                entity.Property(e => e.ModuloPrioridad).HasColumnName("moduloPrioridad");

                entity.Property(e => e.Modulonombre)
                    .IsRequired()
                    .HasColumnName("modulonombre")
                    .HasMaxLength(45);

                entity.Property(e => e.ProyectoIdproyecto).HasColumnName("proyecto_idproyecto");

                entity.Property(e => e.RecursoIdrecurso).HasColumnName("recurso_idrecurso");

                entity.HasOne(d => d.ProyectoIdproyectoNavigation)
                    .WithMany(p => p.Modulo)
                    .HasForeignKey(d => d.ProyectoIdproyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("modulo$fk_modulo_proyecto1");

                entity.HasOne(d => d.RecursoIdrecursoNavigation)
                    .WithMany(p => p.Modulo)
                    .HasForeignKey(d => d.RecursoIdrecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("modulo$fk_modulo_recurso1");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.Idproyecto)
                    .HasName("PK_proyecto_idproyecto");

                entity.ToTable("proyecto", "seguimiento_actividades_bd");

                entity.HasIndex(e => e.ClienteIdcliente)
                    .HasName("fk_proyecto_cliente_idx");

                entity.Property(e => e.Idproyecto)
                    .HasColumnName("idproyecto")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClienteIdcliente).HasColumnName("cliente_idcliente");

                entity.Property(e => e.ProyectoNombre)
                    .IsRequired()
                    .HasColumnName("proyectoNombre")
                    .HasMaxLength(45);

                entity.HasOne(d => d.ClienteIdclienteNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.ClienteIdcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proyecto$fk_proyecto_cliente");
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.HasKey(e => e.Idrecurso)
                    .HasName("PK_recurso_idrecurso");

                entity.ToTable("recurso", "seguimiento_actividades_bd");

                entity.Property(e => e.Idrecurso).HasColumnName("idrecurso");

                entity.Property(e => e.RecursoNombre)
                    .IsRequired()
                    .HasColumnName("recursoNombre")
                    .HasMaxLength(45);

                entity.Property(e => e.Recursocorreo)
                    .IsRequired()
                    .HasColumnName("recursocorreo")
                    .HasMaxLength(45);

                entity.Property(e => e.Recursodisponibilidad).HasColumnName("recursodisponibilidad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
