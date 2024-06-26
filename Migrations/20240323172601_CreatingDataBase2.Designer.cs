﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestLiveCode.Context;

#nullable disable

namespace TestLiveCode.Migrations
{
    [DbContext(typeof(DbContextExample))]
    [Migration("20240323172601_CreatingDataBase2")]
    partial class CreatingDataBase2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestLiveCode.Model.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("BIT")
                        .HasColumnName("ACTIVE");

                    b.Property<DateTime>("DateAdded")
                        .HasMaxLength(500)
                        .HasColumnType("DATETIME")
                        .HasColumnName("DATE_ADDED");

                    b.Property<bool>("IsTop500")
                        .HasColumnType("BIT")
                        .HasColumnName("IS_TOP_500");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("NAME");

                    b.Property<int>("TasksDone")
                        .HasColumnType("INT")
                        .HasColumnName("TASKS_DONE");

                    b.Property<int>("TasksToBeDone")
                        .HasColumnType("INT")
                        .HasColumnName("TASKS_TO_BE_DONE");

                    b.HasKey("ClientId")
                        .HasName("CLIENT_ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("TestLiveCode.Model.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("BIT")
                        .HasColumnName("ACTIVE");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("CLIENT_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<bool>("Done")
                        .HasColumnType("BIT")
                        .HasColumnName("DONE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("TicketId")
                        .HasName("TICKET_ID");

                    b.HasIndex("ClientId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("TestLiveCode.Model.Ticket", b =>
                {
                    b.HasOne("TestLiveCode.Model.Client", "Client")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TestLiveCode.Model.Client", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
