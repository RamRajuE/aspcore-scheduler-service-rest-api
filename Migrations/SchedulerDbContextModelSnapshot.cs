﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using schedule_aspcore_service.Data;

#nullable disable

namespace aspcore_scheduler_service_web_api.Migrations
{
    [DbContext(typeof(SchedulerDbContext))]
    partial class SchedulerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("schedule_aspcore_service.Models.ScheduleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndTimezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FollowingID")
                        .HasColumnType("int");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsAllDay")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsBlock")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsReadOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("RecurrenceException")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecurrenceID")
                        .HasColumnType("int");

                    b.Property<string>("RecurrenceRule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTimezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ScheduleTableAspCore");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Subject = "Intial item"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
