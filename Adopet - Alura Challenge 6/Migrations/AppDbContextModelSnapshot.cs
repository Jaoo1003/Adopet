﻿// <auto-generated />
using System;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Adopet___Alura_Challenge_6.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Abrigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Abrigos");
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Adocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.HasIndex("TutorId");

                    b.ToTable("Adocoes");
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AbrigoId")
                        .HasColumnType("int");

                    b.Property<bool>("Adotado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Personalidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Porte")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AbrigoId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tutores");
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Adocao", b =>
                {
                    b.HasOne("Adopet___Alura_Challenge_6.Models.Pet", "Pet")
                        .WithOne("Adocao")
                        .HasForeignKey("Adopet___Alura_Challenge_6.Models.Adocao", "PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adopet___Alura_Challenge_6.Models.Tutor", "Tutor")
                        .WithMany("Adocao")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Pet", b =>
                {
                    b.HasOne("Adopet___Alura_Challenge_6.Models.Abrigo", "Abrigo")
                        .WithMany("Pets")
                        .HasForeignKey("AbrigoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abrigo");
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Abrigo", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Pet", b =>
                {
                    b.Navigation("Adocao")
                        .IsRequired();
                });

            modelBuilder.Entity("Adopet___Alura_Challenge_6.Models.Tutor", b =>
                {
                    b.Navigation("Adocao");
                });
#pragma warning restore 612, 618
        }
    }
}
