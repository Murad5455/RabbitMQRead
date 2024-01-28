using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallInformationDetaileds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CallId = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CallStarted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CallStartedTest = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CallEnded = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CallAnswered = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    GatewayName = table.Column<string>(type: "text", nullable: true),
                    IsMakeCall = table.Column<string>(type: "text", nullable: true),
                    Chain = table.Column<string>(type: "text", nullable: true),
                    ReasonTerminated = table.Column<string>(type: "text", nullable: true),
                    ReasonChanged = table.Column<string>(type: "text", nullable: true),
                    CallType = table.Column<int>(type: "integer", nullable: false),
                    CallDuraction = table.Column<int>(type: "integer", nullable: true),
                    Internal = table.Column<string>(type: "text", nullable: true),
                    SipStatusRecived = table.Column<string>(type: "text", nullable: true),
                    SipStatus = table.Column<string>(type: "text", nullable: true),
                    External = table.Column<string>(type: "text", nullable: true),
                    DialResult = table.Column<int>(type: "integer", nullable: true),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    Cif = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallInformationDetaileds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallInformations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    External = table.Column<string>(type: "text", nullable: false),
                    Internal = table.Column<string>(type: "text", nullable: false),
                    SipStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallInformations", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallInformationDetaileds");

            migrationBuilder.DropTable(
                name: "CallInformations");
        }
    }
}
