using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lifestyle_Preference_survey.Migrations
{
    /// <inheritdoc />
    public partial class _Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Fullnames = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    User_ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserDetailID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pizza = table.Column<bool>(type: "INTEGER", nullable: false),
                    Pasta = table.Column<bool>(type: "INTEGER", nullable: false),
                    PapAndWors = table.Column<bool>(type: "INTEGER", nullable: false),
                    Other = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Foods_UserDetails_UserDetailID",
                        column: x => x.UserDetailID,
                        principalTable: "UserDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    User_ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserDetailID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Movies = table.Column<bool>(type: "INTEGER", nullable: false),
                    Radio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Out = table.Column<bool>(type: "INTEGER", nullable: false),
                    TV = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ratings_UserDetails_UserDetailID",
                        column: x => x.UserDetailID,
                        principalTable: "UserDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UserDetailID",
                table: "Foods",
                column: "UserDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserDetailID",
                table: "Ratings",
                column: "UserDetailID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
