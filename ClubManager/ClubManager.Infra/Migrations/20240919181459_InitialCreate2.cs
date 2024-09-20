using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Expenses_ResponsibleUserId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserClubMembers_UserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ResponsibleUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResponsibleUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClubMemberId",
                table: "ClubMember");

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 14, 59, 523, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.CreateIndex(
                name: "IX_UserClubMembers_UserId",
                table: "UserClubMembers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ResponsibleUserId",
                table: "Expenses",
                column: "ResponsibleUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_User_ResponsibleUserId",
                table: "Expenses",
                column: "ResponsibleUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClubMembers_User_UserId",
                table: "UserClubMembers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_User_ResponsibleUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClubMembers_User_UserId",
                table: "UserClubMembers");

            migrationBuilder.DropIndex(
                name: "IX_UserClubMembers_UserId",
                table: "UserClubMembers");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ResponsibleUserId",
                table: "Expenses");

            migrationBuilder.AddColumn<long>(
                name: "ResponsibleUserId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ClubMemberId",
                table: "ClubMember",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "FacilityCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "PlayerCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "RevenueCategories",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 453, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3419));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "TeamCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateOfCreation",
                value: new DateTime(2024, 9, 19, 19, 6, 53, 452, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.CreateIndex(
                name: "IX_User_ResponsibleUserId",
                table: "User",
                column: "ResponsibleUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Expenses_ResponsibleUserId",
                table: "User",
                column: "ResponsibleUserId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserClubMembers_UserId",
                table: "User",
                column: "UserId",
                principalTable: "UserClubMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
