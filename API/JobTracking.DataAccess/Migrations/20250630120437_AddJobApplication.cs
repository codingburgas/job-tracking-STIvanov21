using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddJobApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantEmail",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantFullName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Applications",
                newName: "CoverLetter");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Applications",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Applications",
                newName: "AppliedOn");

            migrationBuilder.AddColumn<int>(
                name: "JobOfferId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobOfferId",
                table: "Applications",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobOfferId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Applications",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "CoverLetter",
                table: "Applications",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "AppliedOn",
                table: "Applications",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantEmail",
                table: "Applications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantFullName",
                table: "Applications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Applications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Applications",
                type: "datetime2",
                nullable: true);
        }
    }
}
