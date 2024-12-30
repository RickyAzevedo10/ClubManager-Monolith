using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClubManager.Infrastructure.Migrations
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
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetTokenExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserPermissionId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
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
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Internal = table.Column<bool>(type: "bit", nullable: false),
                    External = table.Column<bool>(type: "bit", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubMemberId = table.Column<long>(type: "bigint", nullable: true),
                    PlayerId = table.Column<long>(type: "bigint", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_ClubMember_ClubMemberId",
                        column: x => x.ClubMemberId,
                        principalTable: "ClubMember",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entities_Player_PlayerId",
                        column: x => x.PlayerId,
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
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    TransferFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCoach_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClubMembers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Expenses_User_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "User",
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Revenues_User_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "User",
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

            migrationBuilder.InsertData(
                table: "ClubMember",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateOfCreation", "DateOfJoining", "DateOfModification", "EducationOfficer", "Email", "FirstName", "LastName", "Partner", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, "306 Rachael Center, Boscofort, San Marino", new DateTime(1981, 1, 1, 11, 17, 40, 59, DateTimeKind.Local).AddTicks(1308), new DateTime(2024, 12, 30, 13, 55, 35, 468, DateTimeKind.Local).AddTicks(9937), new DateTime(2023, 10, 18, 9, 16, 24, 379, DateTimeKind.Local).AddTicks(7739), null, true, "Luciano_Sanford@hotmail.com", "Destiny", "Reichert", true, "730-248-4712 x361" },
                    { 2L, "476 Dannie Streets, North Scottie, Cocos (Keeling) Islands", new DateTime(1987, 5, 22, 12, 33, 49, 313, DateTimeKind.Local).AddTicks(823), new DateTime(2024, 12, 30, 13, 55, 35, 469, DateTimeKind.Local).AddTicks(484), new DateTime(2021, 11, 25, 7, 10, 10, 925, DateTimeKind.Local).AddTicks(8785), null, false, "Louvenia.OKeefe@hotmail.com", "Maybell", "Harvey", false, "(935) 764-9352 x318" },
                    { 3L, "324 Green Crest, Adrianland, Syrian Arab Republic", new DateTime(1986, 11, 29, 0, 58, 43, 60, DateTimeKind.Local).AddTicks(5671), new DateTime(2024, 12, 30, 13, 55, 35, 469, DateTimeKind.Local).AddTicks(8712), new DateTime(2020, 1, 11, 9, 12, 43, 713, DateTimeKind.Local).AddTicks(8329), null, false, "Marjory.Pfannerstill@hotmail.com", "Stewart", "Kozey", true, "1-644-217-0456" },
                    { 4L, "8655 Elmira Ways, Lake Elisa, Puerto Rico", new DateTime(1995, 7, 7, 23, 0, 41, 512, DateTimeKind.Local).AddTicks(2508), new DateTime(2024, 12, 30, 13, 55, 35, 469, DateTimeKind.Local).AddTicks(8903), new DateTime(2023, 11, 29, 0, 46, 24, 308, DateTimeKind.Local).AddTicks(4949), null, false, "Rhiannon.Prohaska74@gmail.com", "Efren", "O'Kon", false, "(508) 590-1215 x04825" },
                    { 5L, "8065 Ondricka Squares, Wehnermouth, Finland", new DateTime(1992, 12, 17, 3, 20, 38, 417, DateTimeKind.Local).AddTicks(471), new DateTime(2024, 12, 30, 13, 55, 35, 469, DateTimeKind.Local).AddTicks(9074), new DateTime(2021, 11, 10, 0, 39, 34, 991, DateTimeKind.Local).AddTicks(4877), null, false, "Horace0@gmail.com", "Alden", "Cole", false, "860.382.3498" },
                    { 6L, "066 Sean Mill, Crookshaven, Guernsey", new DateTime(2003, 3, 9, 2, 24, 16, 338, DateTimeKind.Local).AddTicks(4808), new DateTime(2024, 12, 30, 13, 55, 35, 469, DateTimeKind.Local).AddTicks(9204), new DateTime(2022, 12, 28, 11, 17, 56, 320, DateTimeKind.Local).AddTicks(3929), null, false, "Reina_Moen@gmail.com", "Yolanda", "Beier", false, "539-879-3321 x704" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7422), null, "Despesas relacionadas com o pagamento de salários a jogadores, treinadores e funcionários.", "Salários" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7427), null, "Custos associados à compra de equipamento e material desportivo necessário para a equipa.", "Material Desportivo" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7428), null, "Despesas com viagens e alojamento para jogos fora de casa, incluindo transporte e estadia.", "Custos de Viagem" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7429), null, "Custos associados à manutenção e reparação do estádio e outras infraestruturas do clube.", "Manutenção do Estádio" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7431), null, "Despesas com campanhas de marketing e publicidade para promover o clube e atrair patrocinadores e adeptos.", "Marketing e Publicidade" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7432), null, "Custos gerais de administração, incluindo despesas com escritório e administração do clube.", "Despesas Administrativas" },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7433), null, "Despesas com seguros para proteger o clube, jogadores e infraestruturas contra riscos e danos.", "Seguros" },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7434), null, "Custos com serviços de consultoria e honorários profissionais, como advogados e contabilistas.", "Honorários e Consultoria" },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7435), null, "Custos relacionados com a organização de eventos especiais, como receções, eventos de angariação de fundos e outros eventos promocionais.", "Despesas com Eventos" },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7436), null, "Custos associados com a formação e desenvolvimento contínuo de jogadores e equipa técnica.", "Despesas com Formação" },
                    { 11L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7437), null, "Custos relacionados com licenças e autorizações necessárias para operar o clube e participar em competições.", "Despesas de Licenciamento" },
                    { 12L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7438), null, "Custos com serviços essenciais, como eletricidade, água e gás para as instalações do clube.", "Despesas de Utilidades" },
                    { 13L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7439), null, "Custos com a reparação e manutenção de equipamentos e infraestruturas do clube.", "Despesas de Reparação e Manutenção" },
                    { 14L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7440), null, "Custos relacionados com empréstimos e financiamentos, incluindo juros e amortizações.", "Despesas de Empréstimo" },
                    { 15L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7441), null, "Custos não categorizados especificamente, mas que podem incluir diversas despesas operacionais e imprevistos.", "Despesas Variáveis" }
                });

            migrationBuilder.InsertData(
                table: "FacilityCategories",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 528, DateTimeKind.Local).AddTicks(4681), null, "Outdoor or indoor areas designed for sports activities, such as soccer fields, tennis courts, etc.", "Sports Field" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 528, DateTimeKind.Local).AddTicks(4686), null, "Fitness centers equipped with exercise machines, weights, and other fitness equipment.", "Gym" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 528, DateTimeKind.Local).AddTicks(4688), null, "Rooms designated for meetings, conferences, and other business-related gatherings.", "Meeting Room" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 528, DateTimeKind.Local).AddTicks(4689), null, "Facilities providing restroom and changing areas, including showers and lockers.", "Restroom" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 528, DateTimeKind.Local).AddTicks(4689), null, "Workspaces for administrative tasks, including private offices and open office areas.", "Office" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 528, DateTimeKind.Local).AddTicks(4690), null, "Large rooms or halls designed for lectures, presentations, and performances.", "Auditorium" }
                });

            migrationBuilder.InsertData(
                table: "Institution",
                columns: new[] { "Id", "Abbreviation", "Address", "Colors", "DateOfCreation", "DateOfModification", "FoundationDate", "HaveTrainingCenter", "Logo", "Name", "OfficialWebsiteUrl", "SocialMediaLinks", "StadiumCapacity", "StadiumInauguration", "StadiumName", "TrainingCenterAddress" },
                values: new object[] { 1L, null, "08253 Victor Bypass, Jakeberg, New Zealand", "white", new DateTime(2024, 12, 30, 13, 55, 35, 465, DateTimeKind.Local).AddTicks(2749), null, new DateTime(1963, 11, 20, 12, 14, 9, 492, DateTimeKind.Local).AddTicks(960), true, null, "Sipes and Sons", "https://aurelie.com", "https://harrison.org", 35753, new DateTime(1986, 12, 2, 4, 44, 34, 750, DateTimeKind.Local).AddTicks(6938), "earum", null });

            migrationBuilder.InsertData(
                table: "PlayerCategory",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9733), null, "Pré-Petizes", "Sub-5" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9745), null, "Petizes 1º ano", "Sub-6" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9746), null, "Petizes 2º ano", "Sub-7" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9747), null, "Traquinas 1º ano", "Sub-8" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9748), null, "Traquinas 2º ano", "Sub-9" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9749), null, "Benjamins 1º ano", "Sub-10" },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9751), null, "Benjamins 2º ano", "Sub-11" },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9752), null, "Infantis 1º ano", "Sub-12" },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9753), null, "Infantis 2º ano", "Sub-13" },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9754), null, "Iniciados 1º ano", "Sub-14" },
                    { 11L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9755), null, "Iniciados 2º ano", "Sub-15" },
                    { 12L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9756), null, "Juvenis 1º ano", "Sub-16" },
                    { 13L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9757), null, "Juvenis 2º ano", "Sub-17" },
                    { 14L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9758), null, "Juniores 1º ano", "Sub-18" },
                    { 15L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9759), null, "Juniores 2º ano", "Sub-19" },
                    { 16L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(9760), null, "Seniores", "Seniores" }
                });

            migrationBuilder.InsertData(
                table: "RevenueCategories",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(6987), null, "Receitas provenientes de acordos com empresas que patrocinam o clube, como patrocínios de camisas ou nomeação do estádio.", "Patrocínios" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(6994), null, "Renda gerada com a venda de bilhetes, merchandising e alimentos e bebidas nos dias de jogo.", "Receitas de Dia de Jogo" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(6995), null, "Receitas recebidas pela venda dos direitos de transmissão dos jogos para televisão ou plataformas de streaming.", "Direitos de Transmissão" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(6996), null, "Receita gerada pela venda de produtos relacionados ao clube, como camisas, cachecóis e outros artigos.", "Merchandising" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(6997), null, "Dinheiro recebido como prémio por desempenho em competições, como torneios nacionais ou internacionais.", "Prémios em Dinheiro" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(6998), null, "Receitas provenientes de parcerias comerciais com marcas e empresas para eventos especiais ou produtos conjuntos.", "Parcerias Comerciais" },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(6999), null, "Receitas das taxas pagas pelos associados do clube para acesso a benefícios exclusivos, como bilhetes preferenciais ou eventos especiais.", "Taxas de Associação" },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7000), null, "Receitas geradas pela venda dos direitos de nomeação do estádio do clube.", "Direitos de Nomeação do Estádio" },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7001), null, "Receitas provenientes da venda ou empréstimo de jogadores para outros clubes.", "Transferências de Jogadores" },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7002), null, "Receitas geradas pela publicidade dentro do estádio ou em outras plataformas relacionadas ao clube.", "Publicidade" },
                    { 11L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7003), null, "Receitas obtidas com a venda de pacotes de hospitalidade corporativa, que incluem bilhetes para jogos e serviços adicionais.", "Hospedagem Corporativa" },
                    { 12L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7004), null, "Receitas provenientes da realização de eventos especiais no estádio, como concertos ou eventos corporativos.", "Receitas de Eventos" },
                    { 13L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7005), null, "Receitas geradas por taxas de inscrição ou desenvolvimento de jovens talentos e futuras transferências.", "Receitas da Academia de Jovens" },
                    { 14L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7006), null, "Receitas obtidas pelo aluguel de instalações do clube, como campos de treino ou áreas do estádio para eventos externos.", "Renda de Aluguel" },
                    { 15L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(7007), null, "Dinheiro recebido de subsídios governamentais, fundações ou doações privadas para apoiar o clube.", "Subsídios e Doações" }
                });

            migrationBuilder.InsertData(
                table: "TeamCategory",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6443), null, "Pré-Petizes", "Pré-Petizes" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6446), null, "Petizes", "Petizes" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6448), null, "Traquinas", "Traquinas" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6449), null, "Benjamins", "Benjamins" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6450), null, "Infantis", "Infantis" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6451), null, "Iniciados", "Iniciados" },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6452), null, "Juvenis", "Juvenis" },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6453), null, "Juniores", "Juniores" },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(6454), null, "Seniores", "Seniores" }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "Consult", "Create", "DateOfCreation", "DateOfModification", "Delete", "Edit" },
                values: new object[,]
                {
                    { 1L, false, false, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4394), null, false, true },
                    { 2L, false, false, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4528), null, false, true },
                    { 3L, true, true, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4537), null, true, false },
                    { 4L, true, true, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4542), null, true, true },
                    { 5L, false, false, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4545), null, false, false },
                    { 6L, true, true, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4549), null, true, false },
                    { 7L, false, true, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4553), null, false, true },
                    { 8L, true, false, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4557), null, false, false },
                    { 9L, false, true, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4562), null, false, false },
                    { 10L, false, true, new DateTime(2024, 12, 30, 13, 55, 35, 466, DateTimeKind.Local).AddTicks(4565), null, false, true }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 463, DateTimeKind.Local).AddTicks(6613), null, "Função administrativa para gerenciamento da instituição. Acesso total a toda a informação dentro da instituição.", "Admin" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 463, DateTimeKind.Local).AddTicks(6668), null, "Supervisiona todas as operações do clube, toma decisões estratégicas e tem acesso a todos as operações e funcionalidades da aplicação.", "Presidente" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 463, DateTimeKind.Local).AddTicks(6669), null, "Encarregado das operações futebolísticas, incluindo gestão de treinadores, jogadores, transferências e contratações.", "Diretor Desportivo" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 463, DateTimeKind.Local).AddTicks(6670), null, "Gere a equipe técnica, planeia treinos, táticas de jogo, escolhe a equipa para os jogos e monitoriza o desempenho dos jogadores.", "Treinador" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 463, DateTimeKind.Local).AddTicks(6671), null, "Gere as finanças do clube, incluindo orçamento, salários, receitas de bilheteira, patrocínios e outras fontes de receita.", "Diretor Financeiro" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 463, DateTimeKind.Local).AddTicks(6673), null, "Gere as instalações do clube, incluindo estádios, campos de treino e outras infraestruturas.", "Gestor de Infraestruturas" },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 463, DateTimeKind.Local).AddTicks(6674), null, "Trata de toda a documentação e administração necessária para o funcionamento do clube.", "Secretário" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Capacity", "DateOfCreation", "DateOfModification", "Description", "FacilityCategoryId", "Location", "Name" },
                values: new object[,]
                {
                    { 1L, 278, new DateTime(2024, 12, 30, 13, 55, 35, 529, DateTimeKind.Local).AddTicks(2889), null, "Ad velit voluptas alias sint iure voluptates voluptatum. Est error accusantium. Omnis est facilis autem non nam quidem rerum dolores eos. Animi odit recusandae iure tempora cupiditate voluptatem sed. Ullam placeat accusantium et illo necessitatibus consectetur non officiis.", 6L, "05870 Kian Stream, New Guiseppebury, France", "Licensed Plastic Pizza" },
                    { 2L, 2655, new DateTime(2024, 12, 30, 13, 55, 35, 529, DateTimeKind.Local).AddTicks(5382), null, "Pariatur rerum ipsam quis consequatur. Atque facere cupiditate voluptates minus delectus eius perferendis labore animi. Quis deserunt qui excepturi sint beatae exercitationem iure. Sint qui officia non iusto. Sunt laboriosam beatae est dolorum optio voluptatum qui architecto est.", 3L, "44650 Casper Groves, D'Amoreberg, Tunisia", "Awesome Metal Chips" },
                    { 3L, 1249, new DateTime(2024, 12, 30, 13, 55, 35, 529, DateTimeKind.Local).AddTicks(5688), null, "Quae quibusdam et doloribus numquam earum molestiae mollitia. Quibusdam repellat et rerum qui a qui est. Excepturi ea quo accusantium dolorum. Eum et excepturi et similique quaerat ipsa nihil eum enim.", 5L, "93654 Kunde Terrace, Pascaleborough, Jordan", "Practical Fresh Cheese" },
                    { 4L, 229, new DateTime(2024, 12, 30, 13, 55, 35, 529, DateTimeKind.Local).AddTicks(5930), null, "Mollitia repellat ab ea ab est voluptas omnis et temporibus. Sequi illo ut impedit quia dolor. Id quaerat fugiat suscipit autem molestias tempora molestiae eum veniam.", 2L, "269 Alexis Turnpike, Lizzieborough, Colombia", "Rustic Fresh Car" },
                    { 5L, 3637, new DateTime(2024, 12, 30, 13, 55, 35, 529, DateTimeKind.Local).AddTicks(6088), null, "Soluta qui temporibus voluptas est minima. Et reiciendis minus ut at et qui aut sequi omnis. Quis vitae ut ut et magnam neque.", 4L, "762 Amira Viaduct, Lake Agnes, Monaco", "Unbranded Frozen Table" }
                });

            migrationBuilder.InsertData(
                table: "MinorClubMember",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateOfCreation", "DateOfJoining", "DateOfModification", "Email", "FirstName", "GuardianId", "LastName", "Partner", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, "895 Marvin Hills, South Noreneborough, United States Minor Outlying Islands", new DateTime(2010, 3, 9, 13, 0, 35, 770, DateTimeKind.Local).AddTicks(3971), new DateTime(2024, 12, 30, 13, 55, 35, 470, DateTimeKind.Local).AddTicks(7953), new DateTime(2024, 4, 4, 12, 47, 33, 346, DateTimeKind.Local).AddTicks(5884), null, "Era74@gmail.com", "Elinore", 6L, "Bergnaum", true, "(221) 508-0980" },
                    { 2L, "93116 Carolina Centers, Kavonport, Saudi Arabia", new DateTime(2013, 7, 18, 9, 23, 11, 431, DateTimeKind.Local).AddTicks(6518), new DateTime(2024, 12, 30, 13, 55, 35, 470, DateTimeKind.Local).AddTicks(9480), new DateTime(2023, 3, 27, 8, 59, 36, 934, DateTimeKind.Local).AddTicks(4111), null, "Orrin_Quigley70@gmail.com", "Mozell", 5L, "Pouros", false, "(548) 414-0314 x53815" },
                    { 3L, "317 Parker Divide, Ceasarmouth, Brunei Darussalam", new DateTime(2013, 7, 28, 9, 16, 6, 260, DateTimeKind.Local).AddTicks(2279), new DateTime(2024, 12, 30, 13, 55, 35, 470, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 12, 26, 1, 29, 50, 401, DateTimeKind.Local).AddTicks(1643), null, "Dan_Lueilwitz@gmail.com", "Serenity", 4L, "Jaskolski", true, "(597) 921-2668 x252" },
                    { 4L, "07402 Bayer Landing, Bartonmouth, Peru", new DateTime(2008, 7, 19, 18, 45, 5, 657, DateTimeKind.Local).AddTicks(644), new DateTime(2024, 12, 30, 13, 55, 35, 470, DateTimeKind.Local).AddTicks(9902), new DateTime(2023, 6, 29, 8, 46, 17, 781, DateTimeKind.Local).AddTicks(5386), null, "Vanessa.Kuphal@hotmail.com", "Constance", 5L, "Flatley", false, "(994) 548-3607" }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "DateOfBirth", "DateOfCreation", "DateOfModification", "FirstName", "Height", "LastName", "Nationality", "PlayerCategoryId", "Position", "PreferredFoot", "Weight" },
                values: new object[,]
                {
                    { 1L, new DateTime(2004, 12, 8, 15, 6, 32, 148, DateTimeKind.Local).AddTicks(386), new DateTime(2024, 12, 30, 13, 55, 35, 471, DateTimeKind.Local).AddTicks(8817), null, "Electa", 194, "Hintz", "Norfolk Island", 4L, "Goalkeeper", "Right", 90 },
                    { 2L, new DateTime(1996, 10, 21, 14, 59, 10, 708, DateTimeKind.Local).AddTicks(2520), new DateTime(2024, 12, 30, 13, 55, 35, 471, DateTimeKind.Local).AddTicks(9982), null, "Kaitlyn", 173, "Raynor", "Jamaica", 3L, "Goalkeeper", "Right", 92 },
                    { 3L, new DateTime(2007, 11, 15, 17, 19, 59, 836, DateTimeKind.Local).AddTicks(1912), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(37), null, "Susie", 186, "Jenkins", "Bolivia", 4L, "Midfielder", "Both", 87 },
                    { 4L, new DateTime(1993, 2, 26, 16, 59, 53, 982, DateTimeKind.Local).AddTicks(1946), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(63), null, "Nicklaus", 182, "Stamm", "Rwanda", 4L, "Midfielder", "Both", 77 },
                    { 5L, new DateTime(2003, 2, 8, 7, 25, 52, 121, DateTimeKind.Local).AddTicks(7996), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(86), null, "Roger", 173, "Reichel", "Algeria", 5L, "Midfielder", "Right", 63 },
                    { 6L, new DateTime(2005, 9, 14, 3, 32, 50, 297, DateTimeKind.Local).AddTicks(4198), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(106), null, "Rudy", 195, "Jacobs", "Benin", 4L, "Midfielder", "Both", 94 },
                    { 7L, new DateTime(2000, 3, 27, 3, 20, 1, 124, DateTimeKind.Local).AddTicks(2687), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(149), null, "Jadon", 193, "Strosin", "Chile", 3L, "Defender", "Both", 84 },
                    { 8L, new DateTime(2006, 7, 25, 18, 33, 58, 182, DateTimeKind.Local).AddTicks(2243), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(171), null, "Eloisa", 170, "Powlowski", "Seychelles", 3L, "Midfielder", "Both", 74 },
                    { 9L, new DateTime(1989, 9, 27, 19, 21, 12, 878, DateTimeKind.Local).AddTicks(71), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(194), null, "Sarah", 179, "Gerlach", "Saint Pierre and Miquelon", 2L, "Defender", "Right", 93 },
                    { 10L, new DateTime(2003, 8, 9, 2, 31, 23, 391, DateTimeKind.Local).AddTicks(9732), new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(213), null, "Larry", 191, "Dibbert", "Cote d'Ivoire", 3L, "Forward", "Both", 75 }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "ClubId", "DateOfCreation", "DateOfModification", "Female", "Male", "Name", "TeamCategoryId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 496, DateTimeKind.Local).AddTicks(8723), null, false, true, "Beauty, Outdoors & Health migration", 1L },
                    { 2L, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 497, DateTimeKind.Local).AddTicks(7014), null, false, true, "Electronics Technician", 1L },
                    { 3L, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 498, DateTimeKind.Local).AddTicks(6864), null, true, false, "Clothing invoice", 1L },
                    { 4L, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 499, DateTimeKind.Local).AddTicks(6460), null, true, false, "Jewelery & Industrial Dam", 1L },
                    { 5L, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 500, DateTimeKind.Local).AddTicks(5404), null, false, true, "Industrial & Tools cross-platform", 9L }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "DateOfCreation", "DateOfLastAccess", "DateOfModification", "Email", "InstitutionId", "LockoutEnd", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpire", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpire", "TwoFactorActivated", "UserPermissionId", "UserRoleId", "Username" },
                values: new object[,]
                {
                    { 1L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(3805), new DateTime(2024, 12, 29, 16, 9, 53, 546, DateTimeKind.Local).AddTicks(5570), null, "Fern.Pfeffer@hotmail.com", 1L, new DateTime(2024, 5, 13, 11, 39, 28, 859, DateTimeKind.Local).AddTicks(8867), new byte[] { 68, 20, 86, 216, 105, 208, 103, 146, 143, 133, 13, 217, 87, 170, 225, 110, 237, 130, 180, 244 }, "2smj3hr5", new DateTime(2025, 7, 12, 10, 6, 51, 50, DateTimeKind.Local).AddTicks(3799), new byte[] { 49, 195, 172, 58, 54, 205, 112, 184, 167, 14, 168, 140, 94, 179, 156, 205, 133, 26, 80, 189 }, "700.661.0860 x94694", false, "lc9kxav3zk4j97tq", new DateTime(2025, 11, 21, 3, 38, 10, 963, DateTimeKind.Local).AddTicks(594), true, 1L, 6L, "Elbert56" },
                    { 2L, 5, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5018), new DateTime(2024, 12, 29, 17, 58, 48, 70, DateTimeKind.Local).AddTicks(937), null, "Reina_Harber76@gmail.com", 1L, new DateTime(2024, 12, 26, 4, 15, 18, 424, DateTimeKind.Local).AddTicks(1100), new byte[] { 85, 37, 159, 209, 5, 225, 77, 212, 250, 219, 227, 110, 244, 247, 48, 231, 190, 183, 253, 66 }, "40f2hne4", new DateTime(2025, 2, 10, 20, 10, 41, 83, DateTimeKind.Local).AddTicks(311), new byte[] { 229, 149, 156, 42, 189, 84, 214, 118, 22, 21, 153, 75, 224, 75, 250, 145, 148, 175, 40, 104 }, "564.382.7053", true, "44ci3l7b2wx3gad7", new DateTime(2025, 8, 23, 13, 51, 58, 570, DateTimeKind.Local).AddTicks(5329), false, 2L, 7L, "Sim20" },
                    { 3L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5190), new DateTime(2024, 12, 29, 16, 48, 22, 463, DateTimeKind.Local).AddTicks(6913), null, "Augusta_Reynolds3@hotmail.com", 1L, new DateTime(2024, 6, 20, 23, 28, 38, 560, DateTimeKind.Local).AddTicks(7308), new byte[] { 203, 1, 40, 34, 17, 66, 11, 126, 229, 235, 177, 47, 142, 5, 212, 251, 205, 189, 212, 76 }, "dm27iavs", new DateTime(2025, 4, 25, 23, 13, 15, 591, DateTimeKind.Local).AddTicks(5193), new byte[] { 110, 110, 228, 97, 164, 91, 87, 29, 117, 108, 3, 156, 253, 138, 120, 10, 6, 102, 128, 207 }, "791-353-2262", true, "kwazvemovoeo0mjh", new DateTime(2025, 8, 8, 0, 1, 23, 556, DateTimeKind.Local).AddTicks(4980), true, 3L, 3L, "Dangelo14" },
                    { 4L, 4, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5373), new DateTime(2024, 12, 30, 7, 9, 34, 567, DateTimeKind.Local).AddTicks(6537), null, "Kristin_Mante@hotmail.com", 1L, new DateTime(2024, 12, 13, 8, 8, 17, 38, DateTimeKind.Local).AddTicks(3582), new byte[] { 101, 64, 198, 217, 221, 148, 218, 118, 222, 132, 84, 87, 75, 49, 46, 74, 226, 144, 245, 103 }, "azlhics2", new DateTime(2025, 12, 7, 20, 58, 55, 717, DateTimeKind.Local).AddTicks(3006), new byte[] { 198, 155, 200, 124, 234, 217, 138, 144, 149, 31, 52, 50, 248, 84, 239, 11, 6, 60, 235, 159 }, "388.576.6685 x5026", true, "rxghutg7b0xjr8fe", new DateTime(2025, 10, 3, 6, 45, 33, 608, DateTimeKind.Local).AddTicks(3905), true, 4L, 6L, "Julianne.Bergstrom" },
                    { 5L, 5, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5491), new DateTime(2024, 12, 29, 17, 35, 33, 250, DateTimeKind.Local).AddTicks(9181), null, "Raul35@yahoo.com", 1L, new DateTime(2024, 3, 3, 8, 42, 14, 174, DateTimeKind.Local).AddTicks(9602), new byte[] { 99, 43, 160, 32, 227, 149, 171, 135, 60, 96, 120, 85, 67, 26, 70, 19, 62, 75, 211, 58 }, "gb1shyz6", new DateTime(2025, 5, 23, 7, 35, 20, 336, DateTimeKind.Local).AddTicks(8707), new byte[] { 89, 40, 39, 126, 56, 131, 86, 136, 142, 188, 127, 106, 10, 219, 66, 28, 14, 233, 8, 180 }, "(510) 528-4218 x253", true, "zrr0t3qag8wgrckv", new DateTime(2025, 6, 27, 0, 22, 4, 125, DateTimeKind.Local).AddTicks(3572), false, 5L, 7L, "Bernadette46" },
                    { 6L, 5, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5613), new DateTime(2024, 12, 30, 6, 50, 20, 287, DateTimeKind.Local).AddTicks(978), null, "Amanda.Sanford@yahoo.com", 1L, new DateTime(2024, 5, 12, 15, 19, 51, 862, DateTimeKind.Local).AddTicks(3625), new byte[] { 136, 154, 60, 254, 31, 154, 213, 101, 10, 60, 149, 74, 130, 109, 24, 216, 203, 114, 174, 151 }, "g7v48jt1", new DateTime(2025, 3, 1, 20, 23, 5, 722, DateTimeKind.Local).AddTicks(8648), new byte[] { 101, 171, 71, 177, 56, 127, 152, 86, 85, 74, 134, 10, 44, 52, 242, 130, 214, 177, 177, 27 }, "684-498-9784", false, "orewcle1qc0tbygb", new DateTime(2025, 10, 15, 15, 5, 46, 758, DateTimeKind.Local).AddTicks(2208), false, 6L, 3L, "Kieran.Collier" },
                    { 7L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5698), new DateTime(2024, 12, 29, 15, 14, 30, 580, DateTimeKind.Local).AddTicks(1560), null, "Heaven_Moore36@hotmail.com", 1L, new DateTime(2024, 10, 1, 10, 23, 10, 873, DateTimeKind.Local).AddTicks(2433), new byte[] { 23, 112, 245, 238, 154, 166, 64, 238, 48, 55, 111, 253, 242, 122, 75, 17, 140, 168, 86, 100 }, "zhwn72y6", new DateTime(2025, 9, 4, 9, 11, 50, 585, DateTimeKind.Local).AddTicks(3159), new byte[] { 24, 16, 190, 238, 85, 132, 19, 217, 137, 193, 73, 30, 43, 211, 102, 120, 233, 201, 99, 99 }, "499-420-2769", false, "55e3mtl6g79vses9", new DateTime(2025, 3, 26, 13, 40, 25, 734, DateTimeKind.Local).AddTicks(1456), true, 7L, 1L, "Jackson79" },
                    { 8L, 3, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5794), new DateTime(2024, 12, 29, 20, 12, 57, 779, DateTimeKind.Local).AddTicks(7717), null, "Jackson86@yahoo.com", 1L, new DateTime(2024, 10, 21, 9, 28, 31, 906, DateTimeKind.Local).AddTicks(9607), new byte[] { 30, 58, 69, 205, 208, 135, 217, 38, 88, 4, 213, 159, 127, 113, 224, 201, 90, 164, 93, 50 }, "joyfh78i", new DateTime(2025, 1, 4, 17, 14, 21, 986, DateTimeKind.Local).AddTicks(2710), new byte[] { 91, 107, 28, 3, 108, 196, 131, 134, 181, 194, 66, 221, 82, 232, 107, 39, 86, 200, 55, 221 }, "(245) 303-8265 x0093", false, "ezm0iwdc94dbj5hq", new DateTime(2025, 11, 9, 21, 3, 54, 380, DateTimeKind.Local).AddTicks(4560), false, 8L, 2L, "Julius.Terry61" },
                    { 9L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5882), new DateTime(2024, 12, 30, 11, 11, 13, 770, DateTimeKind.Local).AddTicks(2978), null, "Madge_Stamm80@gmail.com", 1L, new DateTime(2024, 8, 25, 2, 36, 57, 183, DateTimeKind.Local).AddTicks(1724), new byte[] { 51, 234, 43, 21, 123, 29, 235, 106, 11, 137, 174, 219, 242, 114, 230, 98, 250, 143, 240, 213 }, "uhpqrhii", new DateTime(2025, 2, 7, 8, 53, 37, 389, DateTimeKind.Local).AddTicks(8444), new byte[] { 103, 58, 51, 209, 200, 6, 8, 77, 156, 155, 174, 173, 167, 229, 90, 95, 207, 64, 242, 167 }, "471-904-5053 x8001", false, "sdc0d5c4dwi28ers", new DateTime(2025, 9, 7, 10, 39, 1, 373, DateTimeKind.Local).AddTicks(5986), false, 9L, 7L, "Clyde_Bergstrom" },
                    { 10L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 467, DateTimeKind.Local).AddTicks(5980), new DateTime(2024, 12, 30, 11, 52, 25, 27, DateTimeKind.Local).AddTicks(7824), null, "Alena_Rutherford95@hotmail.com", 1L, new DateTime(2024, 8, 17, 19, 45, 28, 930, DateTimeKind.Local).AddTicks(3987), new byte[] { 186, 234, 190, 164, 203, 176, 13, 31, 81, 159, 167, 216, 12, 7, 162, 110, 107, 9, 93, 0 }, "7kgu51y9", new DateTime(2025, 4, 2, 15, 48, 13, 612, DateTimeKind.Local).AddTicks(5461), new byte[] { 144, 93, 172, 130, 226, 37, 21, 27, 172, 73, 247, 216, 193, 209, 90, 35, 69, 71, 185, 2 }, "406-831-0635 x93869", false, "s5vrtugqgpeh10pm", new DateTime(2025, 3, 24, 6, 50, 38, 613, DateTimeKind.Local).AddTicks(5620), true, 10L, 6L, "Eddie_Deckow75" }
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "Id", "ClubMemberId", "DateOfCreation", "DateOfModification", "EntityName", "EntityType", "External", "Internal", "PlayerId" },
                values: new object[,]
                {
                    { 1L, 2L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(6542), null, "Kozey, Torphy and Bayer", "Club", true, false, 5L },
                    { 2L, 2L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7046), null, "Bruen - Kertzmann", "Club", true, false, 4L },
                    { 3L, 5L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7138), null, "Gerlach Group", "Club", true, true, 8L },
                    { 4L, 4L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7232), null, "Jast LLC", "Sponsor", false, true, 7L },
                    { 5L, 3L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7301), null, "Farrell and Sons", "Sponsor", true, false, 1L },
                    { 6L, 2L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7347), null, "Thiel - Ondricka", "Sponsor", true, true, 10L },
                    { 7L, 5L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7406), null, "Crona - Harvey", "Player", false, true, 9L },
                    { 8L, 2L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7449), null, "Zemlak, Macejkovic and Breitenberg", "Player", false, false, 3L },
                    { 9L, 4L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7535), null, "Nikolaus, Gutkowski and Grady", "Manager", false, false, 2L },
                    { 10L, 2L, new DateTime(2024, 12, 30, 13, 55, 35, 533, DateTimeKind.Local).AddTicks(7613), null, "Morissette, O'Kon and Labadie", "Club", true, false, 6L }
                });

            migrationBuilder.InsertData(
                table: "FacilityReservations",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "EndTime", "EventDescription", "EventType", "FacilityId", "ReservedUserId", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5435), null, new DateTime(2025, 3, 1, 22, 44, 45, 468, DateTimeKind.Local).AddTicks(6849), "Ex ea veritatis praesentium nesciunt.", "velit", 5L, 9L, new DateTime(2025, 3, 1, 18, 44, 45, 468, DateTimeKind.Local).AddTicks(6849) },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5717), null, new DateTime(2025, 5, 8, 17, 16, 50, 884, DateTimeKind.Local).AddTicks(5092), "Ad sunt veniam autem aperiam inventore animi doloribus.", "ratione", 4L, 4L, new DateTime(2025, 5, 8, 13, 16, 50, 884, DateTimeKind.Local).AddTicks(5092) },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5754), null, new DateTime(2025, 1, 27, 17, 31, 23, 317, DateTimeKind.Local).AddTicks(1478), "Deserunt omnis delectus dolore voluptas quia vitae saepe cum.", "et", 3L, 6L, new DateTime(2025, 1, 27, 15, 31, 23, 317, DateTimeKind.Local).AddTicks(1478) },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5786), null, new DateTime(2025, 8, 25, 3, 27, 39, 159, DateTimeKind.Local).AddTicks(1362), "Autem quia facilis magni dolorem accusantium ipsum reiciendis nobis doloribus.", "ipsum", 1L, 3L, new DateTime(2025, 8, 25, 1, 27, 39, 159, DateTimeKind.Local).AddTicks(1362) },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5817), null, new DateTime(2025, 2, 23, 1, 40, 53, 298, DateTimeKind.Local).AddTicks(3711), "Ducimus reiciendis quia voluptates dignissimos est et.", "et", 3L, 3L, new DateTime(2025, 2, 22, 21, 40, 53, 298, DateTimeKind.Local).AddTicks(3711) },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5844), null, new DateTime(2025, 8, 21, 4, 5, 21, 497, DateTimeKind.Local).AddTicks(4265), "Impedit possimus ut unde eos ea libero.", "eligendi", 3L, 7L, new DateTime(2025, 8, 21, 1, 5, 21, 497, DateTimeKind.Local).AddTicks(4265) },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5891), null, new DateTime(2025, 11, 7, 5, 53, 41, 242, DateTimeKind.Local).AddTicks(5229), "Enim dolor voluptas at eaque alias eligendi consequuntur veniam.", "unde", 2L, 7L, new DateTime(2025, 11, 7, 1, 53, 41, 242, DateTimeKind.Local).AddTicks(5229) },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5918), null, new DateTime(2025, 5, 7, 13, 36, 27, 558, DateTimeKind.Local).AddTicks(3924), "Magni fugiat est beatae consequatur nisi repellat enim quas.", "esse", 2L, 1L, new DateTime(2025, 5, 7, 10, 36, 27, 558, DateTimeKind.Local).AddTicks(3924) },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5944), null, new DateTime(2025, 6, 21, 0, 51, 51, 114, DateTimeKind.Local).AddTicks(1913), "Repudiandae eligendi iusto ab eum et ipsa quae officia veniam.", "hic", 4L, 1L, new DateTime(2025, 6, 20, 21, 51, 51, 114, DateTimeKind.Local).AddTicks(1913) },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 530, DateTimeKind.Local).AddTicks(5974), null, new DateTime(2025, 8, 1, 22, 55, 38, 260, DateTimeKind.Local).AddTicks(9991), "Ut rerum veritatis quibusdam ut at alias et facere corrupti.", "quod", 2L, 4L, new DateTime(2025, 8, 1, 18, 55, 38, 260, DateTimeKind.Local).AddTicks(9991) }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceHistories",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "Description", "FacilityId", "MaintenanceDate", "MaintenanceType", "RequestUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(4227), null, "Quaerat quis rerum incidunt voluptas voluptatem.", 5L, new DateTime(2024, 5, 15, 5, 1, 36, 439, DateTimeKind.Local).AddTicks(2153), "Corretiva", 2L },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(5129), null, "Atque maxime quis et et possimus.", 5L, new DateTime(2024, 4, 9, 16, 19, 26, 931, DateTimeKind.Local).AddTicks(6280), "Urgente", 8L },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(5193), null, "Beatae voluptas ut ipsa quia aut qui.", 1L, new DateTime(2024, 11, 28, 3, 58, 52, 865, DateTimeKind.Local).AddTicks(2567), "Corretiva", 2L },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(5220), null, "Accusantium voluptatem velit non et quaerat aut veniam quaerat vitae.", 4L, new DateTime(2024, 6, 30, 2, 11, 46, 675, DateTimeKind.Local).AddTicks(4267), "Urgente", 6L },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(5247), null, "Harum atque velit numquam quo est.", 4L, new DateTime(2024, 1, 24, 12, 12, 28, 804, DateTimeKind.Local).AddTicks(1881), "Preventiva", 2L },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(5267), null, "Aut rerum eum totam dolore.", 4L, new DateTime(2024, 4, 24, 2, 59, 36, 668, DateTimeKind.Local).AddTicks(5397), "Corretiva", 8L },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(5289), null, "Quo esse qui hic reiciendis voluptatem.", 3L, new DateTime(2024, 4, 19, 13, 22, 59, 401, DateTimeKind.Local).AddTicks(569), "Corretiva", 10L },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 531, DateTimeKind.Local).AddTicks(5307), null, "Nostrum ea et quisquam pariatur aut eaque consectetur.", 1L, new DateTime(2024, 2, 28, 14, 38, 8, 146, DateTimeKind.Local).AddTicks(2852), "Preventiva", 5L }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "FacilityId", "MaintenanceType", "Priority", "ProblemDescription", "RequestDate", "RequestedUserId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(3705), null, 5L, "Hidráulica", "Média", "Voluptatem dicta ex laboriosam. Aut reiciendis quia. Dolores esse sunt labore sed rerum qui et sint. Saepe omnis assumenda ducimus sint eos tempore doloremque accusantium. Ut aut doloremque quis quisquam sequi dolorem.", new DateTime(2023, 7, 27, 22, 7, 31, 201, DateTimeKind.Local).AddTicks(673), 5L, "Em Andamento" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(4525), null, 1L, "Estrutural", "Baixa", "Praesentium illo et quisquam qui voluptate quod. Excepturi dolores nesciunt. Voluptates doloribus nobis rerum at quo. Quam eum aut.", new DateTime(2024, 7, 11, 12, 34, 41, 390, DateTimeKind.Local).AddTicks(7934), 6L, "Em Andamento" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(4644), null, 5L, "Estrutural", "Alta", "Est minima maiores blanditiis dolore animi dolor. Cumque quasi blanditiis sed qui sed non id. Quae recusandae suscipit ipsam et beatae assumenda nobis. Non et vero veritatis. Earum perspiciatis tempora nesciunt dolor asperiores neque.", new DateTime(2024, 4, 12, 2, 9, 29, 147, DateTimeKind.Local).AddTicks(6860), 10L, "Em Andamento" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(4779), null, 1L, "Hidráulica", "Alta", "Ut alias facere est rerum enim. Qui fugit assumenda nihil labore aut aut pariatur fuga animi. Odit quos dolorem velit. Architecto aut maiores consequuntur expedita nobis ipsum non voluptas omnis.", new DateTime(2024, 5, 9, 10, 13, 18, 416, DateTimeKind.Local).AddTicks(6688), 4L, "Cancelado" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(4943), null, 5L, "Estrutural", "Baixa", "Ex reiciendis quia et aperiam velit eius dolore dignissimos aut. Dolores sapiente accusamus quo labore. Est totam iure accusamus dolor libero sunt est. In minima nulla odio reprehenderit. Sunt sit incidunt doloremque error ad.", new DateTime(2023, 8, 28, 22, 28, 6, 636, DateTimeKind.Local).AddTicks(7188), 10L, "Concluído" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(5020), null, 5L, "Hidráulica", "Alta", "Et iure veniam dolore quibusdam veniam. Possimus voluptatem aut qui qui. Eveniet rerum amet distinctio non occaecati est ad quibusdam.", new DateTime(2023, 9, 21, 1, 5, 39, 808, DateTimeKind.Local).AddTicks(7800), 8L, "Em Andamento" },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(5090), null, 4L, "Hidráulica", "Média", "Et quasi culpa adipisci et eum numquam libero nam. Culpa earum laudantium reprehenderit quo et delectus. Consectetur exercitationem ipsa deleniti est neque aut sint sint explicabo. Ut sint libero asperiores cumque quam voluptatem nisi. Et laboriosam voluptatem eum.", new DateTime(2023, 10, 5, 21, 43, 9, 524, DateTimeKind.Local).AddTicks(9536), 8L, "Cancelado" },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(5172), null, 4L, "Hidráulica", "Média", "Ut fuga accusantium praesentium tempora quae qui et. Aperiam temporibus ullam aliquam aut voluptate minima atque quis culpa. Quo accusantium alias rem neque consequuntur aut sequi corporis. Officiis placeat ut. Laboriosam quaerat ratione repellat totam aut qui.", new DateTime(2023, 10, 21, 6, 9, 15, 47, DateTimeKind.Local).AddTicks(1843), 2L, "Aberto" },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(5260), null, 4L, "Hidráulica", "Alta", "Dignissimos repellendus eos doloremque qui. Fugiat iure beatae temporibus ea non. Nam et corrupti quia reiciendis.", new DateTime(2024, 7, 31, 17, 50, 24, 636, DateTimeKind.Local).AddTicks(2378), 1L, "Cancelado" },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(5300), null, 4L, "Elétrica", "Média", "Temporibus officia nobis perspiciatis omnis reprehenderit nihil repudiandae molestiae. Facilis incidunt dolorem facilis et placeat ipsam explicabo recusandae qui. Maxime modi at repellat sunt neque similique vel hic. Hic ipsum odit quas.", new DateTime(2024, 7, 21, 2, 0, 9, 859, DateTimeKind.Local).AddTicks(245), 6L, "Concluído" },
                    { 11L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(5397), null, 5L, "Estrutural", "Baixa", "Optio accusamus consequatur. Vel repellat maxime quam quasi numquam magni. Occaecati quo quod. Assumenda aut tempora atque et iusto placeat temporibus quod. Placeat non ratione quod eum explicabo corrupti deserunt quidem cupiditate.", new DateTime(2024, 12, 22, 20, 1, 7, 327, DateTimeKind.Local).AddTicks(4928), 6L, "Cancelado" },
                    { 12L, new DateTime(2024, 12, 30, 13, 55, 35, 532, DateTimeKind.Local).AddTicks(5483), null, 3L, "Estrutural", "Alta", "Quae ea ea repellat. Facere expedita necessitatibus totam at cupiditate odit. Ut sint reiciendis voluptates est. In rerum aut accusantium.", new DateTime(2023, 4, 20, 6, 50, 13, 46, DateTimeKind.Local).AddTicks(9086), 5L, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "CompetitionType", "Date", "DateOfCreation", "DateOfModification", "IsCanceled", "Location", "Opponent", "TeamId" },
                values: new object[,]
                {
                    { 1L, "League", new DateTime(2025, 4, 27, 9, 26, 45, 384, DateTimeKind.Local).AddTicks(3626), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(482), null, true, "Welchborough", "Jewelery & Industrial Dam", 5L },
                    { 2L, "Friendly", new DateTime(2025, 9, 24, 17, 5, 54, 228, DateTimeKind.Local).AddTicks(4425), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2154), null, false, "Wunschbury", "Beauty, Outdoors & Health migration", 5L },
                    { 3L, "League", new DateTime(2025, 4, 16, 7, 11, 28, 293, DateTimeKind.Local).AddTicks(6319), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2257), null, false, "Robertschester", "Clothing invoice", 2L },
                    { 4L, "League", new DateTime(2025, 12, 1, 12, 12, 49, 639, DateTimeKind.Local).AddTicks(2106), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2298), null, true, "Lake Craigview", "Clothing invoice", 1L },
                    { 5L, "Friendly", new DateTime(2025, 10, 16, 23, 45, 59, 508, DateTimeKind.Local).AddTicks(7266), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2381), null, true, "North Alec", "Beauty, Outdoors & Health migration", 4L },
                    { 6L, "Friendly", new DateTime(2025, 8, 7, 4, 42, 21, 710, DateTimeKind.Local).AddTicks(4724), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2409), null, false, "Lake Kenyatta", "Clothing invoice", 1L },
                    { 7L, "Friendly", new DateTime(2025, 11, 7, 9, 7, 40, 441, DateTimeKind.Local).AddTicks(1200), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2458), null, false, "Bergehaven", "Jewelery & Industrial Dam", 4L },
                    { 8L, "Friendly", new DateTime(2025, 12, 14, 20, 11, 49, 684, DateTimeKind.Local).AddTicks(1986), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2483), null, true, "Karliestad", "Clothing invoice", 3L },
                    { 9L, "Friendly", new DateTime(2025, 7, 7, 14, 3, 38, 908, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2509), null, false, "Lake Kamillemouth", "Electronics Technician", 4L },
                    { 10L, "Cup", new DateTime(2025, 7, 16, 3, 45, 14, 13, DateTimeKind.Local).AddTicks(7839), new DateTime(2024, 12, 30, 13, 55, 35, 537, DateTimeKind.Local).AddTicks(2561), null, true, "New Elliott", "Beauty, Outdoors & Health migration", 5L }
                });

            migrationBuilder.InsertData(
                table: "PlayerContract",
                columns: new[] { "Id", "ContractType", "DateOfCreation", "DateOfModification", "EndDate", "PlayerId", "Salary", "StartDate" },
                values: new object[,]
                {
                    { 1L, "Youth", new DateTime(2024, 12, 30, 13, 55, 35, 472, DateTimeKind.Local).AddTicks(8530), null, new DateTime(2026, 9, 8, 19, 50, 24, 723, DateTimeKind.Local).AddTicks(522), 9L, 78476.04m, new DateTime(2023, 9, 8, 19, 50, 24, 723, DateTimeKind.Local).AddTicks(522) },
                    { 2L, "Youth", new DateTime(2024, 12, 30, 13, 55, 35, 473, DateTimeKind.Local).AddTicks(444), null, new DateTime(2027, 5, 5, 6, 5, 25, 921, DateTimeKind.Local).AddTicks(5504), 8L, 408826.11m, new DateTime(2024, 5, 5, 6, 5, 25, 921, DateTimeKind.Local).AddTicks(5504) },
                    { 3L, "Amateur", new DateTime(2024, 12, 30, 13, 55, 35, 473, DateTimeKind.Local).AddTicks(486), null, new DateTime(2028, 1, 10, 2, 34, 10, 519, DateTimeKind.Local).AddTicks(5498), 10L, 81609.23m, new DateTime(2023, 1, 10, 2, 34, 10, 519, DateTimeKind.Local).AddTicks(5498) },
                    { 4L, "Youth", new DateTime(2024, 12, 30, 13, 55, 35, 473, DateTimeKind.Local).AddTicks(496), null, new DateTime(2028, 7, 8, 1, 2, 24, 920, DateTimeKind.Local).AddTicks(9365), 4L, 207078.73m, new DateTime(2023, 7, 8, 1, 2, 24, 920, DateTimeKind.Local).AddTicks(9365) },
                    { 5L, "Amateur", new DateTime(2024, 12, 30, 13, 55, 35, 473, DateTimeKind.Local).AddTicks(504), null, new DateTime(2027, 12, 6, 1, 5, 51, 793, DateTimeKind.Local).AddTicks(5150), 1L, 465876.17m, new DateTime(2024, 12, 6, 1, 5, 51, 793, DateTimeKind.Local).AddTicks(5150) }
                });

            migrationBuilder.InsertData(
                table: "PlayerPerformanceHistory",
                columns: new[] { "Id", "Assists", "ClubOpponent", "DateOfCreation", "DateOfModification", "Goals", "MinutesPlayed", "PlayerId", "RedCards", "Season", "YellowCards" },
                values: new object[,]
                {
                    { 1L, 12, "Cremin and Sons", new DateTime(2024, 12, 30, 13, 55, 35, 473, DateTimeKind.Local).AddTicks(8938), null, 8, 15, 1L, 0, "2024/2025", 3 },
                    { 2L, 11, "Bartell, Fadel and Fritsch", new DateTime(2024, 12, 30, 13, 55, 35, 473, DateTimeKind.Local).AddTicks(9936), null, 17, 52, 5L, 0, "2024/2025", 2 },
                    { 3L, 4, "Bednar Group", new DateTime(2024, 12, 30, 13, 55, 35, 474, DateTimeKind.Local).AddTicks(36), null, 16, 23, 2L, 0, "2024/2025", 3 },
                    { 4L, 15, "Johns, Toy and Wisoky", new DateTime(2024, 12, 30, 13, 55, 35, 474, DateTimeKind.Local).AddTicks(112), null, 0, 34, 8L, 1, "2024/2025", 1 },
                    { 5L, 4, "Connelly, Grady and Bogan", new DateTime(2024, 12, 30, 13, 55, 35, 474, DateTimeKind.Local).AddTicks(180), null, 19, 25, 3L, 1, "2024/2025", 1 },
                    { 6L, 7, "Barton, Ondricka and Hand", new DateTime(2024, 12, 30, 13, 55, 35, 474, DateTimeKind.Local).AddTicks(255), null, 0, 26, 9L, 1, "2024/2025", 5 },
                    { 7L, 15, "Bode Group", new DateTime(2024, 12, 30, 13, 55, 35, 474, DateTimeKind.Local).AddTicks(333), null, 9, 57, 1L, 1, "2024/2025", 4 },
                    { 8L, 13, "Bechtelar, Hammes and Williamson", new DateTime(2024, 12, 30, 13, 55, 35, 474, DateTimeKind.Local).AddTicks(377), null, 15, 47, 2L, 1, "2024/2025", 2 }
                });

            migrationBuilder.InsertData(
                table: "PlayerResponsible",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "IsPrimaryContact", "MemberId", "PlayerId", "Relationship" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 475, DateTimeKind.Local).AddTicks(9330), null, true, 3L, 1L, "Relative" },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 476, DateTimeKind.Local).AddTicks(7530), null, false, 1L, 1L, "Guardian" },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 477, DateTimeKind.Local).AddTicks(5860), null, false, 3L, 2L, "Guardian" },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 478, DateTimeKind.Local).AddTicks(4010), null, true, 4L, 2L, "Coach" },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 479, DateTimeKind.Local).AddTicks(2121), null, true, 1L, 3L, "Coach" },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 479, DateTimeKind.Local).AddTicks(9987), null, false, 5L, 3L, "Relative" },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 480, DateTimeKind.Local).AddTicks(7950), null, true, 5L, 4L, "Parent" },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 481, DateTimeKind.Local).AddTicks(5868), null, true, 6L, 4L, "Coach" },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 482, DateTimeKind.Local).AddTicks(4364), null, true, 5L, 5L, "Relative" },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 483, DateTimeKind.Local).AddTicks(3019), null, false, 4L, 5L, "Guardian" },
                    { 11L, new DateTime(2024, 12, 30, 13, 55, 35, 484, DateTimeKind.Local).AddTicks(1078), null, true, 4L, 6L, "Parent" },
                    { 12L, new DateTime(2024, 12, 30, 13, 55, 35, 484, DateTimeKind.Local).AddTicks(8964), null, false, 5L, 6L, "Relative" },
                    { 13L, new DateTime(2024, 12, 30, 13, 55, 35, 485, DateTimeKind.Local).AddTicks(7034), null, false, 2L, 7L, "Coach" },
                    { 14L, new DateTime(2024, 12, 30, 13, 55, 35, 486, DateTimeKind.Local).AddTicks(4991), null, true, 5L, 7L, "Coach" },
                    { 15L, new DateTime(2024, 12, 30, 13, 55, 35, 487, DateTimeKind.Local).AddTicks(3054), null, true, 1L, 8L, "Relative" },
                    { 16L, new DateTime(2024, 12, 30, 13, 55, 35, 488, DateTimeKind.Local).AddTicks(1148), null, false, 2L, 8L, "Guardian" },
                    { 17L, new DateTime(2024, 12, 30, 13, 55, 35, 488, DateTimeKind.Local).AddTicks(9069), null, true, 3L, 9L, "Relative" },
                    { 18L, new DateTime(2024, 12, 30, 13, 55, 35, 489, DateTimeKind.Local).AddTicks(6998), null, false, 2L, 9L, "Parent" },
                    { 19L, new DateTime(2024, 12, 30, 13, 55, 35, 490, DateTimeKind.Local).AddTicks(4978), null, false, 3L, 10L, "Parent" },
                    { 20L, new DateTime(2024, 12, 30, 13, 55, 35, 491, DateTimeKind.Local).AddTicks(2874), null, false, 2L, 10L, "Guardian" }
                });

            migrationBuilder.InsertData(
                table: "PlayerTransfer",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "FromClub", "PlayerId", "ToClub", "TransferDate", "TransferFee" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 474, DateTimeKind.Local).AddTicks(8785), null, "Friesen LLC", 4L, "Cruickshank, Wisoky and Leuschke", new DateTime(2024, 1, 18, 11, 17, 35, 848, DateTimeKind.Local).AddTicks(6692), 8546081.34m },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 475, DateTimeKind.Local).AddTicks(541), null, "Gibson, Volkman and Harvey", 2L, "Dach - Wiegand", new DateTime(2024, 3, 17, 8, 3, 14, 254, DateTimeKind.Local).AddTicks(6792), 3093475.66m },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 475, DateTimeKind.Local).AddTicks(768), null, "Adams - Hamill", 8L, "Bruen - Bergnaum", new DateTime(2024, 3, 15, 11, 55, 41, 269, DateTimeKind.Local).AddTicks(6953), 6098127.41m }
                });

            migrationBuilder.InsertData(
                table: "TeamCoach",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "IsHeadCoach", "TeamId", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 501, DateTimeKind.Local).AddTicks(4378), null, false, 1L, 4L },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 502, DateTimeKind.Local).AddTicks(2344), null, true, 1L, 2L },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 503, DateTimeKind.Local).AddTicks(542), null, true, 2L, 2L },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 503, DateTimeKind.Local).AddTicks(8425), null, false, 2L, 1L },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 504, DateTimeKind.Local).AddTicks(6355), null, false, 3L, 2L },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 505, DateTimeKind.Local).AddTicks(4246), null, false, 3L, 1L },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 506, DateTimeKind.Local).AddTicks(2162), null, true, 4L, 8L },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 507, DateTimeKind.Local).AddTicks(38), null, false, 4L, 6L },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 507, DateTimeKind.Local).AddTicks(7982), null, false, 5L, 1L },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 508, DateTimeKind.Local).AddTicks(6064), null, true, 5L, 4L }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayer",
                columns: new[] { "Id", "DateOfCreation", "DateOfModification", "PlayerId", "TeamId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 30, 13, 55, 35, 509, DateTimeKind.Local).AddTicks(4303), null, 5L, 1L },
                    { 2L, new DateTime(2024, 12, 30, 13, 55, 35, 510, DateTimeKind.Local).AddTicks(2211), null, 3L, 1L },
                    { 3L, new DateTime(2024, 12, 30, 13, 55, 35, 510, DateTimeKind.Local).AddTicks(9951), null, 10L, 1L },
                    { 4L, new DateTime(2024, 12, 30, 13, 55, 35, 511, DateTimeKind.Local).AddTicks(7740), null, 6L, 1L },
                    { 5L, new DateTime(2024, 12, 30, 13, 55, 35, 512, DateTimeKind.Local).AddTicks(5560), null, 4L, 1L },
                    { 6L, new DateTime(2024, 12, 30, 13, 55, 35, 513, DateTimeKind.Local).AddTicks(3496), null, 2L, 2L },
                    { 7L, new DateTime(2024, 12, 30, 13, 55, 35, 514, DateTimeKind.Local).AddTicks(1574), null, 1L, 2L },
                    { 8L, new DateTime(2024, 12, 30, 13, 55, 35, 514, DateTimeKind.Local).AddTicks(9637), null, 5L, 2L },
                    { 9L, new DateTime(2024, 12, 30, 13, 55, 35, 515, DateTimeKind.Local).AddTicks(7539), null, 9L, 2L },
                    { 10L, new DateTime(2024, 12, 30, 13, 55, 35, 516, DateTimeKind.Local).AddTicks(5945), null, 3L, 2L },
                    { 11L, new DateTime(2024, 12, 30, 13, 55, 35, 517, DateTimeKind.Local).AddTicks(3974), null, 8L, 3L },
                    { 12L, new DateTime(2024, 12, 30, 13, 55, 35, 518, DateTimeKind.Local).AddTicks(1815), null, 3L, 3L },
                    { 13L, new DateTime(2024, 12, 30, 13, 55, 35, 518, DateTimeKind.Local).AddTicks(9492), null, 2L, 3L },
                    { 14L, new DateTime(2024, 12, 30, 13, 55, 35, 519, DateTimeKind.Local).AddTicks(7316), null, 4L, 3L },
                    { 15L, new DateTime(2024, 12, 30, 13, 55, 35, 520, DateTimeKind.Local).AddTicks(5323), null, 1L, 3L },
                    { 16L, new DateTime(2024, 12, 30, 13, 55, 35, 521, DateTimeKind.Local).AddTicks(3182), null, 10L, 4L },
                    { 17L, new DateTime(2024, 12, 30, 13, 55, 35, 522, DateTimeKind.Local).AddTicks(936), null, 2L, 4L },
                    { 18L, new DateTime(2024, 12, 30, 13, 55, 35, 522, DateTimeKind.Local).AddTicks(8657), null, 7L, 4L },
                    { 19L, new DateTime(2024, 12, 30, 13, 55, 35, 523, DateTimeKind.Local).AddTicks(6738), null, 9L, 4L },
                    { 20L, new DateTime(2024, 12, 30, 13, 55, 35, 524, DateTimeKind.Local).AddTicks(4636), null, 4L, 4L },
                    { 21L, new DateTime(2024, 12, 30, 13, 55, 35, 525, DateTimeKind.Local).AddTicks(2445), null, 4L, 5L },
                    { 22L, new DateTime(2024, 12, 30, 13, 55, 35, 526, DateTimeKind.Local).AddTicks(139), null, 8L, 5L },
                    { 23L, new DateTime(2024, 12, 30, 13, 55, 35, 526, DateTimeKind.Local).AddTicks(8034), null, 9L, 5L },
                    { 24L, new DateTime(2024, 12, 30, 13, 55, 35, 527, DateTimeKind.Local).AddTicks(5835), null, 7L, 5L },
                    { 25L, new DateTime(2024, 12, 30, 13, 55, 35, 528, DateTimeKind.Local).AddTicks(3697), null, 10L, 5L }
                });

            migrationBuilder.InsertData(
                table: "TrainingSessions",
                columns: new[] { "Id", "Date", "DateOfCreation", "DateOfModification", "Description", "Duration", "IsCanceled", "Location", "Name", "Objectives", "TeamId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 20, 11, 7, 32, 252, DateTimeKind.Local).AddTicks(4112), new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(9739), null, "Nostrum impedit ducimus sed. Voluptatem sed quidem eos. Rerum quod possimus. Cupiditate error est deserunt eos rerum. Molestiae ea non explicabo non officia pariatur autem. Iste in et nihil molestiae quod perferendis.", 106, true, "Port Donnellside", "bus", "Eos aut atque distinctio est.", 5L },
                    { 2L, new DateTime(2025, 7, 27, 3, 59, 6, 907, DateTimeKind.Local).AddTicks(4346), new DateTime(2024, 12, 30, 13, 55, 35, 539, DateTimeKind.Local).AddTicks(1932), null, "Et dicta error et esse molestiae. Est illum sed non quia. Et quidem veritatis voluptatibus ex. Itaque consectetur officia est quia commodi neque odit. Est est et.", 83, true, "East Chaya", "application", "Nesciunt aut sit hic voluptate magni minus nostrum et omnis.", 5L },
                    { 3L, new DateTime(2025, 7, 26, 4, 4, 29, 819, DateTimeKind.Local).AddTicks(714), new DateTime(2024, 12, 30, 13, 55, 35, 539, DateTimeKind.Local).AddTicks(2158), null, "Dolorem exercitationem blanditiis sunt possimus. Rerum dolorem aut quia quas rerum sunt. Id omnis nihil.", 82, true, "Hettingermouth", "interface", "Numquam pariatur id est quis impedit ut.", 5L },
                    { 4L, new DateTime(2025, 2, 25, 11, 26, 32, 90, DateTimeKind.Local).AddTicks(8228), new DateTime(2024, 12, 30, 13, 55, 35, 539, DateTimeKind.Local).AddTicks(2240), null, "Quia voluptas tenetur. Nihil eaque sit nulla. Excepturi vitae tempora fugiat molestias optio temporibus illo quibusdam vero. Libero omnis corporis. Ad sequi occaecati sunt mollitia harum. Sequi debitis provident non ullam quas nobis molestiae.", 69, false, "Lake Audie", "microchip", "Voluptas hic itaque sit saepe consequatur magnam deleniti rerum.", 3L },
                    { 5L, new DateTime(2025, 9, 16, 17, 13, 49, 188, DateTimeKind.Local).AddTicks(3194), new DateTime(2024, 12, 30, 13, 55, 35, 539, DateTimeKind.Local).AddTicks(2401), null, "Enim vel itaque eos est qui quaerat omnis adipisci. Aliquam repellendus quasi consequatur doloribus possimus necessitatibus ipsa est. Rerum magni ipsum velit beatae accusamus aperiam occaecati quo.", 111, false, "Randiville", "hard drive", "Aperiam odio aut modi minima.", 2L }
                });

            migrationBuilder.InsertData(
                table: "UserClubMembers",
                columns: new[] { "Id", "ClubMemberId", "DateOfCreation", "DateOfModification", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 492, DateTimeKind.Local).AddTicks(979), null, 1L },
                    { 2L, 2L, new DateTime(2024, 12, 30, 13, 55, 35, 492, DateTimeKind.Local).AddTicks(8815), null, 2L },
                    { 3L, 3L, new DateTime(2024, 12, 30, 13, 55, 35, 493, DateTimeKind.Local).AddTicks(6821), null, 3L },
                    { 4L, 4L, new DateTime(2024, 12, 30, 13, 55, 35, 494, DateTimeKind.Local).AddTicks(4699), null, 4L },
                    { 5L, 5L, new DateTime(2024, 12, 30, 13, 55, 35, 495, DateTimeKind.Local).AddTicks(2685), null, 5L },
                    { 6L, 6L, new DateTime(2024, 12, 30, 13, 55, 35, 496, DateTimeKind.Local).AddTicks(401), null, 6L }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "DateOfCreation", "DateOfModification", "Description", "Destination", "EntityId", "ExpenseDate", "PaymentReference", "ResponsibleUserId" },
                values: new object[,]
                {
                    { 1L, 776.91m, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(6056), null, "Enim ad consequuntur sint qui libero.", "DuBuque, Monahan and Effertz", 5L, new DateTime(2024, 9, 29, 10, 48, 12, 505, DateTimeKind.Local).AddTicks(6573), "677198692021858403", 4L },
                    { 2L, 548.50m, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(7958), null, "Rerum nisi eum odit accusantium fugiat dolorum.", "Pacocha, Jenkins and Ferry", 10L, new DateTime(2024, 11, 22, 23, 45, 20, 884, DateTimeKind.Local).AddTicks(8235), "3528-8752-7163-2269", 7L },
                    { 3L, 927.97m, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(8261), null, "Rerum atque quod.", "Hermann LLC", 5L, new DateTime(2024, 10, 11, 7, 13, 47, 657, DateTimeKind.Local).AddTicks(6697), "630481191356908748", 10L },
                    { 4L, 516.05m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(8519), null, "Nulla illo perferendis officiis est.", "Brekke - O'Keefe", 6L, new DateTime(2024, 4, 22, 12, 37, 39, 24, DateTimeKind.Local).AddTicks(3727), "4235-1280-1834-2731", 2L },
                    { 5L, 977.70m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(8722), null, "Vero porro eum dolorem soluta.", "Mohr, Collins and Dickens", 2L, new DateTime(2024, 11, 20, 4, 58, 28, 428, DateTimeKind.Local).AddTicks(5849), "6759-6325-0809-2475", 5L },
                    { 6L, 384.71m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(8927), null, "Quia eos modi.", "Tromp and Sons", 1L, new DateTime(2024, 7, 31, 9, 4, 26, 351, DateTimeKind.Local).AddTicks(1891), "4495774228082", 3L },
                    { 7L, 122.48m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(9110), null, "Quam eaque minus vel minima temporibus atque voluptatum exercitationem consequuntur.", "Koelpin and Sons", 10L, new DateTime(2024, 11, 12, 8, 59, 51, 36, DateTimeKind.Local).AddTicks(2286), "3638-916172-3361", 9L },
                    { 8L, 407.63m, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(9310), null, "Incidunt dolores expedita reprehenderit eos facere quo vel.", "Gutkowski, Waters and Hoeger", 1L, new DateTime(2024, 8, 30, 12, 58, 44, 254, DateTimeKind.Local).AddTicks(9652), "6511-6219-9506-3844-8968", 6L },
                    { 9L, 620.39m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(9553), null, "Magnam et ipsum qui.", "Conn - Sawayn", 3L, new DateTime(2024, 5, 13, 9, 7, 42, 193, DateTimeKind.Local).AddTicks(4005), "3550-4654-7649-2213", 1L },
                    { 10L, 537.14m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 534, DateTimeKind.Local).AddTicks(9737), null, "Aliquid veritatis harum saepe iste laborum similique qui.", "Bartoletti, Parisian and Schroeder", 2L, new DateTime(2024, 1, 6, 13, 49, 24, 44, DateTimeKind.Local).AddTicks(4995), "6759-8744-7043-4913-14", 8L }
                });

            migrationBuilder.InsertData(
                table: "MatchStatistics",
                columns: new[] { "Id", "Assists", "DateOfCreation", "DateOfModification", "Goals", "MatchId", "MinutesPlayed", "PlayerId", "RedCards", "Substitutions", "YellowCards" },
                values: new object[,]
                {
                    { 1L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1064), null, 0, 7L, 74, 1L, 1, 0, 0 },
                    { 2L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1256), null, 2, 5L, 83, 5L, 0, 0, 1 },
                    { 3L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1269), null, 3, 3L, 87, 5L, 1, 2, 2 },
                    { 4L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1277), null, 1, 4L, 48, 7L, 0, 2, 0 },
                    { 5L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1286), null, 3, 4L, 66, 4L, 0, 2, 2 },
                    { 6L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1293), null, 0, 7L, 70, 5L, 1, 0, 1 },
                    { 7L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1312), null, 2, 6L, 84, 8L, 1, 3, 1 },
                    { 8L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1319), null, 3, 1L, 65, 2L, 0, 0, 1 },
                    { 9L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1325), null, 1, 7L, 64, 8L, 0, 2, 1 },
                    { 10L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1331), null, 3, 8L, 50, 5L, 1, 2, 0 },
                    { 11L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1337), null, 2, 9L, 52, 8L, 0, 1, 1 },
                    { 12L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1343), null, 3, 8L, 60, 3L, 0, 2, 2 },
                    { 13L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1351), null, 0, 9L, 78, 6L, 1, 3, 0 },
                    { 14L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1357), null, 3, 8L, 86, 1L, 1, 0, 0 },
                    { 15L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1363), null, 0, 2L, 54, 10L, 1, 1, 2 },
                    { 16L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1369), null, 0, 10L, 85, 10L, 0, 1, 2 },
                    { 17L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1375), null, 2, 9L, 53, 5L, 0, 1, 2 },
                    { 18L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1382), null, 3, 8L, 53, 10L, 1, 1, 1 },
                    { 19L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1388), null, 0, 5L, 49, 4L, 1, 0, 2 },
                    { 20L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1394), null, 3, 8L, 75, 8L, 1, 1, 1 },
                    { 21L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1400), null, 3, 1L, 51, 4L, 0, 3, 2 },
                    { 22L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1406), null, 3, 9L, 45, 3L, 0, 3, 2 },
                    { 23L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1412), null, 1, 9L, 50, 8L, 0, 0, 1 },
                    { 24L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1419), null, 2, 2L, 48, 8L, 1, 2, 2 },
                    { 25L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1425), null, 2, 5L, 47, 6L, 0, 3, 1 },
                    { 26L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1431), null, 3, 9L, 82, 9L, 1, 0, 1 },
                    { 27L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1437), null, 1, 3L, 68, 8L, 1, 0, 0 },
                    { 28L, 1, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1443), null, 3, 10L, 84, 3L, 1, 2, 0 },
                    { 29L, 0, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1449), null, 0, 8L, 66, 3L, 1, 2, 0 },
                    { 30L, 2, new DateTime(2024, 12, 30, 13, 55, 35, 538, DateTimeKind.Local).AddTicks(1455), null, 1, 6L, 55, 5L, 1, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Revenues",
                columns: new[] { "Id", "Amount", "CategoryId", "DateOfCreation", "DateOfModification", "Description", "EntityId", "PaymentReference", "ResponsibleUserId", "RevenueDate", "Source" },
                values: new object[,]
                {
                    { 1L, 3535.84m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 535, DateTimeKind.Local).AddTicks(8560), null, "Et voluptatem quaerat est.", 10L, "6706305632319174023", 5L, new DateTime(2024, 3, 12, 20, 35, 46, 790, DateTimeKind.Local).AddTicks(2107), "Weber Inc" },
                    { 2L, 1399.83m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(150), null, "Ut consectetur ut ut et et fugiat unde quisquam ipsum.", 6L, "6394-4417-3445-1781", 6L, new DateTime(2024, 6, 28, 23, 8, 55, 453, DateTimeKind.Local).AddTicks(8422), "Koelpin, O'Connell and Kreiger" },
                    { 3L, 1016.49m, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(459), null, "Sapiente provident quasi.", 2L, "6390-0380-1230-0583", 9L, new DateTime(2024, 5, 20, 19, 54, 3, 820, DateTimeKind.Local).AddTicks(42), "Baumbach - Ward" },
                    { 4L, 2146.21m, 1L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(672), null, "Vitae repellendus architecto a.", 9L, "6771606463824522", 1L, new DateTime(2024, 7, 26, 16, 51, 1, 974, DateTimeKind.Local).AddTicks(7313), "Balistreri - Gorczany" },
                    { 5L, 643.14m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(863), null, "Iusto architecto accusantium maiores excepturi voluptatem modi.", 8L, "3723-845339-51990", 4L, new DateTime(2024, 1, 11, 20, 20, 4, 10, DateTimeKind.Local).AddTicks(590), "Huel LLC" },
                    { 6L, 3282.54m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(1154), null, "Odit velit minus molestiae et.", 2L, "3773-017810-44273", 3L, new DateTime(2024, 4, 27, 19, 35, 47, 859, DateTimeKind.Local).AddTicks(1585), "Denesik - Homenick" },
                    { 7L, 4254.08m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(1342), null, "Ipsa voluptatem perspiciatis doloribus temporibus omnis excepturi quia.", 2L, "6771905742282081796", 8L, new DateTime(2024, 2, 21, 15, 59, 10, 457, DateTimeKind.Local).AddTicks(9899), "Hoeger Inc" },
                    { 8L, 1411.13m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(1567), null, "Cumque quod quae rem et vel nobis ratione ad commodi.", 1L, "6709701935150320", 7L, new DateTime(2024, 9, 21, 1, 39, 21, 892, DateTimeKind.Local).AddTicks(1615), "Kihn, Witting and Willms" },
                    { 9L, 1321.96m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(1785), null, "Quis quis sint voluptatem incidunt quam accusantium facilis maxime.", 9L, "630461429528876847", 2L, new DateTime(2024, 5, 23, 11, 21, 55, 66, DateTimeKind.Local).AddTicks(3819), "Nienow Inc" },
                    { 10L, 2735.25m, 15L, new DateTime(2024, 12, 30, 13, 55, 35, 536, DateTimeKind.Local).AddTicks(1968), null, "Quia omnis explicabo rerum nisi provident tempore.", 1L, "6771963130641023", 10L, new DateTime(2024, 3, 2, 17, 6, 35, 558, DateTimeKind.Local).AddTicks(5515), "Blick - McDermott" }
                });

            migrationBuilder.InsertData(
                table: "TrainingAttendances",
                columns: new[] { "Id", "AbsenceReason", "DateOfCreation", "DateOfModification", "IsPresent", "PlayerId", "TrainingSessionId" },
                values: new object[,]
                {
                    { 1L, "Cumque harum voluptatem est quo minus culpa quo.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(672), null, true, 8L, 1L },
                    { 2L, "Iste cum at est et omnis.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(1909), null, false, 4L, 5L },
                    { 3L, "A unde veritatis officia occaecati labore officiis consequuntur blanditiis.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(1965), null, true, 3L, 4L },
                    { 4L, "Laborum molestiae cumque et consequatur nostrum omnis.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(1990), null, false, 5L, 2L },
                    { 5L, "Omnis nisi iste odit quas voluptatem.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2012), null, false, 2L, 4L },
                    { 6L, "Quaerat ea tempore impedit aut reiciendis asperiores rerum.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2029), null, false, 2L, 1L },
                    { 7L, "Voluptate dolorem deleniti perspiciatis voluptas.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2049), null, true, 3L, 2L },
                    { 8L, "Consequatur illo eum in.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2103), null, true, 2L, 1L },
                    { 9L, "Illo aut voluptas cupiditate et iste blanditiis.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2117), null, true, 10L, 2L },
                    { 10L, "Voluptas voluptatem laborum necessitatibus quia.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2135), null, false, 6L, 1L },
                    { 11L, "Impedit voluptas id et ea id animi.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2150), null, false, 9L, 5L },
                    { 12L, "Quasi porro sed est totam maiores ipsam est.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2167), null, false, 5L, 4L },
                    { 13L, "Non quo ea.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2186), null, true, 6L, 1L },
                    { 14L, "Quis omnis similique ut incidunt illo enim explicabo fugit.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2197), null, false, 7L, 5L },
                    { 15L, "Dolorem culpa quasi laborum.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2218), null, true, 5L, 3L },
                    { 16L, "Tenetur et itaque aut ut rerum.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2240), null, false, 5L, 1L },
                    { 17L, "Eius nemo autem corporis accusamus culpa.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2256), null, true, 5L, 1L },
                    { 18L, "Qui quia quam excepturi consequatur ratione.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2272), null, false, 2L, 1L },
                    { 19L, "Necessitatibus ut quaerat ipsam.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2287), null, false, 8L, 1L },
                    { 20L, "Corporis blanditiis eius quia tenetur.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2300), null, false, 6L, 4L },
                    { 21L, "Est odit et cupiditate.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2314), null, false, 2L, 2L },
                    { 22L, "Reiciendis libero eum assumenda eos necessitatibus doloribus autem.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2326), null, true, 2L, 2L },
                    { 23L, "Perferendis atque dolore.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2347), null, false, 1L, 5L },
                    { 24L, "Modi qui voluptates quos excepturi nisi voluptatum.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2390), null, true, 10L, 2L },
                    { 25L, "Tempora rerum et enim autem veritatis consequuntur.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2408), null, true, 10L, 5L },
                    { 26L, "Repellat et et sequi quis.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2426), null, true, 2L, 4L },
                    { 27L, "Veritatis perspiciatis aut molestiae incidunt.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2440), null, true, 5L, 3L },
                    { 28L, "Est sed consequuntur illum voluptas nihil.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2454), null, true, 10L, 2L },
                    { 29L, "Tenetur temporibus consequatur nihil velit ex ullam.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2470), null, true, 7L, 2L },
                    { 30L, "Eum minus harum sit vel iusto sed vitae cumque sed.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2486), null, true, 3L, 3L },
                    { 31L, "Minus qui et esse natus.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2508), null, true, 10L, 2L },
                    { 32L, "Voluptate a dignissimos sed possimus voluptas ea aut.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2541), null, true, 5L, 1L },
                    { 33L, "Eveniet laudantium nesciunt est sit.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2559), null, true, 4L, 4L },
                    { 34L, "Itaque doloremque id.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2574), null, true, 4L, 4L },
                    { 35L, "Vel totam repellendus praesentium id unde.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2586), null, true, 5L, 3L },
                    { 36L, "Enim qui voluptatem et ut.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2602), null, true, 8L, 1L },
                    { 37L, "Dolore dolorem consequatur doloribus.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2617), null, false, 4L, 5L },
                    { 38L, "Quia dolorem et.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2629), null, true, 7L, 2L },
                    { 39L, "Nam aliquam sed placeat.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2641), null, true, 3L, 1L },
                    { 40L, "Repudiandae perspiciatis sit itaque repudiandae similique cupiditate veniam aspernatur quia.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2654), null, true, 1L, 5L },
                    { 41L, "Corrupti quasi perspiciatis doloremque voluptas.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2691), null, false, 8L, 5L },
                    { 42L, "Adipisci voluptatibus non ut voluptatem nam.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2707), null, true, 4L, 3L },
                    { 43L, "Beatae asperiores placeat reprehenderit dolores velit aspernatur sunt.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2722), null, true, 6L, 1L },
                    { 44L, "Cum nihil porro accusantium.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2744), null, true, 7L, 5L },
                    { 45L, "Numquam numquam doloremque.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2758), null, false, 7L, 2L },
                    { 46L, "Qui accusamus occaecati expedita quia numquam corrupti aut eos voluptate.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2769), null, true, 2L, 4L },
                    { 47L, "Enim fugit aut quisquam officiis architecto quia.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2789), null, false, 9L, 2L },
                    { 48L, "Consectetur dolorem et ut.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2820), null, false, 7L, 1L },
                    { 49L, "Minima cum non delectus et id natus delectus magnam.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2833), null, true, 1L, 2L },
                    { 50L, "Rerum non animi itaque.", new DateTime(2024, 12, 30, 13, 55, 35, 540, DateTimeKind.Local).AddTicks(2851), null, false, 8L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubMember_Email",
                table: "ClubMember",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_ClubMemberId",
                table: "Entities",
                column: "ClubMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_PlayerId",
                table: "Entities",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_Name",
                table: "ExpenseCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EntityId",
                table: "Expenses",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ResponsibleUserId",
                table: "Expenses",
                column: "ResponsibleUserId",
                unique: true);

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
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_EntityId",
                table: "Revenues",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_ResponsibleUserId",
                table: "Revenues",
                column: "ResponsibleUserId",
                unique: true);

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
                name: "IX_User_UserPermissionId",
                table: "User",
                column: "UserPermissionId",
                unique: true);

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
                name: "IX_UserClubMembers_UserId",
                table: "UserClubMembers",
                column: "UserId",
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
                name: "Expenses");

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
                name: "UserClubMembers");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "RevenueCategories");

            migrationBuilder.DropTable(
                name: "TrainingSessions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "FacilityCategories");

            migrationBuilder.DropTable(
                name: "ClubMember");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "PlayerCategory");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "TeamCategory");
        }
    }
}
