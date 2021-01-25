﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prepaid_Mobile_Topup_MVC.Data;

namespace Prepaid_Mobile_Topup_MVC.Migrations
{
    [DbContext(typeof(Prepaid_Mobile_Topup_MVCContext))]
    [Migration("20210125023745_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prepaid_Mobile_Topup_MVC.Models.MobileAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrepaidCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrepaidCustomerId");

                    b.ToTable("MobileAccount");
                });

            modelBuilder.Entity("Prepaid_Mobile_Topup_MVC.Models.PrepaidCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistereddDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PrepaidCustomer");
                });

            modelBuilder.Entity("Prepaid_Mobile_Topup_MVC.Models.TopUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MobileAccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("TopUpAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TopUpChannelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MobileAccountId");

                    b.HasIndex("TopUpChannelId");

                    b.ToTable("TopUp");
                });

            modelBuilder.Entity("Prepaid_Mobile_Topup_MVC.Models.TopUpChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TopUpChannel");
                });

            modelBuilder.Entity("Prepaid_Mobile_Topup_MVC.Models.MobileAccount", b =>
                {
                    b.HasOne("Prepaid_Mobile_Topup_MVC.Models.PrepaidCustomer", "PrepaidCustomer")
                        .WithMany()
                        .HasForeignKey("PrepaidCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prepaid_Mobile_Topup_MVC.Models.TopUp", b =>
                {
                    b.HasOne("Prepaid_Mobile_Topup_MVC.Models.MobileAccount", "MobileAccount")
                        .WithMany()
                        .HasForeignKey("MobileAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prepaid_Mobile_Topup_MVC.Models.TopUpChannel", "TopUpChannel")
                        .WithMany()
                        .HasForeignKey("TopUpChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
