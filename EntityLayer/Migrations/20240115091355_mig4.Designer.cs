﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RabbitMQRead.AppContext;

#nullable disable

namespace EntityLayer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240115091355_mig4")]
    partial class mig4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RabbitMQRead.Entity.CallInformation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("External")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Internal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SipStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("CallInformations");
                });

            modelBuilder.Entity("RabbitMQRead.Entity.CallInformationDetailed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CallAnswered")
                        .HasColumnType("text");

                    b.Property<string>("CallEnded")
                        .HasColumnType("text");

                    b.Property<string>("CallId")
                        .HasColumnType("text");

                    b.Property<string>("CallStarted")
                        .HasColumnType("text");

                    b.Property<int>("CallType")
                        .HasColumnType("integer");

                    b.Property<string>("Chain")
                        .HasColumnType("text");

                    b.Property<string>("GatewayName")
                        .HasColumnType("text");

                    b.Property<string>("IsMakeCall")
                        .HasColumnType("text");

                    b.Property<string>("ReasonChanged")
                        .HasColumnType("text");

                    b.Property<string>("ReasonTerminated")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CallInformationDetaileds");
                });
#pragma warning restore 612, 618
        }
    }
}
