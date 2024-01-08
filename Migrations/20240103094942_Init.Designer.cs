﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using event_managment_API.Data;

#nullable disable

namespace event_managment_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240103094942_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("event_managment_API.Models.Attendee", b =>
                {
                    b.Property<int>("AttendeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendeeId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttendeeId");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("event_managment_API.Models.AttendeeEvent", b =>
                {
                    b.Property<int>("AttendeeId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("AttendeeId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("AttendeeEvents");
                });

            modelBuilder.Entity("event_managment_API.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("event_managment_API.Models.AttendeeEvent", b =>
                {
                    b.HasOne("event_managment_API.Models.Attendee", "Attendee")
                        .WithMany("AttendeeEvents")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("event_managment_API.Models.Event", "Event")
                        .WithMany("AttendeeEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("event_managment_API.Models.Attendee", b =>
                {
                    b.Navigation("AttendeeEvents");
                });

            modelBuilder.Entity("event_managment_API.Models.Event", b =>
                {
                    b.Navigation("AttendeeEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
