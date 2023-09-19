using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComponentesMVC.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Gigas = table.Column<double>(type: "float", nullable: true),
                    Calor = table.Column<double>(type: "float", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    OrdenadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordenadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "Calor", "Cores", "Descripcion", "Gigas", "NumSerie", "OrdenadorId", "Precio", "Tipo" },
                values: new object[,]
                {
                    { 1, 10.0, 9, "Procesador Intel i7", 0.0, "789_XCS", 2, 134.0, 1 },
                    { 2, 12.0, 10, "Procesador Intel i7", 0.0, "789_XCD", 1, 138.0, 1 },
                    { 3, 22.0, 11, "Procesador Intel i7", 0.0, "789_XCT", 1, 138.0, 1 },
                    { 4, 10.0, 0, "Banco de memoria SDRAM", 512.0, "879FH", 2, 100.0, 0 },
                    { 5, 15.0, 0, "Banco de memoria SDRAM", 1024.0, "879FH_L", 1, 125.0, 0 },
                    { 6, 24.0, 0, "Banco de memoria SDRAM", 2028.0, "879FH_T", 1, 150.0, 0 },
                    { 7, 10.0, 0, "Disco Duro Scan Disk", 500000.0, "789_XX", 2, 50.0, 2 },
                    { 8, 29.0, 0, "Disco Duro Scan Disk", 1000000.0, "789_XX_2", 1, 90.0, 2 },
                    { 9, 39.0, 0, "Disco Duro Scan Disk", 2000000.0, "789_XX_3", 1, 128.0, 2 },
                    { 10, 30.0, 10, "Procesador Ryzen AMD", 0.0, "797-X", 1, 78.0, 1 },
                    { 11, 30.0, 29, "Procesador Ryzen AMD", 0.0, "797-X-2", 1, 178.0, 1 },
                    { 12, 60.0, 34, "Procesador Ryzen AMD", 0.0, "797-X-3", 1, 278.0, 1 },
                    { 13, 35.0, 0, "Disco Mecanico Patatin", 250.0, "788-fg", 1, 37.0, 2 },
                    { 14, 35.0, 0, "Disco Mecanico Patatin", 250.0, "788-fg-2", 1, 67.0, 2 },
                    { 15, 35.0, 0, "Disco Mecanico Patatin", 250.0, "788-fg-3", 1, 97.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "Id", "Descripcion", "Precio" },
                values: new object[] { 1, "Factura 1", 0.0 });

            migrationBuilder.InsertData(
                table: "Ordenadores",
                columns: new[] { "Id", "Descripcion", "PedidoId", "Precio" },
                values: new object[,]
                {
                    { 1, "Almacén de componentes", 0, 0.0 },
                    { 2, "Ordenador de María", 1, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "Descripcion", "FacturaId", "Precio" },
                values: new object[,]
                {
                    { 1, "Pedido 1", 1, 0.0 },
                    { 2, "Pedido 2", 1, 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Ordenadores");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
