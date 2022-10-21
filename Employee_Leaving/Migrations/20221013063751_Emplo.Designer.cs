﻿// <auto-generated />
using System;
using Employee_Leaving.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee_Leaving.Migrations
{
    [DbContext(typeof(LeavingDbContext))]
    [Migration("20221013063751_Emplo")]
    partial class Emplo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Employee_Leaving.Models.Employee", b =>
                {
                    b.Property<int>("Emp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Emp_Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email_Id")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Emp_Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Employee_Leaving.Models.Leave", b =>
                {
                    b.Property<int>("Leave_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Leave_Id"), 1L, 1);

                    b.Property<string>("ActionResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Emp_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeaveType_Id")
                        .HasColumnType("int");

                    b.Property<int>("RemainingLeaveDays")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalNoDays")
                        .HasColumnType("int");

                    b.HasKey("Leave_Id");

                    b.ToTable("Leave");
                });

            modelBuilder.Entity("Employee_Leaving.Models.Leave_Type", b =>
                {
                    b.Property<int>("LeaveType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveType_Id"), 1L, 1);

                    b.Property<string>("LeaveType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaveType_Id");

                    b.ToTable("LeaveTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
