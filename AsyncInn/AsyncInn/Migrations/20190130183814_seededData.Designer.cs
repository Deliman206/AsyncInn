﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20190130183814_seededData")]
    partial class seededData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("AMENITIES");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Coffee Maker"
                        },
                        new
                        {
                            ID = 2,
                            Name = "TV"
                        },
                        new
                        {
                            ID = 3,
                            Name = "WiFi"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Bathroom Attire"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Mini Bar"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<long>("Phone");

                    b.HasKey("ID");

                    b.ToTable("HOTEL");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Seattle",
                            Name = "Hotel Seattle",
                            Phone = 2065556699L
                        },
                        new
                        {
                            ID = 2,
                            City = "Colorado Springs",
                            Name = "Hotel Springs",
                            Phone = 5095556699L
                        },
                        new
                        {
                            ID = 3,
                            City = "Paia",
                            Name = "Hotel Surf",
                            Phone = 8085556699L
                        },
                        new
                        {
                            ID = 4,
                            City = "Salem",
                            Name = "Hotel Magic",
                            Phone = 2065556699L
                        },
                        new
                        {
                            ID = 5,
                            City = "Las Vegas",
                            Name = "Hotel Risk",
                            Phone = 2065556699L
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomID");

                    b.Property<byte>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<decimal>("RoomNumber");

                    b.HasKey("HotelID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("HOTELROOM");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ROOM");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "The Pad"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 0,
                            Name = "Relax and Meditate"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 1,
                            Name = "The Get Away"
                        },
                        new
                        {
                            ID = 4,
                            Layout = 1,
                            Name = "Comfy Office"
                        },
                        new
                        {
                            ID = 5,
                            Layout = 2,
                            Name = "Family Snoozer"
                        },
                        new
                        {
                            ID = 6,
                            Layout = 2,
                            Name = "Party Room"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("AmenitiesID");

                    b.HasKey("RoomID", "AmenitiesID");

                    b.HasIndex("AmenitiesID");

                    b.ToTable("ROOMAMENITIES");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
