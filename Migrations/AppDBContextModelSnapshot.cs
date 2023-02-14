﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OwlNews.Data;

#nullable disable

namespace OwlNews.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OwlNews.Models.Cherkassy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("cherkassy1");
                });

            modelBuilder.Entity("OwlNews.Models.Chernihiv", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("chernihiv1");
                });

            modelBuilder.Entity("OwlNews.Models.Chernvivtsi", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("chernivtsi1");
                });

            modelBuilder.Entity("OwlNews.Models.Dnipro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("dnipropetrovsk1");
                });

            modelBuilder.Entity("OwlNews.Models.Ivano_Frankivsk", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("ivano_frankivsk1");
                });

            modelBuilder.Entity("OwlNews.Models.Kharkiv", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("kharkiv1");
                });

            modelBuilder.Entity("OwlNews.Models.Kherson", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("kherson1");
                });

            modelBuilder.Entity("OwlNews.Models.Khmelnytskyi", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("khmelnytskyi1");
                });

            modelBuilder.Entity("OwlNews.Models.Kirovohrad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("kirovohradsk1");
                });

            modelBuilder.Entity("OwlNews.Models.Kryvyi_Rih", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("kryvyi_rih1");
                });

            modelBuilder.Entity("OwlNews.Models.Kyiv", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("kyiv1");
                });

            modelBuilder.Entity("OwlNews.Models.Luhansk", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("luhansk1");
                });

            modelBuilder.Entity("OwlNews.Models.Lviv", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("lviv1");
                });

            modelBuilder.Entity("OwlNews.Models.Mykolayiv", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("mykolayiv1");
                });

            modelBuilder.Entity("OwlNews.Models.Odesa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("odesa1");
                });

            modelBuilder.Entity("OwlNews.Models.Poltava", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("poltava1");
                });

            modelBuilder.Entity("OwlNews.Models.Rivne", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("rivne1");
                });

            modelBuilder.Entity("OwlNews.Models.Sumy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("sumy1");
                });

            modelBuilder.Entity("OwlNews.Models.Ternopil", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("ternopil1");
                });

            modelBuilder.Entity("OwlNews.Models.Vinnytsia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("vinnytsia1");
                });

            modelBuilder.Entity("OwlNews.Models.Volyn", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("volyn1");
                });

            modelBuilder.Entity("OwlNews.Models.Zakarapattia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("zakarpattia1");
                });

            modelBuilder.Entity("OwlNews.Models.Zaporizhzhia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("zaporizhzhia1");
                });

            modelBuilder.Entity("OwlNews.Models.Zhytomyr", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("info")
                        .HasColumnType("text");

                    b.Property<string>("link")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("zhytomyr1");
                });
#pragma warning restore 612, 618
        }
    }
}
