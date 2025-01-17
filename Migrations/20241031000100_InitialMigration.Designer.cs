﻿// <auto-generated />
using System;
using GrpcService1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrpcService1.Migrations
{
    [DbContext(typeof(MyVaccineAppDbContext))]
    [Migration("20241031000100_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FamilyGroupUser", b =>
                {
                    b.Property<int>("FamilyGroupsFamilyGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("FamilyGroupsFamilyGroupId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("FamilyGroupUser");
                });

            modelBuilder.Entity("GrpcService1.Allergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AllergyId");

                    b.HasIndex("UserId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("GrpcService1.Dependent", b =>
                {
                    b.Property<int>("DependentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DependentId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DependentId");

                    b.HasIndex("UserId");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("GrpcService1.FamilyGroup", b =>
                {
                    b.Property<int>("FamilyGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyGroupId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FamilyGroupId");

                    b.ToTable("familyGroups");
                });

            modelBuilder.Entity("GrpcService1.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GrpcService1.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("RequiresBooster")
                        .HasColumnType("bit");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("GrpcService1.VaccineCategory", b =>
                {
                    b.Property<int>("VaccineCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineCategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VaccineCategoryId");

                    b.ToTable("VaccineCategories");
                });

            modelBuilder.Entity("GrpcService1.VaccineRecord", b =>
                {
                    b.Property<int>("VaccineCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineCategoryId"));

                    b.Property<string>("AdministeredBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AdministeredLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateAdministered")
                        .HasColumnType("datetime2");

                    b.Property<int>("DependentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VaccineId")
                        .HasColumnType("int");

                    b.HasKey("VaccineCategoryId");

                    b.HasIndex("DependentId");

                    b.HasIndex("UserId");

                    b.HasIndex("VaccineId");

                    b.ToTable("VaccineRecords");
                });

            modelBuilder.Entity("VaccineVaccineCategory", b =>
                {
                    b.Property<int>("CategoriesVaccineCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("VaccinesVaccineId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesVaccineCategoryId", "VaccinesVaccineId");

                    b.HasIndex("VaccinesVaccineId");

                    b.ToTable("VaccineCategoryVaccines", (string)null);
                });

            modelBuilder.Entity("FamilyGroupUser", b =>
                {
                    b.HasOne("GrpcService1.FamilyGroup", null)
                        .WithMany()
                        .HasForeignKey("FamilyGroupsFamilyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrpcService1.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrpcService1.Allergy", b =>
                {
                    b.HasOne("GrpcService1.User", "User")
                        .WithMany("Allergies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GrpcService1.Dependent", b =>
                {
                    b.HasOne("GrpcService1.User", "User")
                        .WithMany("Dependents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GrpcService1.VaccineRecord", b =>
                {
                    b.HasOne("GrpcService1.Dependent", "Dependent")
                        .WithMany("VaccineRecords")
                        .HasForeignKey("DependentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrpcService1.User", "User")
                        .WithMany("VaccineRecords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GrpcService1.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dependent");

                    b.Navigation("User");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("VaccineVaccineCategory", b =>
                {
                    b.HasOne("GrpcService1.VaccineCategory", null)
                        .WithMany()
                        .HasForeignKey("CategoriesVaccineCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrpcService1.Vaccine", null)
                        .WithMany()
                        .HasForeignKey("VaccinesVaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrpcService1.Dependent", b =>
                {
                    b.Navigation("VaccineRecords");
                });

            modelBuilder.Entity("GrpcService1.User", b =>
                {
                    b.Navigation("Allergies");

                    b.Navigation("Dependents");

                    b.Navigation("VaccineRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
