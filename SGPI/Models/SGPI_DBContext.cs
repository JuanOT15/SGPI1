using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SGPI.Models
{
    public partial class SGPI_DBContext : DbContext
    {
        public SGPI_DBContext()
        {
        }

        public SGPI_DBContext(DbContextOptions<SGPI_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entrevistum> Entrevista { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Homologacion> Homologacions { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Programa> Programas { get; set; }
        public virtual DbSet<ProgramaUsuario> ProgramaUsuarios { get; set; }
        public virtual DbSet<Programacion> Programacions { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OTFISE1\\SQLEXPRESS;Initial Catalog=SGPI_DB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.IdEntrevista);

                entity.Property(e => e.IdEntrevista).ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.FechaEntrevista).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Entrevista_Usuario");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero);

                entity.ToTable("Genero");

                entity.Property(e => e.IdGenero).ValueGeneratedNever();

                entity.Property(e => e.ValGenero)
                    .HasMaxLength(500)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Homologacion>(entity =>
            {
                entity.HasKey(e => e.IdHomologacion);

                entity.ToTable("Homologacion");

                entity.Property(e => e.IdHomologacion).ValueGeneratedNever();

                entity.Property(e => e.FechaHomo).HasColumnType("date");

                entity.Property(e => e.Universidad)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK_Homologacion_Modulo");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_Homologacion_Programa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Homologacion_Usuario");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo);

                entity.ToTable("Modulo");

                entity.Property(e => e.IdModulo).ValueGeneratedNever();

                entity.Property(e => e.ValModulo)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_Modulo_Programa");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.Property(e => e.IdPago).ValueGeneratedNever();

                entity.Property(e => e.ComprobPago)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Pagos_Usuario");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.IdPrograma);

                entity.ToTable("Programa");

                entity.Property(e => e.IdPrograma).ValueGeneratedNever();

                entity.Property(e => e.Pensum)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.ValPrograma)
                    .HasMaxLength(500)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ProgramaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdProgramaUsu);

                entity.ToTable("ProgramaUsuario");

                entity.Property(e => e.IdProgramaUsu).ValueGeneratedNever();

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.ProgramaUsuarios)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_ProgramaUsuario_Programa");

                entity.HasOne(d => d.IdPrograma1)
                    .WithMany(p => p.ProgramaUsuarios)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_ProgramaUsuario_Usuario");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion);

                entity.ToTable("Programacion");

                entity.Property(e => e.IdProgramacion).ValueGeneratedNever();

                entity.Property(e => e.Clave)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Salon)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Semestre)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK_Programacion_Modulo");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).ValueGeneratedNever();

                entity.Property(e => e.ValRol)
                    .HasMaxLength(500)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDoc);

                entity.ToTable("TipoDocumento");

                entity.Property(e => e.IdTipoDoc).ValueGeneratedNever();

                entity.Property(e => e.ValTipoDoc)
                    .HasMaxLength(500)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Documento)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.HasOne(d => d.GeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Genero)
                    .HasConstraintName("FK_Usuario_Genero");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_Usuario_Rol");

                entity.HasOne(d => d.TipoDocNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoDoc)
                    .HasConstraintName("FK_Usuario_TipoDocumento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
