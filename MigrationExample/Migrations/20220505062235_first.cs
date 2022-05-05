using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MigrationExample.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedMemberId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedMemberId = table.Column<int>(type: "integer", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedMemberId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PersonalEmailAddress = table.Column<string>(type: "text", nullable: false),
                    CorporateEmailAddress = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    SocialNumber = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedMemberId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedMemberId = table.Column<int>(type: "integer", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedMemberId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Departmant_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departmant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departmant",
                columns: new[] { "Id", "CreatedDateTime", "CreatedMemberId", "DeletedDateTime", "DeletedMemberId", "IsDeleted", "Name", "UpdatedDateTime", "UpdatedMemberId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 5, 6, 22, 35, 46, DateTimeKind.Utc).AddTicks(6380), null, null, null, false, "Information Techonolgy", null, null },
                    { 2, new DateTime(2022, 5, 5, 6, 22, 35, 46, DateTimeKind.Utc).AddTicks(6384), null, null, null, false, "Human Resources", null, null }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "BirthDate", "CorporateEmailAddress", "CreatedDateTime", "CreatedMemberId", "DeletedDateTime", "DeletedMemberId", "DepartmentId", "IsDeleted", "Name", "Password", "PersonalEmailAddress", "PhoneNumber", "SocialNumber", "Surname", "UpdatedDateTime", "UpdatedMemberId" },
                values: new object[] { 1, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test@email.com", new DateTime(2022, 5, 5, 6, 22, 35, 46, DateTimeKind.Utc).AddTicks(6411), null, null, null, 1, false, "Kaan", "******", "test@email.com", "+90**********", "***********", "Küçük", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Departmant");
        }
    }
}
