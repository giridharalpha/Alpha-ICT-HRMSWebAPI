using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS.DAL.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesignationMaster",
                columns: table => new
                {
                    DesignationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationMaster", x => x.DesignationID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    correspondenceAddress = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmergencyContactNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MaritialStatus = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MedicalHistory = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    DesignationID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EnteredBy = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

           
            migrationBuilder.CreateTable(
                name: "LeaveReasonMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveReason = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveReasonMaster", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignationMaster");

            migrationBuilder.DropTable(
                name: "Employee");           

            migrationBuilder.DropTable(
                name: "LeaveReasonMaster");
        }
    }
}
