﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShiftLogger.Models;

#nullable disable

namespace ShiftLoggerAPI.Migrations.Shift
{
    [DbContext(typeof(ShiftContext))]
    [Migration("20230210211642_ShiftMigration")]
    partial class ShiftMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShiftLogger.Models.ShiftModel", b =>
                {
                    b.Property<int>("ShiftModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftModelId"), 1L, 1);

                    b.Property<DateTime>("EndOfShift")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartOfShift")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("ShiftModelId");

                    b.ToTable("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
