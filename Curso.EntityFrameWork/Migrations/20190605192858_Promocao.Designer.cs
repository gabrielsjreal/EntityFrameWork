﻿// <auto-generated />
using System;
using Curso.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Curso.EntityFrameWork.Migrations
{
    [DbContext(typeof(LojaContext))]
    [Migration("20190605192858_Promocao")]
    partial class Promocao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Curso.EntityFrameWork.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Preco");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Curso.EntityFrameWork.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria");

                    b.Property<string>("Nome");

                    b.Property<double>("PrecoUnitario");

                    b.Property<string>("Unidade");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Curso.EntityFrameWork.Promocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInicio");

                    b.Property<DateTime>("DataTermino");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("Curso.EntityFrameWork.PromocaoProduto", b =>
                {
                    b.Property<int>("PromocaoId");

                    b.Property<int>("ProdutoId");

                    b.HasKey("PromocaoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PromocaoProduto");
                });

            modelBuilder.Entity("Curso.EntityFrameWork.Compra", b =>
                {
                    b.HasOne("Curso.EntityFrameWork.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Curso.EntityFrameWork.PromocaoProduto", b =>
                {
                    b.HasOne("Curso.EntityFrameWork.Produto", "Produto")
                        .WithMany("Promocaos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Curso.EntityFrameWork.Promocao", "Promocao")
                        .WithMany("Produtos")
                        .HasForeignKey("PromocaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
