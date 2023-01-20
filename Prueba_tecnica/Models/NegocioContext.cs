using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_tecnica.Models;

public partial class NegocioContext : DbContext
{
    public NegocioContext()
    {
    }

    public NegocioContext(DbContextOptions<NegocioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-759APQ2\\SQLEXPRESS; Database=Negocio; Trusted_Connection=True; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Identificador);

            entity.Property(e => e.Identificador).HasColumnName("Id_Producto");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Estado_Producto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Nombre_Producto");
			entity.Property(e => e.Acciones)
				.HasMaxLength(50)
				.HasColumnName("Acciones");
		});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
