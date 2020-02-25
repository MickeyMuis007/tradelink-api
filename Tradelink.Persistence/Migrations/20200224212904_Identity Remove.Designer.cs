﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tradelink.Persistence.Context;

namespace Tradelink.Persistence.Migrations
{
    [DbContext(typeof(TradelinkContext))]
    [Migration("20200224212904_Identity Remove")]
    partial class IdentityRemove
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Tradelink.Domain.AggregateModels.RequestAggregate.Children.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Tradelink.Domain.AggregateModels.RequestAggregate.Children.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("Tradelink.Domain.AggregateModels.RequestAggregate.Children.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Tradelink.Domain.AggregateModels.RequestAggregate.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProviderId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Tradelink.Domain.AggregateModels.RequestAggregate.Children.Provider", b =>
                {
                    b.HasOne("Tradelink.Domain.AggregateModels.RequestAggregate.Children.Contact", "Contact")
                        .WithMany("Providers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Tradelink.Domain.AggregateModels.RequestAggregate.Children.Transaction", b =>
                {
                    b.HasOne("Tradelink.Domain.AggregateModels.RequestAggregate.Request", "Request")
                        .WithMany("Transactions")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Tradelink.Domain.AggregateModels.RequestAggregate.Request", b =>
                {
                    b.HasOne("Tradelink.Domain.AggregateModels.RequestAggregate.Children.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");
                });
#pragma warning restore 612, 618
        }
    }
}