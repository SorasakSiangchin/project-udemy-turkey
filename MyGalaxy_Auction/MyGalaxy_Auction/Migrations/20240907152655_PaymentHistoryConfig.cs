using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGalaxy_Auction.Migrations
{
    /// <inheritdoc />
    public partial class PaymentHistoryConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "PaymentHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripePaymentIntentId",
                table: "PaymentHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4795), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4785) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 1, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4823), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4826), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4829), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4828) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4831), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4831) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4834), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4837), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4840), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4839) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4842), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4845), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4847), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4847) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4850), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4853), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4858), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4858) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4862), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4862) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4866), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4868), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4871), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4874), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4876), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4876) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 25, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4879), new DateTime(2024, 9, 7, 22, 26, 54, 964, DateTimeKind.Local).AddTicks(4878) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "StripePaymentIntentId",
                table: "PaymentHistories");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5738), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5727) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 27, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5746), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5749), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5752), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5751) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5756), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5756) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5759), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5761), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5764), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5767), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5767) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5771), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5771) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5773), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5773) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5776), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5775) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5784), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5787), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5790), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5792), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5792) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5795), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5794) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5797), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5797) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5799), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 11, 14, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5802), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5804), new DateTime(2024, 9, 3, 21, 21, 6, 408, DateTimeKind.Local).AddTicks(5804) });
        }
    }
}
