﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day09Lab_DatabaseFirst.Models;

public partial class ShoppingCartDbContext : DbContext
{
    public ShoppingCartDbContext()
    {
    }

    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CtHoaDon> CtHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MFTG9FU5;Database=ShoppingCartDB;uid=sa;pwd=UTC@123;MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CT_HOA_D__3214EC27117BCA6F");

            entity.ToTable("CT_HOA_DON");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGiaMua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");
            entity.Property(e => e.SoLuongMua).HasDefaultValue(1);
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("([SoLuongMua]*[DonGiaMua])", true)
                .HasColumnType("decimal(29, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.HoaDon).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.HoaDonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CT_HOA_DO__HoaDo__4D94879B");

            entity.HasOne(d => d.SanPham).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.SanPhamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CT_HOA_DO__SanPh__4E88ABD4");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HOA_DON__3214EC27D1E89029");

            entity.ToTable("HOA_DON");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(100);
            entity.Property(e => e.MaHoaDon).HasMaxLength(20);
            entity.Property(e => e.NgayHoaDon)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayNhan).HasColumnType("datetime");
            entity.Property(e => e.TongTriGia)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HOA_DON__MaKhach__48CFD27E");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KHACH_HA__3214EC273412102B");

            entity.ToTable("KHACH_HANG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(100);
            entity.Property(e => e.MaKhachHang).HasMaxLength(20);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.NgayDangKy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAI_SAN__3214EC2780252AF4");

            entity.ToTable("LOAI_SAN_PHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaLoai).HasMaxLength(20);
            entity.Property(e => e.TenLoai).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QUAN_TRI__3214EC273920A586");

            entity.ToTable("QUAN_TRI");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SAN_PHAM__3214EC27F01CD4B3");

            entity.ToTable("SAN_PHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HinhAnh).HasMaxLength(200);
            entity.Property(e => e.MaSanPham).HasMaxLength(20);
            entity.Property(e => e.SoLuong).HasDefaultValue(0);
            entity.Property(e => e.TenSanPham).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SAN_PHAM__MaLoai__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
