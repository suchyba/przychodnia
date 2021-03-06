﻿// <auto-generated />
using System;
using Bazy_Danych.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bazy_Danych.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20201209153434_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Bazy_Danych.Model.Adres", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Kod_pocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nr_domu")
                        .HasColumnType("int");

                    b.Property<int?>("Nr_mieszkania")
                        .HasColumnType("int");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Adresy");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Lek", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Dawkowanie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa_leku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Leki");
                });

            modelBuilder.Entity("Bazy_Danych.Model.LekRecepta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Lek")
                        .HasColumnType("int");

                    b.Property<int>("Recepta")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Lek");

                    b.HasIndex("Recepta");

                    b.ToTable("LekRecepta");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Lekarz", b =>
                {
                    b.Property<long>("PESEL")
                        .HasColumnType("bigint");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specjalizacja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("adresID")
                        .HasColumnType("int");

                    b.HasKey("PESEL");

                    b.HasIndex("adresID");

                    b.ToTable("Lekarze");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Pacjent", b =>
                {
                    b.Property<long>("PESEL")
                        .HasColumnType("bigint");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("adresID")
                        .HasColumnType("int");

                    b.HasKey("PESEL");

                    b.HasIndex("adresID");

                    b.ToTable("Pacjeci");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Pielegniarka", b =>
                {
                    b.Property<long>("PESEL")
                        .HasColumnType("bigint");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("adresID")
                        .HasColumnType("int");

                    b.HasKey("PESEL");

                    b.HasIndex("adresID");

                    b.ToTable("Pielegniarki");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Recepta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("lekarzPESEL")
                        .HasColumnType("bigint");

                    b.Property<long>("pacjentPESEL")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("lekarzPESEL");

                    b.HasIndex("pacjentPESEL");

                    b.ToTable("Recepty");
                });

            modelBuilder.Entity("Bazy_Danych.Model.RodzajZabiegu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("RodzajeZabiegow");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Skierowanie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data_wygasniecia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nazwa_zabiegu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("adresID")
                        .HasColumnType("int");

                    b.Property<long>("lekarzPESEL")
                        .HasColumnType("bigint");

                    b.Property<long>("pacjentPESEL")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("adresID");

                    b.HasIndex("lekarzPESEL");

                    b.HasIndex("pacjentPESEL");

                    b.ToTable("Skierowania");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Wizyta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("lekarzPESEL")
                        .HasColumnType("bigint");

                    b.Property<long>("pacjentPESEL")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("lekarzPESEL");

                    b.HasIndex("pacjentPESEL");

                    b.ToTable("Wizyty");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Zabieg", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<long>("lekarzPESEL")
                        .HasColumnType("bigint");

                    b.Property<long>("pacjentPESEL")
                        .HasColumnType("bigint");

                    b.Property<long>("pielegniarkaPESEL")
                        .HasColumnType("bigint");

                    b.Property<int?>("rodzajZabieguID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("lekarzPESEL");

                    b.HasIndex("pacjentPESEL");

                    b.HasIndex("pielegniarkaPESEL");

                    b.HasIndex("rodzajZabieguID");

                    b.ToTable("Zabiegi");
                });

            modelBuilder.Entity("Bazy_Danych.Model.LekRecepta", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Lek", "lek")
                        .WithMany("recepty")
                        .HasForeignKey("Lek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazy_Danych.Model.Recepta", "recepta")
                        .WithMany("leki")
                        .HasForeignKey("Recepta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lek");

                    b.Navigation("recepta");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Lekarz", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Adres", "adres")
                        .WithMany()
                        .HasForeignKey("adresID");

                    b.Navigation("adres");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Pacjent", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Adres", "adres")
                        .WithMany()
                        .HasForeignKey("adresID");

                    b.Navigation("adres");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Pielegniarka", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Adres", "adres")
                        .WithMany()
                        .HasForeignKey("adresID");

                    b.Navigation("adres");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Recepta", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Lekarz", "lekarz")
                        .WithMany("recepty")
                        .HasForeignKey("lekarzPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazy_Danych.Model.Pacjent", "pacjent")
                        .WithMany("recepty")
                        .HasForeignKey("pacjentPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lekarz");

                    b.Navigation("pacjent");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Skierowanie", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Adres", "adres")
                        .WithMany()
                        .HasForeignKey("adresID");

                    b.HasOne("Bazy_Danych.Model.Lekarz", "lekarz")
                        .WithMany("skierowania")
                        .HasForeignKey("lekarzPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazy_Danych.Model.Pacjent", "pacjent")
                        .WithMany("skierowanie")
                        .HasForeignKey("pacjentPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adres");

                    b.Navigation("lekarz");

                    b.Navigation("pacjent");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Wizyta", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Lekarz", "lekarz")
                        .WithMany("wizyty")
                        .HasForeignKey("lekarzPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazy_Danych.Model.Pacjent", "pacjent")
                        .WithMany("wizyty")
                        .HasForeignKey("pacjentPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lekarz");

                    b.Navigation("pacjent");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Zabieg", b =>
                {
                    b.HasOne("Bazy_Danych.Model.Lekarz", "lekarz")
                        .WithMany("zabiegi")
                        .HasForeignKey("lekarzPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazy_Danych.Model.Pacjent", "pacjent")
                        .WithMany("zabiegi")
                        .HasForeignKey("pacjentPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazy_Danych.Model.Pielegniarka", "pielegniarka")
                        .WithMany("zabiegi")
                        .HasForeignKey("pielegniarkaPESEL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazy_Danych.Model.RodzajZabiegu", "rodzajZabiegu")
                        .WithMany()
                        .HasForeignKey("rodzajZabieguID");

                    b.Navigation("lekarz");

                    b.Navigation("pacjent");

                    b.Navigation("pielegniarka");

                    b.Navigation("rodzajZabiegu");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Lek", b =>
                {
                    b.Navigation("recepty");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Lekarz", b =>
                {
                    b.Navigation("recepty");

                    b.Navigation("skierowania");

                    b.Navigation("wizyty");

                    b.Navigation("zabiegi");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Pacjent", b =>
                {
                    b.Navigation("recepty");

                    b.Navigation("skierowanie");

                    b.Navigation("wizyty");

                    b.Navigation("zabiegi");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Pielegniarka", b =>
                {
                    b.Navigation("zabiegi");
                });

            modelBuilder.Entity("Bazy_Danych.Model.Recepta", b =>
                {
                    b.Navigation("leki");
                });
#pragma warning restore 612, 618
        }
    }
}
