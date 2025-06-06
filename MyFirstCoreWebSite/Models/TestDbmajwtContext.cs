﻿//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace MyFirstCoreWebSite.Models;

//public partial class TestDbmajwtContext : DbContext
//{
//    public TestDbmajwtContext()
//    {
//    }

//    public TestDbmajwtContext(DbContextOptions<TestDbmajwtContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

//    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

//    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

//    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

//    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

//    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

//    public virtual DbSet<Customer> Customers { get; set; }

//    public virtual DbSet<Employee> Employees { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {

//    }
//    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//    //        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-LQDQBGOC;Initial Catalog=TestDBMAJwt;User ID=sa;Password=123;TrustServerCertificate=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<AspNetRole>(entity =>
//        {
//            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
//                .IsUnique()
//                .HasFilter("([NormalizedName] IS NOT NULL)");

//            entity.Property(e => e.Name).HasMaxLength(256);
//            entity.Property(e => e.NormalizedName).HasMaxLength(256);
//        });

//        modelBuilder.Entity<AspNetRoleClaim>(entity =>
//        {
//            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

//            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
//        });

//        modelBuilder.Entity<AspNetUser>(entity =>
//        {
//            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

//            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
//                .IsUnique()
//                .HasFilter("([NormalizedUserName] IS NOT NULL)");

//            entity.Property(e => e.Email).HasMaxLength(256);
//            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
//            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
//            entity.Property(e => e.UserName).HasMaxLength(256);

//            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
//                .UsingEntity<Dictionary<string, object>>(
//                    "AspNetUserRole",
//                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
//                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
//                    j =>
//                    {
//                        j.HasKey("UserId", "RoleId");
//                        j.ToTable("AspNetUserRoles");
//                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
//                    });
//        });

//        modelBuilder.Entity<AspNetUserClaim>(entity =>
//        {
//            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

//            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
//        });

//        modelBuilder.Entity<AspNetUserLogin>(entity =>
//        {
//            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

//            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

//            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
//        });

//        modelBuilder.Entity<AspNetUserToken>(entity =>
//        {
//            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

//            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
//        });

//        modelBuilder.Entity<Customer>(entity =>
//        {
//            entity.ToTable("Customer");

//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Employee>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07045DFA2A");

//            entity.Property(e => e.Address)
//                .HasMaxLength(500)
//                .IsUnicode(false);
//            entity.Property(e => e.Name)
//                .HasMaxLength(255)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.Property(e => e.Name)
//                .HasMaxLength(255)
//                .IsUnicode(false);
//            entity.Property(e => e.Password)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.UserName)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
