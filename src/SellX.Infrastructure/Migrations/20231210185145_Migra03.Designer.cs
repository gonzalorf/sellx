﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SellX.Infrastructure.Database;

#nullable disable

namespace SellX.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231210185145_Migra03")]
    partial class Migra03
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SellX.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Products", "dbo");
                });

            modelBuilder.Entity("SellX.Domain.Tenants.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Tenants", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000001-0001-0001-0001-000000000001"),
                            Active = true,
                            Name = "Gonzalo Tenant"
                        },
                        new
                        {
                            Id = new Guid("863e9564-4b31-409d-805f-88465b949f5a"),
                            Active = true,
                            Name = "Store Norte"
                        },
                        new
                        {
                            Id = new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349"),
                            Active = true,
                            Name = "Store Sur"
                        });
                });

            modelBuilder.Entity("SellX.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d5e1b37-2afe-4063-b4eb-c47f96458e32"),
                            Deleted = false,
                            Email = "gonzalorf@sellx.com",
                            LastName = "Fernández",
                            Login = "gonzalo",
                            Name = "Gonzalo",
                            Order = 0L,
                            Password = "123",
                            Role = "Administrador",
                            TenantId = new Guid("00000001-0001-0001-0001-000000000001")
                        },
                        new
                        {
                            Id = new Guid("95f224c9-0258-4272-9957-ea038942ae90"),
                            Deleted = false,
                            Email = "sayala@music.com",
                            LastName = "Ayala",
                            Login = "chucaro",
                            Name = "Santiago",
                            Order = 0L,
                            Password = "123",
                            Role = "Administrador",
                            TenantId = new Guid("863e9564-4b31-409d-805f-88465b949f5a")
                        },
                        new
                        {
                            Id = new Guid("2b12a886-9a38-45f3-9850-5ffb95774ca0"),
                            Deleted = false,
                            Email = "jcafrune@music.com",
                            LastName = "Cafrune",
                            Login = "turco",
                            Name = "Jorge",
                            Order = 0L,
                            Password = "123",
                            Role = "Administrador",
                            TenantId = new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349")
                        });
                });

            modelBuilder.Entity("SellX.Infrastructure.Domain.Parameters.Parameter", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Name");

                    b.ToTable("Parameters", "dbo");
                });

            modelBuilder.Entity("SellX.Infrastructure.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Error")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
