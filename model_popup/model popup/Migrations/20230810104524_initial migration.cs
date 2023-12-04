using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace model_popup.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Account_number = table.Column<int>(type: "int", maxLength: 14, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IFSC_Code = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Mobile_Number = table.Column<int>(type: "int", nullable: false),
                    Zip_code = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Name_of_customer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Account_number);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");
        }
    }
}
