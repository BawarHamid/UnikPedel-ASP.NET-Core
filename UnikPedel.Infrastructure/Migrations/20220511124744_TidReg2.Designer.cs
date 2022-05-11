﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnikPedel.Infrastructure.Database;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    [DbContext(typeof(UnikPedelContext))]
    [Migration("20220511124744_TidReg2")]
    partial class TidReg2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EjendomVicevært", b =>
                {
                    b.Property<Guid>("EjemdomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ViceværtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EjemdomId", "ViceværtId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("EjendomVicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("LejemålId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LejerLejemålId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SlutTid")
                        .HasColumnType("datetime2")
                        .HasColumnName("SlutTid");

                    b.Property<DateTime>("StartTid")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartTid");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("ViceværtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LejemålId");

                    b.HasIndex("LejerLejemålId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Ejendom", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("By");

                    b.Property<int>("BygningsNummer")
                        .HasColumnType("int")
                        .HasColumnName("BygningsNummer");

                    b.Property<int>("LandKode")
                        .HasColumnType("int")
                        .HasColumnName("LandKode");

                    b.Property<string>("PostNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PostNummer");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Region");

                    b.Property<string>("VejNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VejNavn");

                    b.HasKey("Id");

                    b.ToTable("Ejendom", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.EjendomsAnsvarlig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("EjendomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ViceværtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("EjendomsAnsvarlig", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejemål", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("AndenAdresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AndenAdresse");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("By");

                    b.Property<int>("BygningsNummer")
                        .HasColumnType("int")
                        .HasColumnName("BygningsNummer");

                    b.Property<Guid>("EjendomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EjendomId");

                    b.Property<bool>("IsBookable")
                        .HasColumnType("bit");

                    b.Property<string>("LandKode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LandKode");

                    b.Property<string>("PostNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PostNummer");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Region");

                    b.Property<string>("VejNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VejNavn");

                    b.HasKey("Id");

                    b.HasIndex("EjendomId");

                    b.ToTable("Lejemål", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejer", b =>
                {
                    b.Property<Guid>("LejemålId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("EfterNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EfterNavn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("ForNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ForNavn");

                    b.Property<DateTime>("IndDato")
                        .HasColumnType("datetime2")
                        .HasColumnName("IndDato");

                    b.Property<Guid>("LejemålId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MellemNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MellemNavn");

                    b.Property<int>("Telefon")
                        .HasColumnType("int")
                        .HasColumnName("Telefon");

                    b.Property<DateTime?>("UdDato")
                        .HasColumnType("datetime2")
                        .HasColumnName("UdDato");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("LejemålId");

                    b.HasIndex("LejemålId1");

                    b.ToTable("Lejer", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Rekvisition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Beskrivelse");

                    b.Property<Guid>("EjendomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LejerLejemålId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Status");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("TimeCreated");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("ViceværtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EjendomId");

                    b.HasIndex("LejerLejemålId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("Rekvisition", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.TidRegistering", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<double>("AntalTimer")
                        .HasColumnType("float")
                        .HasColumnName("AntalTimer");

                    b.Property<DateTime>("RegisterDato")
                        .HasColumnType("datetime2")
                        .HasColumnName("RegisterDato");

                    b.Property<Guid?>("RekvisitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ViceværtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RekvisitionId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("TidRegistrering", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Vicevært", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("EfterNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EfterNavn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("ForNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ForNavn");

                    b.Property<int>("Telefon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vicevært", (string)null);
                });

            modelBuilder.Entity("EjendomVicevært", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Ejendom", null)
                        .WithMany()
                        .HasForeignKey("EjemdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Vicevært", null)
                        .WithMany()
                        .HasForeignKey("ViceværtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Booking", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Lejemål", "Lejemål")
                        .WithMany("Bookings")
                        .HasForeignKey("LejemålId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Lejer", "Lejer")
                        .WithMany("Bookings")
                        .HasForeignKey("LejerLejemålId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Vicevært", "Vicevært")
                        .WithMany()
                        .HasForeignKey("ViceværtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lejemål");

                    b.Navigation("Lejer");

                    b.Navigation("Vicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Ejendom", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.EjendomsAnsvarlig", "EjendomsAnsvarlig")
                        .WithMany("Ejendom")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EjendomsAnsvarlig");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejemål", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Ejendom", "Ejendom")
                        .WithMany("Lejemål")
                        .HasForeignKey("EjendomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ejendom");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejer", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Lejemål", "Lejemål")
                        .WithMany("Lejer")
                        .HasForeignKey("LejemålId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lejemål");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Rekvisition", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Ejendom", "Ejendom")
                        .WithMany("Rekvisitioner")
                        .HasForeignKey("EjendomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Lejer", "Lejer")
                        .WithMany("Rekvisitioner")
                        .HasForeignKey("LejerLejemålId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Vicevært", "Vicevært")
                        .WithMany("Rekvisitioner")
                        .HasForeignKey("ViceværtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ejendom");

                    b.Navigation("Lejer");

                    b.Navigation("Vicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.TidRegistering", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Rekvisition", "Rekvisition")
                        .WithMany("TidRegistering")
                        .HasForeignKey("RekvisitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UnikPedel.Domain.Entities.Vicevært", "Vicevært")
                        .WithMany("TidRegistrering")
                        .HasForeignKey("ViceværtId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Rekvisition");

                    b.Navigation("Vicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Vicevært", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.EjendomsAnsvarlig", "EjendomsAnsvarlig")
                        .WithMany("Vicevært")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EjendomsAnsvarlig");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Ejendom", b =>
                {
                    b.Navigation("Lejemål");

                    b.Navigation("Rekvisitioner");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.EjendomsAnsvarlig", b =>
                {
                    b.Navigation("Ejendom");

                    b.Navigation("Vicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejemål", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Lejer");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Rekvisitioner");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Rekvisition", b =>
                {
                    b.Navigation("TidRegistering");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Vicevært", b =>
                {
                    b.Navigation("Rekvisitioner");

                    b.Navigation("TidRegistrering");
                });
#pragma warning restore 612, 618
        }
    }
}
