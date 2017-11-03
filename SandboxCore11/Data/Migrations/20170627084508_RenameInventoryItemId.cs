namespace SandboxCore11.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameInventoryItemId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InventoryItems",
                newName: "InventoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InventoryItemId",
                table: "InventoryItems",
                newName: "Id");
        }
    }
}
