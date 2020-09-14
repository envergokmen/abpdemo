using Microsoft.EntityFrameworkCore.Migrations;

namespace Env.Demo.Migrations
{
    public partial class CampaignItemCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "AppCampaigns",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "AppCampaigns");
        }
    }
}
