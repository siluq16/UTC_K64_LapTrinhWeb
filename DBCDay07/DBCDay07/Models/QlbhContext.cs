using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBCDay07.Models;

public partial class QlbhContext : DbContext
{
    public QlbhContext()
    {
    }

    public QlbhContext(DbContextOptions<QlbhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblChatlieu> TblChatlieus { get; set; }

    public virtual DbSet<TblChitietHdban> TblChitietHdbans { get; set; }

    public virtual DbSet<TblHang> TblHangs { get; set; }

    public virtual DbSet<TblHdban> TblHdbans { get; set; }

    public virtual DbSet<TblKhach> TblKhaches { get; set; }

    public virtual DbSet<TblNhanvien> TblNhanviens { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblChatlieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__tblChatl__453995BC3E67948F");

            entity.ToTable("tblChatlieu");

            entity.Property(e => e.MaChatLieu).HasMaxLength(10);
            entity.Property(e => e.TenChatLieu).HasMaxLength(50);
        });

        modelBuilder.Entity<TblChitietHdban>(entity =>
        {
            entity.HasKey(e => new { e.MaHdban, e.MaHang }).HasName("PK__tblChiti__828C639B124E5425");

            entity.ToTable("tblChitietHDBan");

            entity.Property(e => e.MaHdban)
                .HasMaxLength(20)
                .HasColumnName("MaHDBan");
            entity.Property(e => e.MaHang).HasMaxLength(10);
            entity.Property(e => e.GiaMua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.TblChitietHdbans)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTHDBan_Hang");

            entity.HasOne(d => d.MaHdbanNavigation).WithMany(p => p.TblChitietHdbans)
                .HasForeignKey(d => d.MaHdban)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTHDBan_HDBan");
        });

        modelBuilder.Entity<TblHang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__tblHang__19C0DB1D56903A0B");

            entity.ToTable("tblHang");

            entity.Property(e => e.MaHang).HasMaxLength(10);
            entity.Property(e => e.Anh).HasMaxLength(255);
            entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaChatLieu).HasMaxLength(10);
            entity.Property(e => e.TenHang).HasMaxLength(100);

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TblHangs)
                .HasForeignKey(d => d.MaChatLieu)
                .HasConstraintName("FK_Hang_Chatlieu");
        });

        modelBuilder.Entity<TblHdban>(entity =>
        {
            entity.HasKey(e => e.MaHdban).HasName("PK__tblHDBan__43106E2AB148CCBE");

            entity.ToTable("tblHDBan");

            entity.Property(e => e.MaHdban)
                .HasMaxLength(20)
                .HasColumnName("MaHDBan");
            entity.Property(e => e.MaKhach).HasMaxLength(10);
            entity.Property(e => e.MaNhanvien).HasMaxLength(10);
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaKhachNavigation).WithMany(p => p.TblHdbans)
                .HasForeignKey(d => d.MaKhach)
                .HasConstraintName("FK_HDBan_Khach");

            entity.HasOne(d => d.MaNhanvienNavigation).WithMany(p => p.TblHdbans)
                .HasForeignKey(d => d.MaNhanvien)
                .HasConstraintName("FK_HDBan_Nhanvien");
        });

        modelBuilder.Entity<TblKhach>(entity =>
        {
            entity.HasKey(e => e.MaKhach).HasName("PK__tblKhach__D0CB8DDD0FD3C1C3");

            entity.ToTable("tblKhach");

            entity.Property(e => e.MaKhach).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.TenKhach).HasMaxLength(50);
        });

        modelBuilder.Entity<TblNhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNhanvien).HasName("PK__tblNhanv__81C97F05F79EB774");

            entity.ToTable("tblNhanvien");

            entity.Property(e => e.MaNhanvien).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.TenNhanvien).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
