﻿// <auto-generated />
using System;
using Application.DbClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Presistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210217180507_ChangedDatatype")]
    partial class ChangedDatatype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.BubbleDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BubbleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BubbleMeetDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("BubbleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BubbleSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BubbleType")
                        .HasColumnType("int");

                    b.Property<DateTime>("BubbleValidity")
                        .HasColumnType("datetime2");

                    b.Property<string>("BubbleZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOtherCountyMemberAllowed")
                        .HasColumnType("bit");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BubbleMeetDetailsId");

                    b.ToTable("bubbleDetails");
                });

            modelBuilder.Entity("Domain.Entities.BubbleMeetDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowChat")
                        .HasColumnType("bit");

                    b.Property<int?>("BubbleId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeetDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetTiming")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserPermission")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BubbleId");

                    b.ToTable("bubbleMeetDetails");
                });

            modelBuilder.Entity("Domain.Entities.OtpHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OtpStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OtpTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("otpHistory");
                });

            modelBuilder.Entity("Domain.Entities.UserDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("userDetails");
                });

            modelBuilder.Entity("Domain.Entities.BubbleDetails", b =>
                {
                    b.HasOne("Domain.Entities.BubbleMeetDetails", null)
                        .WithMany("ChooseBubble")
                        .HasForeignKey("BubbleMeetDetailsId");
                });

            modelBuilder.Entity("Domain.Entities.BubbleMeetDetails", b =>
                {
                    b.HasOne("Domain.Entities.BubbleDetails", "BubbleDetails")
                        .WithMany()
                        .HasForeignKey("BubbleId");

                    b.Navigation("BubbleDetails");
                });

            modelBuilder.Entity("Domain.Entities.BubbleMeetDetails", b =>
                {
                    b.Navigation("ChooseBubble");
                });
#pragma warning restore 612, 618
        }
    }
}
