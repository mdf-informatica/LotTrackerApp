﻿// <auto-generated />
using System;
using LotTrackerApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LotTrackerApp.Migrations
{
    [DbContext(typeof(LoteTrackerDbContext))]
    partial class LoteTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LotTrackerApp.Data.Entities.Pais", b =>
                {
                    b.Property<string>("CodPais")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodPais");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("LotTrackerApp.Data.Entities.Produto", b =>
                {
                    b.Property<string>("CodProduto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Familia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LotTrackerApp.Data.Entities.ProdutoFabricante", b =>
                {
                    b.Property<string>("Produto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fabricante")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisCodPais")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Produto", "Fabricante");

                    b.HasIndex("PaisCodPais");

                    b.ToTable("ProdutoFabricante");
                });

            modelBuilder.Entity("LotTrackerApp.Data.Entities.ProdutoLote", b =>
                {
                    b.Property<string>("Produto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Lote")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DtFabrico")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fabricante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Produto", "Lote");

                    b.ToTable("ProdutoLote");
                });

            modelBuilder.Entity("LotTrackerApp.Data.Entities.ProdutoFabricante", b =>
                {
                    b.HasOne("LotTrackerApp.Data.Entities.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisCodPais");

                    b.Navigation("Pais");
                });
#pragma warning restore 612, 618
        }
    }
}
