﻿// <auto-generated />
using System;
using Housematica.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Housematica.Data.Migrations
{
    [DbContext(typeof(HousematicaContext))]
    [Migration("20220113090725_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Housematica.Data.Data.CMS.Apartment", b =>
                {
                    b.Property<int>("IdApartment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdProjects")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdApartment");

                    b.HasIndex("IdProjects");

                    b.ToTable("Apartment");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ApartmentOption", b =>
                {
                    b.Property<int>("IdApartmentOption")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdApartment")
                        .HasColumnType("int");

                    b.Property<string>("OptionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("IdApartmentOption");

                    b.HasIndex("IdApartment");

                    b.ToTable("ApartmentOption");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ApartmentVariants", b =>
                {
                    b.Property<int>("IdApartmentVariants")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("ApartmentArea")
                        .HasColumnType("real");

                    b.Property<string>("ApartmentModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ApartmentPrice")
                        .HasColumnType("real");

                    b.Property<float>("BalconyArea")
                        .HasColumnType("real");

                    b.Property<int>("IdApartment")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLivingRoom")
                        .HasColumnType("int");

                    b.HasKey("IdApartmentVariants");

                    b.HasIndex("IdApartment");

                    b.ToTable("ApartmentVariants");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Features.Notification", b =>
                {
                    b.Property<int>("IdNotifcation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdNotifcation");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.House", b =>
                {
                    b.Property<int>("IdHouse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdProjects")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfFloor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHouse");

                    b.HasIndex("IdProjects");

                    b.ToTable("House");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.HouseOption", b =>
                {
                    b.Property<int>("IdHouseOption")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdHouse")
                        .HasColumnType("int");

                    b.Property<string>("OptionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("IdHouseOption");

                    b.HasIndex("IdHouse");

                    b.ToTable("HouseOption");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.HouseRooms", b =>
                {
                    b.Property<int>("IdHouseRoom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdHouseVariants")
                        .HasColumnType("int");

                    b.Property<float>("RoomArea")
                        .HasColumnType("real");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHouseRoom");

                    b.HasIndex("IdHouseVariants");

                    b.ToTable("HouseRooms");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.HouseVariants", b =>
                {
                    b.Property<int>("IdHouseVariant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("BalconyArea")
                        .HasColumnType("real");

                    b.Property<float>("HouseArea")
                        .HasColumnType("real");

                    b.Property<string>("HouseModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("HousePrice")
                        .HasColumnType("real");

                    b.Property<int>("IdHouse")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLivingRoom")
                        .HasColumnType("int");

                    b.Property<float>("TerraceArea")
                        .HasColumnType("real");

                    b.HasKey("IdHouseVariant");

                    b.HasIndex("IdHouse");

                    b.ToTable("HouseVariants");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.License", b =>
                {
                    b.Property<Guid>("IdLicense")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expire")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLicenseType")
                        .HasColumnType("int");

                    b.HasKey("IdLicense");

                    b.HasIndex("IdLicenseType");

                    b.ToTable("License");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.LicenseType", b =>
                {
                    b.Property<int>("IdLicenseType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDemo")
                        .HasColumnType("bit");

                    b.Property<string>("LicenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectAmount")
                        .HasColumnType("int");

                    b.Property<bool>("SettingsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UserAmount")
                        .HasColumnType("int");

                    b.Property<int>("VariantAmount")
                        .HasColumnType("int");

                    b.HasKey("IdLicenseType");

                    b.ToTable("LicenseType");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectType", b =>
                {
                    b.Property<int>("IdProjectType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConfiguratorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProjectType");

                    b.ToTable("ProjectType");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Projects", b =>
                {
                    b.Property<Guid>("IdProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdProjectType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsValidate")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectAdress1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectAdress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectPostcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProject");

                    b.HasIndex("IdProjectType");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectsContact", b =>
                {
                    b.Property<int>("IdProjectsContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdProjects")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OwnerAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProjectsContact");

                    b.HasIndex("IdProjects")
                        .IsUnique();

                    b.ToTable("ProjectsContacts");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectsLicense", b =>
                {
                    b.Property<int>("IdProjectsLicens")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("IdLicense")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProject")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProjectsLicens");

                    b.HasIndex("IdLicense");

                    b.HasIndex("IdProject");

                    b.ToTable("ProjectsLicense");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectsUser", b =>
                {
                    b.Property<int>("IdProjectsUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("IdProject")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProjectsUser");

                    b.HasIndex("IdProject");

                    b.HasIndex("IdUser");

                    b.ToTable("ProjectsUser");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Rooms", b =>
                {
                    b.Property<int>("IdRoom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdApartmentVariants")
                        .HasColumnType("int");

                    b.Property<float>("RoomArea")
                        .HasColumnType("real");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRoom");

                    b.HasIndex("IdApartmentVariants");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.SavedConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConfigurationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfigurationValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedConfigurationKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SavedConfiguration");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Single", b =>
                {
                    b.Property<Guid>("SingleGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AreaBuild")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdProjects")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfFloor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SingleGuid");

                    b.HasIndex("IdProjects");

                    b.ToTable("Single");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.SingleFloor", b =>
                {
                    b.Property<int>("IdSingleFloor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("BalconyArea")
                        .HasColumnType("real");

                    b.Property<float>("FloorArea")
                        .HasColumnType("real");

                    b.Property<string>("FloorModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloorPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FloorType")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdSingle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfLivingRoom")
                        .HasColumnType("int");

                    b.Property<float>("TerraceArea")
                        .HasColumnType("real");

                    b.HasKey("IdSingleFloor");

                    b.HasIndex("IdSingle");

                    b.ToTable("SingleFloor");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.SingleRooms", b =>
                {
                    b.Property<int>("IdSingleRoom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdSingleFloors")
                        .HasColumnType("int");

                    b.Property<float>("RoomArea")
                        .HasColumnType("real");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSingleRoom");

                    b.HasIndex("IdSingleFloors");

                    b.ToTable("SingleRooms");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Statistics.TotalConfiguration", b =>
                {
                    b.Property<int>("idTotalConfiguration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("April")
                        .HasColumnType("int");

                    b.Property<int>("August")
                        .HasColumnType("int");

                    b.Property<int>("December")
                        .HasColumnType("int");

                    b.Property<int>("February")
                        .HasColumnType("int");

                    b.Property<Guid>("IdProjects")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("January")
                        .HasColumnType("int");

                    b.Property<int>("July")
                        .HasColumnType("int");

                    b.Property<int>("June")
                        .HasColumnType("int");

                    b.Property<int>("March")
                        .HasColumnType("int");

                    b.Property<int>("May")
                        .HasColumnType("int");

                    b.Property<int>("November")
                        .HasColumnType("int");

                    b.Property<int>("October")
                        .HasColumnType("int");

                    b.Property<int>("September")
                        .HasColumnType("int");

                    b.HasKey("idTotalConfiguration");

                    b.HasIndex("IdProjects")
                        .IsUnique();

                    b.ToTable("TotalConfiguration");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Statistics.UViews", b =>
                {
                    b.Property<int>("IdViews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("April")
                        .HasColumnType("int");

                    b.Property<int>("August")
                        .HasColumnType("int");

                    b.Property<int>("December")
                        .HasColumnType("int");

                    b.Property<int>("February")
                        .HasColumnType("int");

                    b.Property<Guid>("IdProjects")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("January")
                        .HasColumnType("int");

                    b.Property<int>("July")
                        .HasColumnType("int");

                    b.Property<int>("June")
                        .HasColumnType("int");

                    b.Property<int>("March")
                        .HasColumnType("int");

                    b.Property<int>("May")
                        .HasColumnType("int");

                    b.Property<int>("November")
                        .HasColumnType("int");

                    b.Property<int>("October")
                        .HasColumnType("int");

                    b.Property<int>("September")
                        .HasColumnType("int");

                    b.HasKey("IdViews");

                    b.HasIndex("IdProjects")
                        .IsUnique();

                    b.ToTable("UViews");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Statistics.Views", b =>
                {
                    b.Property<int>("IdViews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("April")
                        .HasColumnType("int");

                    b.Property<int>("August")
                        .HasColumnType("int");

                    b.Property<int>("December")
                        .HasColumnType("int");

                    b.Property<int>("February")
                        .HasColumnType("int");

                    b.Property<Guid>("IdProjects")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("January")
                        .HasColumnType("int");

                    b.Property<int>("July")
                        .HasColumnType("int");

                    b.Property<int>("June")
                        .HasColumnType("int");

                    b.Property<int>("March")
                        .HasColumnType("int");

                    b.Property<int>("May")
                        .HasColumnType("int");

                    b.Property<int>("November")
                        .HasColumnType("int");

                    b.Property<int>("October")
                        .HasColumnType("int");

                    b.Property<int>("September")
                        .HasColumnType("int");

                    b.HasKey("IdViews");

                    b.HasIndex("IdProjects")
                        .IsUnique();

                    b.ToTable("Views");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.User", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdLicense")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActivate")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.HasIndex("IdLicense");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Apartment", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithMany("Apartment")
                        .HasForeignKey("IdProjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ApartmentOption", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Apartment", "Apartment")
                        .WithMany("ApartmentOption")
                        .HasForeignKey("IdApartment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ApartmentVariants", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Apartment", "Apartment")
                        .WithMany("ApartmentVariants")
                        .HasForeignKey("IdApartment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.House", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithMany("House")
                        .HasForeignKey("IdProjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.HouseOption", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.House", "House")
                        .WithMany("HouseOption")
                        .HasForeignKey("IdHouse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.HouseRooms", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.HouseVariants", "HouseVariants")
                        .WithMany("HouseRooms")
                        .HasForeignKey("IdHouseVariants")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseVariants");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.HouseVariants", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.House", "House")
                        .WithMany("HouseVariants")
                        .HasForeignKey("IdHouse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.License", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.LicenseType", "LicenseType")
                        .WithMany("License")
                        .HasForeignKey("IdLicenseType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicenseType");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Projects", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("IdProjectType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectType");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectsContact", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithOne("ProjectsContact")
                        .HasForeignKey("Housematica.Data.Data.CMS.ProjectsContact", "IdProjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectsLicense", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.License", "License")
                        .WithMany("ProjectsLicense")
                        .HasForeignKey("IdLicense")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithMany("ProjectsLicense")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("License");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectsUser", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithMany("ProjectsUser")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Housematica.Data.Data.CMS.User", "User")
                        .WithMany("ProjectsUser")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Rooms", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.ApartmentVariants", "ApartmentVariants")
                        .WithMany("Rooms")
                        .HasForeignKey("IdApartmentVariants")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApartmentVariants");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Single", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithMany("Single")
                        .HasForeignKey("IdProjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.SingleFloor", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Single", "Single")
                        .WithMany("SingleFloor")
                        .HasForeignKey("IdSingle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Single");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.SingleRooms", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.SingleFloor", "SingleFloor")
                        .WithMany("SingleRooms")
                        .HasForeignKey("IdSingleFloors")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SingleFloor");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Statistics.TotalConfiguration", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithOne("TotalConfiguration")
                        .HasForeignKey("Housematica.Data.Data.CMS.Statistics.TotalConfiguration", "IdProjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Statistics.UViews", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithOne("UViews")
                        .HasForeignKey("Housematica.Data.Data.CMS.Statistics.UViews", "IdProjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Statistics.Views", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.Projects", "Projects")
                        .WithOne("Views")
                        .HasForeignKey("Housematica.Data.Data.CMS.Statistics.Views", "IdProjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.User", b =>
                {
                    b.HasOne("Housematica.Data.Data.CMS.License", "License")
                        .WithMany("User")
                        .HasForeignKey("IdLicense")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("License");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Apartment", b =>
                {
                    b.Navigation("ApartmentOption");

                    b.Navigation("ApartmentVariants");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ApartmentVariants", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.House", b =>
                {
                    b.Navigation("HouseOption");

                    b.Navigation("HouseVariants");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.HouseVariants", b =>
                {
                    b.Navigation("HouseRooms");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.License", b =>
                {
                    b.Navigation("ProjectsLicense");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.LicenseType", b =>
                {
                    b.Navigation("License");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Projects", b =>
                {
                    b.Navigation("Apartment");

                    b.Navigation("House");

                    b.Navigation("ProjectsContact")
                        .IsRequired();

                    b.Navigation("ProjectsLicense");

                    b.Navigation("ProjectsUser");

                    b.Navigation("Single");

                    b.Navigation("TotalConfiguration");

                    b.Navigation("UViews");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.Single", b =>
                {
                    b.Navigation("SingleFloor");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.SingleFloor", b =>
                {
                    b.Navigation("SingleRooms");
                });

            modelBuilder.Entity("Housematica.Data.Data.CMS.User", b =>
                {
                    b.Navigation("ProjectsUser");
                });
#pragma warning restore 612, 618
        }
    }
}
