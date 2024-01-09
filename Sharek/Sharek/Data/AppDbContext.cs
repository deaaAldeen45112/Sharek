using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sharek.Models;

namespace Sharek.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Ministry> Ministries { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Requestservice> Requestservices { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity
                .ToTable("address")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.AddressId).HasColumnType("int(11)");
            entity.Property(e => e.Place)
                .HasMaxLength(100)
                .HasColumnName("place")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Ministry>(entity =>
        {
            entity.HasKey(e => e.MinistryId).HasName("PRIMARY");

            entity
                .ToTable("ministry")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.MinistryId)
                .HasColumnType("int(11)")
                .HasColumnName("ministryId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PRIMARY");

            entity
                .ToTable("post")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.FromPlace, "post_from_id");

            entity.HasIndex(e => e.ToPlace, "post_to_id");

            entity.HasIndex(e => e.UserId, "post_user_id");

            entity.Property(e => e.PostId)
                .HasColumnType("int(11)")
                .HasColumnName("postId");
            entity.Property(e => e.Access)
                .HasMaxLength(100)
                .HasColumnName("access")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ArrivedTime)
                .HasColumnType("timestamp")
                .HasColumnName("arrivedTime");
            entity.Property(e => e.AvaliableSeat)
                .HasColumnType("int(11)")
                .HasColumnName("avaliableSeat");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("createdDate");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("timestamp")
                .HasColumnName("departureDate");
            entity.Property(e => e.FromPlace)
                .HasColumnType("int(11)")
                .HasColumnName("fromPlace");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .HasColumnName("note")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.ToPlace)
                .HasColumnType("int(11)")
                .HasColumnName("toPlace");
            entity.Property(e => e.TypeOfVichle)
                .HasMaxLength(100)
                .HasColumnName("typeOfVichle")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("userId");

            entity.HasOne(d => d.FromPlaceNavigation).WithMany(p => p.PostFromPlaceNavigations)
                .HasForeignKey(d => d.FromPlace)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("post_from_id");

            entity.HasOne(d => d.ToPlaceNavigation).WithMany(p => p.PostToPlaceNavigations)
                .HasForeignKey(d => d.ToPlace)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("post_to_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("post_user_id");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity
                .ToTable("request")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.UserId, "request_user_id");

            entity.Property(e => e.RequestId)
                .HasColumnType("int(11)")
                .HasColumnName("requestId");
            entity.Property(e => e.CaseName)
                .HasMaxLength(100)
                .HasColumnName("caseName")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Lat)
                .HasMaxLength(100)
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasMaxLength(100)
                .HasColumnName("lng");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("request_user_id");
        });

        modelBuilder.Entity<Requestservice>(entity =>
        {
            entity.HasKey(e => e.RequestServiceId).HasName("PRIMARY");

            entity
                .ToTable("requestservice")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.RequestId, "requestService_request_id");

            entity.HasIndex(e => e.ServiceId, "requestService_service_id");

            entity.Property(e => e.RequestServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("requestServiceId");
            entity.Property(e => e.RequestId)
                .HasColumnType("int(11)")
                .HasColumnName("requestId");
            entity.Property(e => e.ServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("serviceId");

            entity.HasOne(d => d.Request).WithMany(p => p.Requestservices)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("requestService_request_id");

            entity.HasOne(d => d.Service).WithMany(p => p.Requestservices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("requestService_service_id");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PRIMARY");

            entity
                .ToTable("service")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.MinistryId, "service_ministry_id");

            entity.Property(e => e.ServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("serviceId");
            entity.Property(e => e.MinistryId)
                .HasColumnType("int(11)")
                .HasColumnName("ministryId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Ministry).WithMany(p => p.Services)
                .HasForeignKey(d => d.MinistryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("service_ministry_id");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("test");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity
                .ToTable("user")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.MinistryId, "user_ministry_id");

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsAbleToSendPost)
                .HasMaxLength(20)
                .HasColumnName("isAbleToSendPost");
            entity.Property(e => e.MinistryId)
                .HasColumnType("int(11)")
                .HasColumnName("ministryId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .HasColumnName("role");
            entity.Property(e => e.Ssid)
                .HasMaxLength(20)
                .HasColumnName("ssid");

            entity.HasOne(d => d.Ministry).WithMany(p => p.Users)
                .HasForeignKey(d => d.MinistryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_ministry_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
