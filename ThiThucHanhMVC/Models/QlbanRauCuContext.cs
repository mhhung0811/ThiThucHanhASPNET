using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThiThucHanhMVC.Models;

public partial class QlbanRauCuContext : DbContext
{
    public QlbanRauCuContext()
    {
    }

    public QlbanRauCuContext(DbContextOptions<QlbanRauCuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TChiTietRauCu> TChiTietRauCus { get; set; }

    public virtual DbSet<TDanhMucRauCu> TDanhMucRauCus { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TLoaiRauCu> TLoaiRauCus { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TXuatXu> TXuatXus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HP_ADMIN_H;Initial Catalog=QLBanRauCu;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TChiTietRauCu>(entity =>
        {
            entity.HasKey(e => e.MaChiTietRauCu);

            entity.ToTable("tChiTietRauCu");

            entity.Property(e => e.MaChiTietRauCu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaRauCu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MoTaChiTiet).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<TDanhMucRauCu>(entity =>
        {
            entity.HasKey(e => e.MaRauCu);

            entity.ToTable("tDanhMucRauCu");

            entity.Property(e => e.MaRauCu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaLoaiRauCu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NguonGoc).HasMaxLength(100);
            entity.Property(e => e.TenRauCu).HasMaxLength(150);
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");
            entity.Property(e => e.ThongTinThue).HasMaxLength(250);
            entity.Property(e => e.TongTienHd)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TongTienHD");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang);

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
        });

        modelBuilder.Entity<TLoaiRauCu>(entity =>
        {
            entity.HasKey(e => e.MaLoaiRauCu);

            entity.ToTable("tLoaiRauCu");

            entity.Property(e => e.MaLoaiRauCu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LoaiRauCu).HasMaxLength(100);
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("tNhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SoDienThoai2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("tUser");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
        });

        modelBuilder.Entity<TXuatXu>(entity =>
        {
            entity.HasKey(e => e.MaXuatXu);

            entity.ToTable("tXuatXu");

            entity.Property(e => e.MaXuatXu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenXuatXu).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
