﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tradelink.Persistence.Context;

namespace Tradelink.Persistence.Migrations
{
    [DbContext(typeof(TradelinkContext))]
    [Migration("20200202204554_Tradelink-Migration")]
    partial class TradelinkMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Tradelink.Persistence.Models.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint(20)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<ulong>("Enabled")
                        .HasColumnName("enabled")
                        .HasColumnType("bit(1)");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("UK_r43af9ap4edm43mmtq01oddj6");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
