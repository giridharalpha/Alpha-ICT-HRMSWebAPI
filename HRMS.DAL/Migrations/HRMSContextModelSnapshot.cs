﻿// <auto-generated />
using System;
using HRMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRMS.DAL.Migrations
{
    [DbContext(typeof(HRMSContext))]
    partial class HRMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRMS.BusinessObjects.Models.DesignationMaster", b =>
                {
                    b.Property<int>("DesignationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DesignationName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DesignationID");

                    b.ToTable("DesignationMaster");
                });

            modelBuilder.Entity("HRMS.BusinessObjects.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<int>("DesignationID")
                        .HasColumnType("int");

                    b.Property<string>("EmailID")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmergencyContactNo")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeCode")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EnteredBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaritialStatus")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MedicalHistory")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PermanentAddress")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("correspondenceAddress")
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HRMS.BusinessObjects.Models.EmployeeCustomName", b =>
                {
                    b.ToTable("EmpName");
                });

            modelBuilder.Entity("HRMS.BusinessObjects.Models.HolidayMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HolidayDate")
                        .HasColumnType("datetime");

                    b.Property<string>("HolidayName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("HolidayType")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("HolidayMaster");
                });

            modelBuilder.Entity("HRMS.BusinessObjects.Models.LeaveApplication", b =>
                {
                    b.Property<int>("LeaveApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AssignForApprovalIDs")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("FinalLeaveStatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime");

                    b.Property<int>("LeaveReasonID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("LeaveApplicationID");

                    b.ToTable("LeaveApplication");
                });

            modelBuilder.Entity("HRMS.BusinessObjects.Models.LeaveReasonMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LeaveReason")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("LeaveReasonMaster");
                });

            modelBuilder.Entity("HRMS.BusinessObjects.Models.NewsEventsMaster", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("EventID");

                    b.ToTable("NewsEventsMaster");
                });

            modelBuilder.Entity("HRMS.BusinessObjects.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("UserID");

                    b.ToTable("UserMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
