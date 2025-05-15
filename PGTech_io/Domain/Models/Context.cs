using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PGTech_io.Data;

namespace PGTech_io.Models;

public partial class Context : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }
    public virtual DbSet<Documentation> Documentations { get; set; }
    public virtual DbSet<Response> Responses { get; set; }
    public virtual DbSet<Sector> Sectors { get; set; }
    public virtual DbSet<Send> Sends { get; set; }
    public virtual DbSet<Subsector> Subsectors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Username=brian; Password=aeth;Database=pgtech_wiz");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles = new()
        {
            new IdentityRole
            {
                Id = "Tecnico",
                Name = "Tecnico",
                NormalizedName = "TECNICO"
            },

            new IdentityRole
            {
                Id = "Usuario",
                Name = "Usuario",
                NormalizedName = "USUARIO"
            },
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
        modelBuilder.HasDefaultSchema("identity");

        modelBuilder.Entity<Documentation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Documentation_pkey");

            entity.ToTable("Documentation", "identity");

            entity.HasIndex(e => e.Idsolicitation, "IX_Documentation_idsolicitation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Createdwhen).HasColumnName("createdwhen");
            entity.Property(e => e.FileUrlproperty).HasColumnName("FileURLProperty");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.Filetype)
                .HasMaxLength(255)
                .HasColumnName("filetype");
            entity.Property(e => e.Fileurl)
                .HasMaxLength(255)
                .HasColumnName("fileurl");
            entity.Property(e => e.Idsolicitation).HasColumnName("idsolicitation");

            entity.HasOne(d => d.IdsolicitationNavigation).WithMany(p => p.Documentations)
                .HasForeignKey(d => d.Idsolicitation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_solicit");
        });

        modelBuilder.Entity<Response>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Responses_pkey");

            entity.ToTable("Responses", "identity");

            entity.HasIndex(e => e.Idsolicitation, "IX_Responses_idsolicitation");

            entity.HasIndex(e => e.Iduser, "IX_Responses_iduser");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Createdwhen).HasColumnName("createdwhen");
            entity.Property(e => e.Idsolicitation).HasColumnName("idsolicitation");
            entity.Property(e => e.Iduser)
                .HasMaxLength(255)
                .HasColumnName("iduser");
            entity.Property(e => e.Solutiondescription)
                .HasMaxLength(255)
                .HasColumnName("solutiondescription");
            entity.Property(e => e.Updatedwhen).HasColumnName("updatedwhen");

            entity.HasOne(d => d.IdsolicitationNavigation).WithMany(p => p.Responses)
                .HasForeignKey(d => d.Idsolicitation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_solicit");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Responses)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sectors_pkey");

            entity.ToTable("Sectors", "identity");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Send>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sends_pkey");

            entity.ToTable("Sends", "identity");

            entity.HasIndex(e => e.Iduser, "IX_Sends_iduser");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Client)
                .HasMaxLength(255)
                .HasColumnName("client");
            entity.Property(e => e.Createdwhen).HasColumnName("createdwhen");
            entity.Property(e => e.Iduser)
                .HasMaxLength(255)
                .HasColumnName("iduser");
            entity.Property(e => e.Problemdescription)
                .HasMaxLength(255)
                .HasColumnName("problemdescription");
            entity.Property(e => e.Updatedwhen).HasColumnName("updatedwhen");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Senders)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<Subsector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Subsectors_pkey");

            entity.ToTable("Subsectors", "identity");

            entity.HasIndex(e => e.Idsector, "IX_Subsectors_idsector");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Idsector).HasColumnName("idsector");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.IdsectorNavigation).WithMany(p => p.Subsectors)
                .HasForeignKey(d => d.Idsector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sector");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
