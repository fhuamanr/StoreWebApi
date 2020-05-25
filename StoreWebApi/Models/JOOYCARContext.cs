using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreWebApi.Models
{
    public partial class JOOYCARContext : DbContext
    {
        public JOOYCARContext()
        {
        }

        public JOOYCARContext(DbContextOptions<JOOYCARContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<ShippingInfo> ShippingInfo { get; set; }
        public virtual DbSet<StatusTk> StatusTk { get; set; }
        public virtual DbSet<Units> Units { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tenant)
                    .HasColumnName("tenant")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShippingInfo>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("shippingInfo");

                entity.Property(e => e.MessageId)
                    .HasColumnName("message_id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApellidoMaterno)
                    .HasColumnName("apellidoMaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasColumnName("apellidoPaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comuna)
                    .HasColumnName("comuna")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("fechaEmision")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasColumnName("modelo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patente)
                    .HasColumnName("patente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Poliza)
                    .HasColumnName("poliza")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rut)
                    .HasColumnName("rut")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vin)
                    .HasColumnName("vin")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Message)
                    .WithOne(p => p.ShippingInfo)
                    .HasForeignKey<ShippingInfo>(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shippingI__messa__395884C4");
            });

            modelBuilder.Entity<StatusTk>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("status_tk");

                entity.Property(e => e.MessageId)
                    .HasColumnName("message_id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Message)
                    .WithOne(p => p.StatusTk)
                    .HasForeignKey<StatusTk>(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__status_tk__messa__339FAB6E");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.ToTable("units");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Imei)
                    .HasColumnName("imei")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MessageId)
                    .IsRequired()
                    .HasColumnName("message_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RefId)
                    .HasColumnName("refId")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RefType)
                    .HasColumnName("refType")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serialNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Warehouse)
                    .HasColumnName("warehouse")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__units__message_i__367C1819");
            });
        }
    }
}
