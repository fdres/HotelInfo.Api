﻿// <auto-generated />

using System;
using HotelInfo.Api.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelInfo.Api.DAL.Migrations
{
    [DbContext(typeof(HotelInfoContext))]
    partial class HotelInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelInfo.Dal.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("HotelId");

                    b.Property<short>("PaxNumber");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Booking");

                    b.HasData(
                        new
                        {
                            Id = new Guid("20790ead-e580-42db-af4e-54c126a02a7e"),
                            CustomerName = "Hans",
                            CustomerSurname = "Gruber",
                            HotelId = new Guid("45199a17-0d92-4c55-bcf9-1c9c99c931f1"),
                            PaxNumber = (short)2
                        },
                        new
                        {
                            Id = new Guid("c45ab61c-f957-4f14-8f86-e83f81829238"),
                            CustomerName = "John",
                            CustomerSurname = "McLane",
                            HotelId = new Guid("45199a17-0d92-4c55-bcf9-1c9c99c931f1"),
                            PaxNumber = (short)4
                        },
                        new
                        {
                            Id = new Guid("d60fbaec-00b5-409a-aa1c-46c969e6bfb1"),
                            CustomerName = "Han",
                            CustomerSurname = "Solo",
                            HotelId = new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"),
                            PaxNumber = (short)1
                        },
                        new
                        {
                            Id = new Guid("37bd242d-b39f-4593-9142-3614357a58c4"),
                            CustomerName = "Luke",
                            CustomerSurname = "Skywalker",
                            HotelId = new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"),
                            PaxNumber = (short)3
                        },
                        new
                        {
                            Id = new Guid("55852b8f-6bc9-4b2e-9768-8d918d2ac09e"),
                            CustomerName = "Leia",
                            CustomerSurname = "Organa",
                            HotelId = new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"),
                            PaxNumber = (short)1
                        },
                        new
                        {
                            Id = new Guid("6ebc2ce2-8efb-41ae-ac21-539c4e3e8433"),
                            CustomerName = "Darth",
                            CustomerSurname = "Vader",
                            HotelId = new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"),
                            PaxNumber = (short)1
                        },
                        new
                        {
                            Id = new Guid("3899fb02-83c3-46a7-8c4f-a1167a56a95d"),
                            CustomerName = "-",
                            CustomerSurname = "Count Dracula",
                            HotelId = new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"),
                            PaxNumber = (short)2
                        },
                        new
                        {
                            Id = new Guid("f4945645-1ddb-4e2e-9a33-845562e8ad3c"),
                            CustomerName = "-",
                            CustomerSurname = "Frankenstein's Monster",
                            HotelId = new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"),
                            PaxNumber = (short)2
                        },
                        new
                        {
                            Id = new Guid("cf4b082c-377c-4afd-baf7-038fac25c4fe"),
                            CustomerName = "-",
                            CustomerSurname = "The Wolfman",
                            HotelId = new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"),
                            PaxNumber = (short)12
                        },
                        new
                        {
                            Id = new Guid("fe04cf9b-04d0-42d4-89e9-9233a314b82f"),
                            CustomerName = "Jack",
                            CustomerSurname = "Skellington",
                            HotelId = new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"),
                            PaxNumber = (short)1
                        });
                });

            modelBuilder.Entity("HotelInfo.Dal.Entities.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double?>("StarRating");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            Id = new Guid("45199a17-0d92-4c55-bcf9-1c9c99c931f1"),
                            Address = "Los Angeles, CA 90067, USA",
                            Description = "The one with the heist and all the murdering during Christmas '88",
                            Name = "Nakatomi Tower Plaza",
                            StarRating = 5.0
                        },
                        new
                        {
                            Id = new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"),
                            Address = "Second cloud on the left, Cloud City, Bespin System",
                            Description = "The one where Darth Vader captured Han Solo and met with his son for the first time",
                            Name = "Cloud City Inn",
                            StarRating = 2.0
                        },
                        new
                        {
                            Id = new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"),
                            Address = "Somewhere in the transylvanian mountains, Romania",
                            Description = "The one where all the \"monsters\" gather to just relax and have some fun",
                            Name = "Hotel Transylvania",
                            StarRating = 4.0
                        });
                });

            modelBuilder.Entity("HotelInfo.Dal.Entities.Booking", b =>
                {
                    b.HasOne("HotelInfo.Dal.Entities.Hotel", "Hotel")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
