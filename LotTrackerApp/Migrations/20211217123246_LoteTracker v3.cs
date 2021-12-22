using Microsoft.EntityFrameworkCore.Migrations;

namespace LotTrackerApp.Migrations
{
    public partial class LoteTrackerv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoFabricante_Paises_Pais1",
                table: "ProdutoFabricante");

            migrationBuilder.RenameColumn(
                name: "Produto",
                table: "Produtos",
                newName: "CodProduto");

            migrationBuilder.RenameColumn(
                name: "Pais1",
                table: "ProdutoFabricante",
                newName: "PaisCodPais");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoFabricante_Pais1",
                table: "ProdutoFabricante",
                newName: "IX_ProdutoFabricante_PaisCodPais");

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Paises",
                newName: "CodPais");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoFabricante_Paises_PaisCodPais",
                table: "ProdutoFabricante",
                column: "PaisCodPais",
                principalTable: "Paises",
                principalColumn: "CodPais",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoFabricante_Paises_PaisCodPais",
                table: "ProdutoFabricante");

            migrationBuilder.RenameColumn(
                name: "CodProduto",
                table: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameColumn(
                name: "PaisCodPais",
                table: "ProdutoFabricante",
                newName: "Pais1");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoFabricante_PaisCodPais",
                table: "ProdutoFabricante",
                newName: "IX_ProdutoFabricante_Pais1");

            migrationBuilder.RenameColumn(
                name: "CodPais",
                table: "Paises",
                newName: "Pais");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoFabricante_Paises_Pais1",
                table: "ProdutoFabricante",
                column: "Pais1",
                principalTable: "Paises",
                principalColumn: "Pais",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
