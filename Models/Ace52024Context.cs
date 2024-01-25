using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace flightapp.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Suhasinibooking> Suhasinibookings { get; set; }

    public virtual DbSet<Suhasinicustomer> Suhasinicustomers { get; set; }

    public virtual DbSet<Suhasiniflight> Suhasiniflights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Suhasinibooking>(entity =>
        {
            entity.HasKey(e => e.Bookingid).HasName("PK__Suhasini__73961EC50952B824");

            entity.ToTable("Suhasinibooking");

            entity.Property(e => e.Bookingid)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Bookingaddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Bookingdate).HasColumnType("datetime");
            entity.Property(e => e.Bookingname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Flightid)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Suhasinibookings)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FK__Suhasinib__Custo__4183B671");

            entity.HasOne(d => d.Flight).WithMany(p => p.Suhasinibookings)
                .HasForeignKey(d => d.Flightid)
                .HasConstraintName("FK__Suhasinib__Fligh__4277DAAA");
        });

        modelBuilder.Entity<Suhasinicustomer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("PK__Suhasini__A4AD5890FDAFD436");

            entity.ToTable("Suhasinicustomer");

            entity.Property(e => e.Customeremail)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Customerlocation)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Customerpw)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Customerusername)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Suhasiniflight>(entity =>
        {
            entity.HasKey(e => e.Flightid).HasName("PK__Suhasini__8A9900662EA14B63");

            entity.ToTable("Suhasiniflight");

            entity.Property(e => e.Flightid)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Flightdestination)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Flightname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Flightsource)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
