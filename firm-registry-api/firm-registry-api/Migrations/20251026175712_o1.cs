using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace firm_registry_api.Migrations
{
    /// <inheritdoc />
    public partial class o1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    JMBG = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Residence = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ActivityGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityCodes_ActivityGroups_ActivityGroupId",
                        column: x => x.ActivityGroupId,
                        principalTable: "ActivityGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    ActivityCodeId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Documents = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AdminNotes = table.Column<string>(type: "text", nullable: false),
                    CompanyType = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: true),
                    ShareCapital = table.Column<decimal>(type: "numeric", nullable: true),
                    BoardOfDirectors = table.Column<List<string>>(type: "text[]", nullable: true),
                    DirectorFullName = table.Column<string>(type: "text", nullable: true),
                    LimitedCompanyRequest_ShareCapital = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyRequests_ActivityCodes_ActivityCodeId",
                        column: x => x.ActivityCodeId,
                        principalTable: "ActivityCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyRequests_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Founders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    JMBG = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    Share = table.Column<decimal>(type: "numeric", nullable: true),
                    CompanyRequestId = table.Column<int>(type: "integer", nullable: false),
                    JointStockCompanyRequestId = table.Column<int>(type: "integer", nullable: true),
                    LimitedCompanyRequestId = table.Column<int>(type: "integer", nullable: true),
                    LimitedPartnershipRequestId = table.Column<int>(type: "integer", nullable: true),
                    LimitedPartnershipRequestId1 = table.Column<int>(type: "integer", nullable: true),
                    PartnershipRequestId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Founders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Founders_CompanyRequests_CompanyRequestId",
                        column: x => x.CompanyRequestId,
                        principalTable: "CompanyRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Founders_CompanyRequests_JointStockCompanyRequestId",
                        column: x => x.JointStockCompanyRequestId,
                        principalTable: "CompanyRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Founders_CompanyRequests_LimitedCompanyRequestId",
                        column: x => x.LimitedCompanyRequestId,
                        principalTable: "CompanyRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Founders_CompanyRequests_LimitedPartnershipRequestId",
                        column: x => x.LimitedPartnershipRequestId,
                        principalTable: "CompanyRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Founders_CompanyRequests_LimitedPartnershipRequestId1",
                        column: x => x.LimitedPartnershipRequestId1,
                        principalTable: "CompanyRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Founders_CompanyRequests_PartnershipRequestId",
                        column: x => x.PartnershipRequestId,
                        principalTable: "CompanyRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCodes_ActivityGroupId",
                table: "ActivityCodes",
                column: "ActivityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRequests_ActivityCodeId",
                table: "CompanyRequests",
                column: "ActivityCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRequests_AddressId",
                table: "CompanyRequests",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRequests_OwnerId",
                table: "CompanyRequests",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRequests_UserId",
                table: "CompanyRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_AddressId",
                table: "Founders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_CompanyRequestId",
                table: "Founders",
                column: "CompanyRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_JointStockCompanyRequestId",
                table: "Founders",
                column: "JointStockCompanyRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_LimitedCompanyRequestId",
                table: "Founders",
                column: "LimitedCompanyRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_LimitedPartnershipRequestId",
                table: "Founders",
                column: "LimitedPartnershipRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_LimitedPartnershipRequestId1",
                table: "Founders",
                column: "LimitedPartnershipRequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_Founders_PartnershipRequestId",
                table: "Founders",
                column: "PartnershipRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRequests_Founders_OwnerId",
                table: "CompanyRequests",
                column: "OwnerId",
                principalTable: "Founders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityCodes_ActivityGroups_ActivityGroupId",
                table: "ActivityCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRequests_ActivityCodes_ActivityCodeId",
                table: "CompanyRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRequests_Addresses_AddressId",
                table: "CompanyRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Addresses_AddressId",
                table: "Founders");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRequests_Founders_OwnerId",
                table: "CompanyRequests");

            migrationBuilder.DropTable(
                name: "ActivityGroups");

            migrationBuilder.DropTable(
                name: "ActivityCodes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Founders");

            migrationBuilder.DropTable(
                name: "CompanyRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
