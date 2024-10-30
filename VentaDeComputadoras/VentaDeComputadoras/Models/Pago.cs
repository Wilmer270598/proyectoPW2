using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentaDeComputadoras.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPago { get; set; }  // Clave primaria, generada automáticamente

        [Required]
        [StringLength(100)]
        public string? metodosPago { get; set; }  // Método de pago (e.g., "Tarjeta", "Transferencia", etc.)

        [Required]
        [DataType(DataType.Date)]
        public DateTime fechaPago { get; set; }  // Fecha de pago

        [Required]
        [StringLength(100)]
        public string? estadoPago { get; set; }  // Estado del pago (e.g., "Completado", "Pendiente", etc.)

        // Relación con Pedido
        [Required]
        public int idPedido { get; set; }  // Llave foránea hacia Pedido

        [ForeignKey("idPedido")]
        public Pedido? pedido { get; set; }  // Propiedad de navegación hacia Pedido
    }
}
