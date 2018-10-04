﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Models;

namespace api.Migrations
{
    [DbContext(typeof(TimeishContext))]
    partial class TimeishContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.Property<int?>("TimesheetId");

                    b.HasKey("Id");

                    b.HasIndex("TimesheetId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("api.Models.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Approved");

                    b.Property<DateTime>("Issued");

                    b.Property<DateTime>("Submitted");

                    b.HasKey("Id");

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("api.Models.Activity", b =>
                {
                    b.HasOne("api.Models.Timesheet", "Timesheet")
                        .WithMany("Activities")
                        .HasForeignKey("TimesheetId");
                });
#pragma warning restore 612, 618
        }
    }
}