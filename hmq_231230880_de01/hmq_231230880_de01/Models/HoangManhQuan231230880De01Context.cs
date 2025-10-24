using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hmq_231230880_de01.Models;

public partial class HoangManhQuan231230880De01Context : DbContext
{
    public HoangManhQuan231230880De01Context()
    {
    }

    public HoangManhQuan231230880De01Context(DbContextOptions<HoangManhQuan231230880De01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<HmqComputer> HmqComputers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MFTG9FU5;Database=HoangManhQuan_231230880_de01;uid=sa;pwd=UTC@123;MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HmqComputer>(entity =>
        {
            entity.HasKey(e => e.HmqComId).HasName("PK__HmqCompu__992CF3A2A9C39D84");

            entity.ToTable("HmqComputer");

            entity.Property(e => e.HmqComId).HasColumnName("hmqComId");
            entity.Property(e => e.HmqComImage)
                .HasMaxLength(255)
                .HasColumnName("hmqComImage");
            entity.Property(e => e.HmqComName)
                .HasMaxLength(50)
                .HasColumnName("hmqComName");
            entity.Property(e => e.HmqComPrice)
                .HasColumnType("decimal(12, 0)")
                .HasColumnName("hmqComPrice");
            entity.Property(e => e.HmqComStatus).HasColumnName("hmqComStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
