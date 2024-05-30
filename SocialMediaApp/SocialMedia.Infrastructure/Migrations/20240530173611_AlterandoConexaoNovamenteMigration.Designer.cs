﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMedia.Infrastructure.Persistence;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    [DbContext(typeof(SocialMediaDbContext))]
    [Migration("20240530173611_AlterandoConexaoNovamenteMigration")]
    partial class AlterandoConexaoNovamenteMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialMedia.Core.Entities.Conexao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataConexao")
                        .HasColumnType("datetime");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<int>("IdPerfilSeguido")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfil");

                    b.HasIndex("IdPerfilSeguido");

                    b.ToTable("Conexao", (string)null);
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .HasDatabaseName("IX_Conta_Email");

                    b.ToTable("Conta", (string)null);
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NomeExibicao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sobre")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdConta");

                    b.ToTable("Perfil", (string)null);
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Publicacao", (string)null);
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Conexao", b =>
                {
                    b.HasOne("SocialMedia.Core.Entities.Perfil", "Perfil")
                        .WithMany("ConexoesPerfil")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialMedia.Core.Entities.Perfil", "PerfilSeguido")
                        .WithMany("ConexoesPerfilSeguido")
                        .HasForeignKey("IdPerfilSeguido")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("PerfilSeguido");
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Perfil", b =>
                {
                    b.HasOne("SocialMedia.Core.Entities.Conta", "Conta")
                        .WithMany("Perfis")
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Publicacao", b =>
                {
                    b.HasOne("SocialMedia.Core.Entities.Perfil", "Perfil")
                        .WithMany("Publicacoes")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Conta", b =>
                {
                    b.Navigation("Perfis");
                });

            modelBuilder.Entity("SocialMedia.Core.Entities.Perfil", b =>
                {
                    b.Navigation("ConexoesPerfil");

                    b.Navigation("ConexoesPerfilSeguido");

                    b.Navigation("Publicacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
