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
    [Migration("20220518205243_EjendomsAnsvarligidnew")]
    partial class EjendomsAnsvarligidnew
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
                    b.Property<int>("EjemdomId")
                        .HasColumnType("int");

                    b.Property<int>("ViceværtId")
                        .HasColumnType("int");

                    b.HasKey("EjemdomId", "ViceværtId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("EjendomVicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LejemålId")
                        .HasColumnType("int");

                    b.Property<int>("LejerId")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.HasIndex("LejemålId");

                    b.HasIndex("LejerId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Ejendom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EjendomId")
                        .HasColumnType("int");

                    b.Property<int>("ViceværtId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EjendomId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("EjendomsAnsvarlig", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejemål", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<int>("EjendomId")
                        .HasColumnType("int")
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

                    b.Property<int?>("RekvisitionId")
                        .HasColumnType("int");

                    b.Property<string>("VejNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VejNavn");

                    b.HasKey("Id");

                    b.HasIndex("EjendomId");

                    b.HasIndex("RekvisitionId");

                    b.ToTable("Lejemål", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<int>("LejemålId")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.HasIndex("LejemålId")
                        .IsUnique();

                    b.ToTable("Lejer", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Rekvisition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Beskrivelse");

                    b.Property<int>("EjendomId")
                        .HasColumnType("int");

                    b.Property<int>("LejerId")
                        .HasColumnType("int");

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

                    b.Property<int>("ViceværtId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EjendomId");

                    b.HasIndex("LejerId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("Rekvisition", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.TidRegistering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AntalTimer")
                        .HasColumnType("float")
                        .HasColumnName("AntalTimer");

                    b.Property<DateTime>("RegisterDato")
                        .HasColumnType("datetime2")
                        .HasColumnName("RegisterDato");

                    b.Property<int?>("RekvisitionId")
                        .HasColumnType("int");

                    b.Property<int?>("ViceværtId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RekvisitionId");

                    b.HasIndex("ViceværtId");

                    b.ToTable("TidRegistrering", (string)null);
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Vicevært", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Lejer", "Lejer")
                        .WithMany("Bookings")
                        .HasForeignKey("LejerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lejemål");

                    b.Navigation("Lejer");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.EjendomsAnsvarlig", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Ejendom", "Ejendom")
                        .WithMany("EjendomsAnsvarlig")
                        .HasForeignKey("EjendomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Vicevært", "Vicevært")
                        .WithMany("EjendomsAnsvarlig")
                        .HasForeignKey("ViceværtId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ejendom");

                    b.Navigation("Vicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejemål", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Ejendom", "Ejendom")
                        .WithMany("Lejemål")
                        .HasForeignKey("EjendomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Rekvisition", null)
                        .WithMany("Lejemål")
                        .HasForeignKey("RekvisitionId");

                    b.Navigation("Ejendom");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejer", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Lejemål", "Lejemål")
                        .WithOne("Lejer")
                        .HasForeignKey("UnikPedel.Domain.Entities.Lejer", "LejemålId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lejemål");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Rekvisition", b =>
                {
                    b.HasOne("UnikPedel.Domain.Entities.Ejendom", "Ejendom")
                        .WithMany("Rekvisitioner")
                        .HasForeignKey("EjendomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Lejer", "Lejer")
                        .WithMany("Rekvisitioner")
                        .HasForeignKey("LejerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UnikPedel.Domain.Entities.Vicevært", "Vicevært")
                        .WithMany("Rekvisitioner")
                        .HasForeignKey("ViceværtId")
                        .OnDelete(DeleteBehavior.NoAction)
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
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Rekvisition");

                    b.Navigation("Vicevært");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Ejendom", b =>
                {
                    b.Navigation("EjendomsAnsvarlig");

                    b.Navigation("Lejemål");

                    b.Navigation("Rekvisitioner");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejemål", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Lejer")
                        .IsRequired();
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Lejer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Rekvisitioner");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Rekvisition", b =>
                {
                    b.Navigation("Lejemål");

                    b.Navigation("TidRegistering");
                });

            modelBuilder.Entity("UnikPedel.Domain.Entities.Vicevært", b =>
                {
                    b.Navigation("EjendomsAnsvarlig");

                    b.Navigation("Rekvisitioner");

                    b.Navigation("TidRegistrering");
                });
#pragma warning restore 612, 618
        }
    }
}
