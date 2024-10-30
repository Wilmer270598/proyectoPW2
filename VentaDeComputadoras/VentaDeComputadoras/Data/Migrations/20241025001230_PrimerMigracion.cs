using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentaDeComputadoras.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimerMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    calle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    codigoPostal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    estadoProducto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id_producto);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descuento = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    estadoPedido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalPedido = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    idDetallePedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProduto = table.Column<int>(type: "int", nullable: false),
                    idPedido = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.idDetallePedido);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_idPedido",
                        column: x => x.idPedido,
                        principalTable: "Pedidos",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Productos_idProduto",
                        column: x => x.idProduto,
                        principalTable: "Productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    idPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    metodosPago = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoPago = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    idPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.idPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Pedidos_idPedido",
                        column: x => x.idPedido,
                        principalTable: "Pedidos",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_idPedido",
                table: "DetallePedidos",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_idProduto",
                table: "DetallePedidos",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_idPedido",
                table: "Pagos",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_idCliente",
                table: "Pedidos",
                column: "idCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
