using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class producto
    {
        [Key]
        public int productoId { get; set; }
        public string? nombre { get; set; }
        public double precios { get; set; }
        public string? marca { get; set; }
        public int pesoVolumenNeto { get; set; }
        public string? ingredientes { get; set; }
        public string? paisOrigen { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaElaboracion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaCaducidad { get; set; }
        public string? lote { get; set; }  
        public string? tamanoPorcion { get; set;}
        public int porcionesEnvase { get; set; }
        public int calorias { get; set; }
        public string? proteinas { get; set; }
        public string? grasasSaturadas { get; set; }
        public string? grasasTrans { get; set; }
        public string? carbohidratos { get; set; }
        public string? azucares { get; set; }
        public string? fibraDietetica { get; set; }
        public string? sodio { get; set; }
        public string? colesterol { get; set; }
        public string? vitaminasMinerales { get; set; }
        public string? sabor { get; set; }
        public string? textura { get; set; }
        public string? presentacion { get; set; }
        public string? empaque { get; set; }
        public string? vidaUtil { get; set; }
        public string? temperaturaConservacion { get; set; }
        public string? libreDe { get; set; }
        public string? nivelAcidez { get; set; }
        public string? alergenos { get; set; }
        public string? advertencias { get; set; }
        public string? instruccionesUso { get; set; }
        public double precioUnidad { get; set; }
        public double precioMayor { get; set; }
        public double precioDescuento { get; set; }
        public double impuesto { get; set; }
        public double precioKiloLitro { get; set; }
        public double margenGanancia { get; set; }
        public string? distribución { get; set; }
        public string? codigoBarras { get; set; }
        public string? posicionTienda { get; set; }
    }
}
