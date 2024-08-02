using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InFornoWebApp.Migrations
{
    public partial class UniqueInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InFornoRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedRoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InFornoUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InFornoIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InFornoOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InFornoProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InFornoRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InFornoRoleClaims_InFornoRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "InFornoRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InFornoUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InFornoUserClaims_InFornoUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "InFornoUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InFornoUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_InFornoUserLogins_InFornoUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "InFornoUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InFornoUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_InFornoUserRoles_InFornoRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "InFornoRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InFornoUserRoles_InFornoUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "InFornoUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InFornoUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_InFornoUserTokens_InFornoUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "InFornoUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InFornoOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InFornoOrderItems_InFornoOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "InFornoOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InFornoOrderItems_InFornoProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "InFornoProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InFornoProductIngredients",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFornoProductIngredients", x => new { x.ProductId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_InFornoProductIngredients_InFornoIngredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "InFornoIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InFornoProductIngredients_InFornoProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "InFornoProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InFornoRoleClaims_RoleId",
                table: "InFornoRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "InFornoRoles",
                column: "NormalizedRoleName",
                unique: true,
                filter: "[NormalizedRoleName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InFornoUserClaims_UserId",
                table: "InFornoUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InFornoUserLogins_UserId",
                table: "InFornoUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InFornoUserRoles_RoleId",
                table: "InFornoUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "InFornoUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "InFornoUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InFornoOrderItems_OrderId",
                table: "InFornoOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InFornoOrderItems_ProductId",
                table: "InFornoOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InFornoProductIngredients_IngredientId",
                table: "InFornoProductIngredients",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InFornoOrderItems");

            migrationBuilder.DropTable(
                name: "InFornoProductIngredients");

            migrationBuilder.DropTable(
                name: "InFornoRoleClaims");

            migrationBuilder.DropTable(
                name: "InFornoUserClaims");

            migrationBuilder.DropTable(
                name: "InFornoUserLogins");

            migrationBuilder.DropTable(
                name: "InFornoUserRoles");

            migrationBuilder.DropTable(
                name: "InFornoUserTokens");

            migrationBuilder.DropTable(
                name: "InFornoOrders");

            migrationBuilder.DropTable(
                name: "InFornoIngredients");

            migrationBuilder.DropTable(
                name: "InFornoProducts");

            migrationBuilder.DropTable(
                name: "InFornoRoles");

            migrationBuilder.DropTable(
                name: "InFornoUsers");
        }
    }
}
