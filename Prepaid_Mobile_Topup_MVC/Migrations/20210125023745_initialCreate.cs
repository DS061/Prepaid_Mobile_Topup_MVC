﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prepaid_Mobile_Topup_MVC.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrepaidCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RegistereddDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepaidCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopUpChannel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopUpChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    PrepaidCustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileAccount_PrepaidCustomer_PrepaidCustomerId",
                        column: x => x.PrepaidCustomerId,
                        principalTable: "PrepaidCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileAccountId = table.Column<int>(nullable: false),
                    TopUpChannelId = table.Column<int>(nullable: false),
                    TopUpAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopUp_MobileAccount_MobileAccountId",
                        column: x => x.MobileAccountId,
                        principalTable: "MobileAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopUp_TopUpChannel_TopUpChannelId",
                        column: x => x.TopUpChannelId,
                        principalTable: "TopUpChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobileAccount_PrepaidCustomerId",
                table: "MobileAccount",
                column: "PrepaidCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TopUp_MobileAccountId",
                table: "TopUp",
                column: "MobileAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TopUp_TopUpChannelId",
                table: "TopUp",
                column: "TopUpChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopUp");

            migrationBuilder.DropTable(
                name: "MobileAccount");

            migrationBuilder.DropTable(
                name: "TopUpChannel");

            migrationBuilder.DropTable(
                name: "PrepaidCustomer");
        }
    }
}
