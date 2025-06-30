using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionLocationTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantEmail",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "ApplicantFullName",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "JobSalary",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "JobOffers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "JobOffers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantEmail",
                table: "JobOffers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantFullName",
                table: "JobOffers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "JobOffers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JobSalary",
                table: "JobOffers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "JobOffers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "JobOffers",
                type: "datetime2",
                nullable: true);
        }
    }
}
