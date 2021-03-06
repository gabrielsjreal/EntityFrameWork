﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.EntityFrameWork
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        // método usado para a classe "Join" PromocaoProduto - Chave estrangeira Composta
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add esse comando, os outros comando desse método foram gerados automaticamente
            modelBuilder.Entity<PromocaoProduto>().HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            // usei esses comandos abaixos para não ter que instanciar na classe "ENDERECO", o atributo "ClienteId", que também funcionaria.
            modelBuilder.Entity<Endereco>().ToTable("Enderecos");

            modelBuilder.Entity<Endereco>().Property<int>("ClienteId");

            modelBuilder.Entity<Endereco>().HasKey("ClienteId");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");

        }
    }
}
