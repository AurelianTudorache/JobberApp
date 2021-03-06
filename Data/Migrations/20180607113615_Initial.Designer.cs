﻿// <auto-generated />
using System;
using JobberApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobberApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180607113615_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobberApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("Flags");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Notes");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVC");

                    b.Property<string>("CardNumber");

                    b.Property<string>("CardType");

                    b.Property<int>("EmployerId");

                    b.Property<byte>("ExpMonth");

                    b.Property<short>("ExpYear");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("NameOnCard");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandThumbnail");

                    b.Property<string>("CompanyEmail");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyNumber");

                    b.Property<string>("FullName");

                    b.Property<string>("HqBuilding");

                    b.Property<string>("HqCity");

                    b.Property<string>("HqPostalCode");

                    b.Property<string>("HqStreet");

                    b.Property<string>("UserId");

                    b.Property<string>("VatNumber");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("JobberApp.Data.Models.JobAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("ChargeRate");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<int>("EmployerId");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsAssigned");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<int>("Payrate");

                    b.Property<int>("PosNeeded");

                    b.Property<string>("Requirments");

                    b.Property<int>("SkillId");

                    b.Property<DateTime>("StartDate");

                    b.Property<float>("TotalCharge");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("JobAds");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Building");

                    b.Property<string>("City");

                    b.Property<int>("EmployerId");

                    b.Property<string>("ImageThumbnail");

                    b.Property<int>("Latitude");

                    b.Property<int>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("JobGroup");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int>("Type");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Card", b =>
                {
                    b.HasOne("JobberApp.Data.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobberApp.Data.Models.Employee", b =>
                {
                    b.HasOne("JobberApp.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Employer", b =>
                {
                    b.HasOne("JobberApp.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JobberApp.Data.Models.JobAd", b =>
                {
                    b.HasOne("JobberApp.Data.Models.Employer")
                        .WithMany("JobAds")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobberApp.Data.Models.Location", b =>
                {
                    b.HasOne("JobberApp.Data.Models.Employer", "Employer")
                        .WithMany("Locations")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobberApp.Data.Models.Skill", b =>
                {
                    b.HasOne("JobberApp.Data.Models.Employee")
                        .WithMany("Skills")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("JobberApp.Data.Models.Token", b =>
                {
                    b.HasOne("JobberApp.Data.Models.ApplicationUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobberApp.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobberApp.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobberApp.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobberApp.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
