using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallAnswered",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CallEnded",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CallStarted",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CallType",
                table: "CallInformationDetaileds",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Chain",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CallInformationDetaileds",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GatewayName",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsMakeCall",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonChanged",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonTerminated",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallAnswered",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "CallEnded",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "CallStarted",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "CallType",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "Chain",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "GatewayName",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "IsMakeCall",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "ReasonChanged",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "ReasonTerminated",
                table: "CallInformationDetaileds");
        }
    }
}
