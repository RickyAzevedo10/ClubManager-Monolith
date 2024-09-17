using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClubManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partner = table.Column<bool>(type: "bit", nullable: false),
                    EducationOfficer = table.Column<bool>(type: "bit", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubMemberId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StadiumName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StadiumCapacity = table.Column<int>(type: "int", nullable: false),
                    StadiumInauguration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HaveTrainingCenter = table.Column<bool>(type: "bit", nullable: false),
                    TrainingCenterAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialWebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Create = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Consult = table.Column<bool>(type: "bit", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinorClubMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Partner = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GuardianId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinorClubMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinorClubMember_ClubMember_GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "ClubMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClubMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClubMemberId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClubMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClubMembers_ClubMember_ClubMemberId",
                        column: x => x.ClubMemberId,
                        principalTable: "ClubMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_FacilityCategories_FacilityCategoryId",
                        column: x => x.FacilityCategoryId,
                        principalTable: "FacilityCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    PreferredFoot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_PlayerCategory_PlayerCategoryId",
                        column: x => x.PlayerCategoryId,
                        principalTable: "PlayerCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Female = table.Column<bool>(type: "bit", nullable: false),
                    Male = table.Column<bool>(type: "bit", nullable: false),
                    ClubId = table.Column<long>(type: "bigint", nullable: false),
                    TeamCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Institution_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_TeamCategory_TeamCategoryId",
                        column: x => x.TeamCategoryId,
                        principalTable: "TeamCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Internal = table.Column<bool>(type: "bit", nullable: false),
                    External = table.Column<bool>(type: "bit", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubMemberId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    UserClubMemberId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId1 = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_ClubMember_UserClubMemberId",
                        column: x => x.UserClubMemberId,
                        principalTable: "ClubMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entities_Player_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerContract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerContract_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPerformanceHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubOpponent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPerformanceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPerformanceHistory_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerResponsible",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrimaryContact = table.Column<bool>(type: "bit", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerResponsible", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerResponsible_ClubMember_MemberId",
                        column: x => x.MemberId,
                        principalTable: "ClubMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerResponsible_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTransfer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    FromClub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToClub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransferFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTransfer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opponent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetitionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayer_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objectives = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSessions_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    ResponsibleUserId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revenues_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revenues_RevenueCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "RevenueCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchStatistics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    Substitutions = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAttendances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingSessionId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    AbsenceReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingAttendances_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingAttendances_TrainingSessions_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorActivated = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfLastAccess = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordResetTokenExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserPermissionId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ResponsibleUserId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Expenses_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserClubMembers_UserId",
                        column: x => x.UserId,
                        principalTable: "UserClubMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserPermissions_UserPermissionId",
                        column: x => x.UserPermissionId,
                        principalTable: "UserPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilityReservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityReservations_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityReservations_User_ReservedUserId",
                        column: x => x.ReservedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<long>(type: "bigint", nullable: false),
                    MaintenanceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestUserId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistories_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistories_User_RequestUserId",
                        column: x => x.RequestUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<long>(type: "bigint", nullable: false),
                    MaintenanceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedUserId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_User_RequestedUserId",
                        column: x => x.RequestedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamCoach",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsHeadCoach = table.Column<bool>(type: "bit", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCoach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamCoach_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamCoach_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2019), null, "Despesas relacionadas com o pagamento de salários a jogadores, treinadores e funcionários.", "Salários" },
                    { 2L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2023), null, "Custos associados à compra de equipamento e material desportivo necessário para a equipa.", "Material Desportivo" },
                    { 3L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2024), null, "Despesas com viagens e alojamento para jogos fora de casa, incluindo transporte e estadia.", "Custos de Viagem" },
                    { 4L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2025), null, "Custos associados à manutenção e reparação do estádio e outras infraestruturas do clube.", "Manutenção do Estádio" },
                    { 5L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2026), null, "Despesas com campanhas de marketing e publicidade para promover o clube e atrair patrocinadores e adeptos.", "Marketing e Publicidade" },
                    { 6L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2028), null, "Custos gerais de administração, incluindo despesas com escritório e administração do clube.", "Despesas Administrativas" },
                    { 7L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2029), null, "Despesas com seguros para proteger o clube, jogadores e infraestruturas contra riscos e danos.", "Seguros" },
                    { 8L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2030), null, "Custos com serviços de consultoria e honorários profissionais, como advogados e contabilistas.", "Honorários e Consultoria" },
                    { 9L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2031), null, "Custos relacionados com a organização de eventos especiais, como receções, eventos de angariação de fundos e outros eventos promocionais.", "Despesas com Eventos" },
                    { 10L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2032), null, "Custos associados com a formação e desenvolvimento contínuo de jogadores e equipa técnica.", "Despesas com Formação" },
                    { 11L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2033), null, "Custos relacionados com licenças e autorizações necessárias para operar o clube e participar em competições.", "Despesas de Licenciamento" },
                    { 12L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2034), null, "Custos com serviços essenciais, como eletricidade, água e gás para as instalações do clube.", "Despesas de Utilidades" },
                    { 13L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2035), null, "Custos com a reparação e manutenção de equipamentos e infraestruturas do clube.", "Despesas de Reparação e Manutenção" },
                    { 14L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2036), null, "Custos relacionados com empréstimos e financiamentos, incluindo juros e amortizações.", "Despesas de Empréstimo" },
                    { 15L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(2037), null, "Custos não categorizados especificamente, mas que podem incluir diversas despesas operacionais e imprevistos.", "Despesas Variáveis" }
                });

            migrationBuilder.InsertData(
                table: "FacilityCategories",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1306), null, "Outdoor or indoor areas designed for sports activities, such as soccer fields, tennis courts, etc.", "Sports Field" },
                    { 2L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1308), null, "Fitness centers equipped with exercise machines, weights, and other fitness equipment.", "Gym" },
                    { 3L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1309), null, "Rooms designated for meetings, conferences, and other business-related gatherings.", "Meeting Room" },
                    { 4L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1310), null, "Facilities providing restroom and changing areas, including showers and lockers.", "Restroom" },
                    { 5L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1311), null, "Workspaces for administrative tasks, including private offices and open office areas.", "Office" },
                    { 6L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1312), null, "Large rooms or halls designed for lectures, presentations, and performances.", "Auditorium" }
                });

            migrationBuilder.InsertData(
                table: "PlayerCategory",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1146), null, "Pré-Petizes", "Sub-5" },
                    { 2L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1152), null, "Petizes 1º ano", "Sub-6" },
                    { 3L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1153), null, "Petizes 2º ano", "Sub-7" },
                    { 4L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1154), null, "Traquinas 1º ano", "Sub-8" },
                    { 5L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1155), null, "Traquinas 2º ano", "Sub-9" },
                    { 6L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1156), null, "Benjamins 1º ano", "Sub-10" },
                    { 7L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1157), null, "Benjamins 2º ano", "Sub-11" },
                    { 8L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1159), null, "Infantis 1º ano", "Sub-12" },
                    { 9L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1160), null, "Infantis 2º ano", "Sub-13" },
                    { 10L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1161), null, "Iniciados 1º ano", "Sub-14" },
                    { 11L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1162), null, "Iniciados 2º ano", "Sub-15" },
                    { 12L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1163), null, "Juvenis 1º ano", "Sub-16" },
                    { 13L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1164), null, "Juvenis 2º ano", "Sub-17" },
                    { 14L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1165), null, "Juniores 1º ano", "Sub-18" },
                    { 15L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1166), null, "Juniores 2º ano", "Sub-19" },
                    { 16L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1167), null, "Seniores", "Seniores" }
                });

            migrationBuilder.InsertData(
                table: "RevenueCategories",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1625), null, "Receitas provenientes de acordos com empresas que patrocinam o clube, como patrocínios de camisas ou nomeação do estádio.", "Patrocínios" },
                    { 2L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1628), null, "Renda gerada com a venda de bilhetes, merchandising e alimentos e bebidas nos dias de jogo.", "Receitas de Dia de Jogo" },
                    { 3L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1629), null, "Receitas recebidas pela venda dos direitos de transmissão dos jogos para televisão ou plataformas de streaming.", "Direitos de Transmissão" },
                    { 4L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1631), null, "Receita gerada pela venda de produtos relacionados ao clube, como camisas, cachecóis e outros artigos.", "Merchandising" },
                    { 5L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1632), null, "Dinheiro recebido como prémio por desempenho em competições, como torneios nacionais ou internacionais.", "Prémios em Dinheiro" },
                    { 6L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1633), null, "Receitas provenientes de parcerias comerciais com marcas e empresas para eventos especiais ou produtos conjuntos.", "Parcerias Comerciais" },
                    { 7L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1634), null, "Receitas das taxas pagas pelos associados do clube para acesso a benefícios exclusivos, como bilhetes preferenciais ou eventos especiais.", "Taxas de Associação" },
                    { 8L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1635), null, "Receitas geradas pela venda dos direitos de nomeação do estádio do clube.", "Direitos de Nomeação do Estádio" },
                    { 9L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1636), null, "Receitas provenientes da venda ou empréstimo de jogadores para outros clubes.", "Transferências de Jogadores" },
                    { 10L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1637), null, "Receitas geradas pela publicidade dentro do estádio ou em outras plataformas relacionadas ao clube.", "Publicidade" },
                    { 11L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1638), null, "Receitas obtidas com a venda de pacotes de hospitalidade corporativa, que incluem bilhetes para jogos e serviços adicionais.", "Hospedagem Corporativa" },
                    { 12L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1639), null, "Receitas provenientes da realização de eventos especiais no estádio, como concertos ou eventos corporativos.", "Receitas de Eventos" },
                    { 13L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1640), null, "Receitas geradas por taxas de inscrição ou desenvolvimento de jovens talentos e futuras transferências.", "Receitas da Academia de Jovens" },
                    { 14L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1641), null, "Receitas obtidas pelo aluguel de instalações do clube, como campos de treino ou áreas do estádio para eventos externos.", "Renda de Aluguel" },
                    { 15L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(1643), null, "Dinheiro recebido de subsídios governamentais, fundações ou doações privadas para apoiar o clube.", "Subsídios e Doações" }
                });

            migrationBuilder.InsertData(
                table: "TeamCategory",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(264), null, "Pré-Petizes", "Pré-Petizes" },
                    { 2L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(267), null, "Petizes", "Petizes" },
                    { 3L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(269), null, "Traquinas", "Traquinas" },
                    { 4L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(270), null, "Benjamins", "Benjamins" },
                    { 5L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(271), null, "Infantis", "Infantis" },
                    { 6L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(272), null, "Iniciados", "Iniciados" },
                    { 7L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(273), null, "Juvenis", "Juvenis" },
                    { 8L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(295), null, "Juniores", "Juniores" },
                    { 9L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(297), null, "Seniores", "Seniores" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 0, 0, 42, 187, DateTimeKind.Local).AddTicks(9950), null, "Função administrativa para gerenciamento da instituição. Acesso total a toda a informação dentro da instituição.", "Admin" },
                    { 2L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(7), null, "Supervisiona todas as operações do clube, toma decisões estratégicas e tem acesso a todos as operações e funcionalidades da aplicação.", "Presidente" },
                    { 3L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(8), null, "Encarregado das operações futebolísticas, incluindo gestão de treinadores, jogadores, transferências e contratações.", "Diretor Desportivo" },
                    { 4L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(9), null, "Gere a equipe técnica, planeia treinos, táticas de jogo, escolhe a equipa para os jogos e monitoriza o desempenho dos jogadores.", "Treinador" },
                    { 5L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(10), null, "Gere as finanças do clube, incluindo orçamento, salários, receitas de bilheteira, patrocínios e outras fontes de receita.", "Diretor Financeiro" },
                    { 6L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(11), null, "Gere as instalações do clube, incluindo estádios, campos de treino e outras infraestruturas.", "Gestor de Infraestruturas" },
                    { 7L, new DateTime(2024, 9, 17, 0, 0, 42, 188, DateTimeKind.Local).AddTicks(13), null, "Trata de toda a documentação e administração necessária para o funcionamento do clube.", "Secretário" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubMember_Email",
                table: "ClubMember",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_PlayerId1",
                table: "Entities",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_UserClubMemberId",
                table: "Entities",
                column: "UserClubMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_Name",
                table: "ExpenseCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EntityId",
                table: "Expenses",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FacilityCategoryId",
                table: "Facilities",
                column: "FacilityCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReservations_FacilityId",
                table: "FacilityReservations",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReservations_ReservedUserId",
                table: "FacilityReservations",
                column: "ReservedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistories_FacilityId",
                table: "MaintenanceHistories",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistories_RequestUserId",
                table: "MaintenanceHistories",
                column: "RequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_FacilityId",
                table: "MaintenanceRequests",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_RequestedUserId",
                table: "MaintenanceRequests",
                column: "RequestedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamId",
                table: "Matches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_MatchId",
                table: "MatchStatistics",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_PlayerId",
                table: "MatchStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MinorClubMember_Email",
                table: "MinorClubMember",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MinorClubMember_GuardianId",
                table: "MinorClubMember",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PlayerCategoryId",
                table: "Player",
                column: "PlayerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerContract_PlayerId",
                table: "PlayerContract",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerformanceHistory_PlayerId",
                table: "PlayerPerformanceHistory",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResponsible_MemberId",
                table: "PlayerResponsible",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResponsible_PlayerId",
                table: "PlayerResponsible",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTransfer_PlayerId",
                table: "PlayerTransfer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueCategories_Name",
                table: "RevenueCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_CategoryId",
                table: "Revenues",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_EntityId",
                table: "Revenues",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ClubId",
                table: "Team",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamCategoryId",
                table: "Team",
                column: "TeamCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoach_TeamId",
                table: "TeamCoach",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoach_UserId",
                table: "TeamCoach",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayer_PlayerId",
                table: "TeamPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayer_TeamId",
                table: "TeamPlayer",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAttendances_PlayerId",
                table: "TrainingAttendances",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAttendances_TrainingSessionId",
                table: "TrainingAttendances",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessions_TeamId",
                table: "TrainingSessions",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_InstitutionId",
                table: "User",
                column: "InstitutionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_User_UserPermissionId",
                table: "User",
                column: "UserPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                table: "User",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClubMembers_ClubMemberId",
                table: "UserClubMembers",
                column: "ClubMemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Name",
                table: "UserRoles",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityReservations");

            migrationBuilder.DropTable(
                name: "MaintenanceHistories");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "MatchStatistics");

            migrationBuilder.DropTable(
                name: "MinorClubMember");

            migrationBuilder.DropTable(
                name: "PlayerContract");

            migrationBuilder.DropTable(
                name: "PlayerPerformanceHistory");

            migrationBuilder.DropTable(
                name: "PlayerResponsible");

            migrationBuilder.DropTable(
                name: "PlayerTransfer");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "TeamCoach");

            migrationBuilder.DropTable(
                name: "TeamPlayer");

            migrationBuilder.DropTable(
                name: "TrainingAttendances");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "RevenueCategories");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TrainingSessions");

            migrationBuilder.DropTable(
                name: "FacilityCategories");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "UserClubMembers");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "TeamCategory");

            migrationBuilder.DropTable(
                name: "ClubMember");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "PlayerCategory");
        }
    }
}
