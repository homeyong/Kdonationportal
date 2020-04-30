using Microsoft.EntityFrameworkCore.Migrations;

namespace NetLearner.SharedLib.Migrations
{
    public partial class AddedResourceListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResourceListId",
                table: "LearningResources",
                nullable: false,
                defaultValue: 0);
            
             migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "LearningResources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResourceLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLists", x => x.Id);
                });

                 migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    TrackingNumber = table.Column<string>(nullable: true),
                    DonationItems = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningResources_ResourceListId",
                table: "LearningResources",
                column: "ResourceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningResources_ResourceLists_ResourceListId",
                table: "LearningResources",
                column: "ResourceListId",
                principalTable: "ResourceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningResources_ResourceLists_ResourceListId",
                table: "LearningResources");

            migrationBuilder.DropTable(
                name: "ResourceLists");

             migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropIndex(
                name: "IX_LearningResources_ResourceListId",
                table: "LearningResources");

            migrationBuilder.DropColumn(
                name: "ResourceListId",
                table: "LearningResources");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "LearningResources");
        }
    }
}
