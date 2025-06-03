using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lifestyle_Preference_survey.Migrations
{
    /// <inheritdoc />
    public partial class _Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_UserDetails_UserDetailID",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_UserDetails_UserDetailID",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserDetailID",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_UserDetailID",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UserDetailID",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "UserDetailID",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Foods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserDetailID",
                table: "Ratings",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "User_ID",
                table: "Ratings",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserDetailID",
                table: "Foods",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "User_ID",
                table: "Foods",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserDetailID",
                table: "Ratings",
                column: "UserDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UserDetailID",
                table: "Foods",
                column: "UserDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_UserDetails_UserDetailID",
                table: "Foods",
                column: "UserDetailID",
                principalTable: "UserDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_UserDetails_UserDetailID",
                table: "Ratings",
                column: "UserDetailID",
                principalTable: "UserDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
