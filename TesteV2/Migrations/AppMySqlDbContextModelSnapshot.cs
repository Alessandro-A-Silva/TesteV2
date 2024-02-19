﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteV2.Data.Contexts;

#nullable disable

namespace TesteV2.Migrations
{
    [DbContext(typeof(AppMySqlDbContext))]
    partial class AppMySqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TesteV2.Entities.Contatos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contato")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("PessoasFisicasId")
                        .HasColumnType("int");

                    b.Property<string>("TipoContato")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PessoasFisicasId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("TesteV2.Entities.Enderecos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PessoasFisicasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoasFisicasId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("TesteV2.Entities.PessoasFisicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .HasColumnType("longtext");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PessoasFisicas");
                });

            modelBuilder.Entity("TesteV2.Entities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("longblob");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TesteV2.Entities.Contatos", b =>
                {
                    b.HasOne("TesteV2.Entities.PessoasFisicas", "PessoaFisica")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoasFisicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("TesteV2.Entities.Enderecos", b =>
                {
                    b.HasOne("TesteV2.Entities.PessoasFisicas", "PessoaFisica")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoasFisicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("TesteV2.Entities.PessoasFisicas", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}