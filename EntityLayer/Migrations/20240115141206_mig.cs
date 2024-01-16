using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityLayer.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CallDuraction",
                table: "CallInformationDetaileds",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cif",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DialResult",
                table: "CallInformationDetaileds",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "External",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Internal",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SipStatus",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SipStatusRecived",
                table: "CallInformationDetaileds",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallDuraction",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "Cif",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "DialResult",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "External",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "Internal",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "SipStatus",
                table: "CallInformationDetaileds");

            migrationBuilder.DropColumn(
                name: "SipStatusRecived",
                table: "CallInformationDetaileds");
        }
    }
}
