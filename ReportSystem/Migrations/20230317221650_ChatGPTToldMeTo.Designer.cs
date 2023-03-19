﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReportSystem.Contexts;

#nullable disable

namespace ReportSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230317221650_ChatGPTToldMeTo")]
    partial class ChatGPTToldMeTo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReportSystem.Models.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.ReportsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.TenantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.TenantReportsEntity", b =>
                {
                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.HasKey("TenantId", "ReportId");

                    b.HasIndex("ReportId");

                    b.ToTable("TenantReports");
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.TenantEntity", b =>
                {
                    b.HasOne("ReportSystem.Models.Entities.AddressEntity", "Address")
                        .WithOne("Tenant")
                        .HasForeignKey("ReportSystem.Models.Entities.TenantEntity", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.TenantReportsEntity", b =>
                {
                    b.HasOne("ReportSystem.Models.Entities.ReportsEntity", "Report")
                        .WithMany("TenantReports")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReportSystem.Models.Entities.TenantEntity", "Tenant")
                        .WithMany("TenantReports")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.AddressEntity", b =>
                {
                    b.Navigation("Tenant")
                        .IsRequired();
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.ReportsEntity", b =>
                {
                    b.Navigation("TenantReports");
                });

            modelBuilder.Entity("ReportSystem.Models.Entities.TenantEntity", b =>
                {
                    b.Navigation("TenantReports");
                });
#pragma warning restore 612, 618
        }
    }
}