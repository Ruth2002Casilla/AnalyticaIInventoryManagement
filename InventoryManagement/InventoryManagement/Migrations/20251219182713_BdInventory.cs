using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class BdInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombreCategoria = table.Column<string>(type: "TEXT", nullable: true),
                    productoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: true),
                    RNCCliente = table.Column<string>(type: "TEXT", nullable: true),
                    TelefonoCliente = table.Column<string>(type: "TEXT", nullable: true),
                    TipoCliente = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    compraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    proveedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroFactura = table.Column<string>(type: "TEXT", nullable: true),
                    fechaCompra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    metodoPago = table.Column<string>(type: "TEXT", nullable: true),
                    tipoEntrega = table.Column<string>(type: "TEXT", nullable: true),
                    transportista = table.Column<string>(type: "TEXT", nullable: true),
                    lugarRecepcion = table.Column<string>(type: "TEXT", nullable: true),
                    costoEnvio = table.Column<double>(type: "REAL", nullable: false),
                    subTotal = table.Column<double>(type: "REAL", nullable: false),
                    impuesto = table.Column<double>(type: "REAL", nullable: false),
                    descuento = table.Column<double>(type: "REAL", nullable: false),
                    total = table.Column<double>(type: "REAL", nullable: false),
                    almacenDestino = table.Column<string>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: true),
                    motivoAnulacion = table.Column<string>(type: "TEXT", nullable: true),
                    regionCompra = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.compraId);
                });

            migrationBuilder.CreateTable(
                name: "detalleCompras",
                columns: table => new
                {
                    detalleCompraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    compraId = table.Column<int>(type: "INTEGER", nullable: false),
                    productoId = table.Column<int>(type: "INTEGER", nullable: false),
                    unidadMedida = table.Column<string>(type: "TEXT", nullable: true),
                    costoUnitario = table.Column<double>(type: "REAL", nullable: false),
                    impuestoUnitario = table.Column<double>(type: "REAL", nullable: false),
                    descuentoUnitario = table.Column<double>(type: "REAL", nullable: false),
                    totalLinea = table.Column<double>(type: "REAL", nullable: false),
                    calidad = table.Column<string>(type: "TEXT", nullable: true),
                    certificaciones = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleCompras", x => x.detalleCompraId);
                });

            migrationBuilder.CreateTable(
                name: "detalleVentas",
                columns: table => new
                {
                    detalleVentaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ventaId = table.Column<int>(type: "INTEGER", nullable: false),
                    productoId = table.Column<int>(type: "INTEGER", nullable: false),
                    precioUnitario = table.Column<double>(type: "REAL", nullable: false),
                    descuentoUnitario = table.Column<double>(type: "REAL", nullable: false),
                    impuestoUnitario = table.Column<double>(type: "REAL", nullable: false),
                    totalLinea = table.Column<double>(type: "REAL", nullable: false),
                    unidadMedida = table.Column<string>(type: "TEXT", nullable: true),
                    ubicacionAlmacen = table.Column<string>(type: "TEXT", nullable: true),
                    promocionAplicada = table.Column<string>(type: "TEXT", nullable: true),
                    margenGanancia = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleVentas", x => x.detalleVentaId);
                });

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    entradaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productoId = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidadProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    catidadCategoria = table.Column<int>(type: "INTEGER", nullable: false),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.entradaId);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    productoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: true),
                    precios = table.Column<double>(type: "REAL", nullable: false),
                    marca = table.Column<string>(type: "TEXT", nullable: true),
                    pesoVolumenNeto = table.Column<int>(type: "INTEGER", nullable: false),
                    ingredientes = table.Column<string>(type: "TEXT", nullable: true),
                    paisOrigen = table.Column<string>(type: "TEXT", nullable: true),
                    fechaElaboracion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fechaCaducidad = table.Column<DateTime>(type: "TEXT", nullable: false),
                    lote = table.Column<string>(type: "TEXT", nullable: true),
                    tamanoPorcion = table.Column<string>(type: "TEXT", nullable: true),
                    porcionesEnvase = table.Column<int>(type: "INTEGER", nullable: false),
                    calorias = table.Column<int>(type: "INTEGER", nullable: false),
                    proteinas = table.Column<string>(type: "TEXT", nullable: true),
                    grasasSaturadas = table.Column<string>(type: "TEXT", nullable: true),
                    grasasTrans = table.Column<string>(type: "TEXT", nullable: true),
                    carbohidratos = table.Column<string>(type: "TEXT", nullable: true),
                    azucares = table.Column<string>(type: "TEXT", nullable: true),
                    fibraDietetica = table.Column<string>(type: "TEXT", nullable: true),
                    sodio = table.Column<string>(type: "TEXT", nullable: true),
                    colesterol = table.Column<string>(type: "TEXT", nullable: true),
                    vitaminasMinerales = table.Column<string>(type: "TEXT", nullable: true),
                    sabor = table.Column<string>(type: "TEXT", nullable: true),
                    textura = table.Column<string>(type: "TEXT", nullable: true),
                    presentacion = table.Column<string>(type: "TEXT", nullable: true),
                    empaque = table.Column<string>(type: "TEXT", nullable: true),
                    vidaUtil = table.Column<string>(type: "TEXT", nullable: true),
                    temperaturaConservacion = table.Column<string>(type: "TEXT", nullable: true),
                    libreDe = table.Column<string>(type: "TEXT", nullable: true),
                    nivelAcidez = table.Column<string>(type: "TEXT", nullable: true),
                    alergenos = table.Column<string>(type: "TEXT", nullable: true),
                    advertencias = table.Column<string>(type: "TEXT", nullable: true),
                    instruccionesUso = table.Column<string>(type: "TEXT", nullable: true),
                    precioUnidad = table.Column<double>(type: "REAL", nullable: false),
                    precioMayor = table.Column<double>(type: "REAL", nullable: false),
                    precioDescuento = table.Column<double>(type: "REAL", nullable: false),
                    impuesto = table.Column<double>(type: "REAL", nullable: false),
                    precioKiloLitro = table.Column<double>(type: "REAL", nullable: false),
                    margenGanancia = table.Column<double>(type: "REAL", nullable: false),
                    distribución = table.Column<string>(type: "TEXT", nullable: true),
                    codigoBarras = table.Column<string>(type: "TEXT", nullable: true),
                    posicionTienda = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    proveedorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: true),
                    telefono = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    direccion = table.Column<string>(type: "TEXT", nullable: true),
                    descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    RNCProveedor = table.Column<string>(type: "TEXT", nullable: true),
                    llegada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    retirada = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.proveedorId);
                });

            migrationBuilder.CreateTable(
                name: "salidas",
                columns: table => new
                {
                    salidaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productoId = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidadProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salidas", x => x.salidaId);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userName = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    rol = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    ventaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    numeroFactura = table.Column<string>(type: "TEXT", nullable: true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    metodoPago = table.Column<string>(type: "TEXT", nullable: true),
                    moneda = table.Column<string>(type: "TEXT", nullable: true),
                    tasaCambio = table.Column<double>(type: "REAL", nullable: false),
                    canalVenta = table.Column<string>(type: "TEXT", nullable: true),
                    origenCampaña = table.Column<string>(type: "TEXT", nullable: true),
                    vendedor = table.Column<string>(type: "TEXT", nullable: true),
                    subTotal = table.Column<double>(type: "REAL", nullable: false),
                    descuento = table.Column<double>(type: "REAL", nullable: false),
                    impuesto = table.Column<double>(type: "REAL", nullable: false),
                    cashback = table.Column<double>(type: "REAL", nullable: false),
                    total = table.Column<double>(type: "REAL", nullable: false),
                    gananciaBruta = table.Column<double>(type: "REAL", nullable: false),
                    cajero = table.Column<string>(type: "TEXT", nullable: true),
                    caja = table.Column<string>(type: "TEXT", nullable: true),
                    ubicacionAlmacen = table.Column<string>(type: "TEXT", nullable: true),
                    usuarioRegistro = table.Column<string>(type: "TEXT", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: true),
                    motivoAnulacion = table.Column<string>(type: "TEXT", nullable: true),
                    region = table.Column<string>(type: "TEXT", nullable: true),
                    segmento = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.ventaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "detalleCompras");

            migrationBuilder.DropTable(
                name: "detalleVentas");

            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "salidas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "ventas");
        }
    }
}
