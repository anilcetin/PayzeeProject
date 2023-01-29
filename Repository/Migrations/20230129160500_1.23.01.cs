using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class _12301 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    BirthDate = table.Column<int>(nullable: false),
                    IdentityNo = table.Column<long>(nullable: false),
                    IdentityNoVerified = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    TypeId = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    ExpiryDateMonth = table.Column<string>(nullable: true),
                    ExpiryDateYear = table.Column<string>(nullable: true),
                    Cvv = table.Column<string>(nullable: true),
                    ResponseCode = table.Column<string>(nullable: true),
                    ResponseMessage = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
