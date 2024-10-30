using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentaDeComputadoras.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPedido { get; set; }  // Clave primaria, generada automáticamente

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal descuento { get; set; }  // Descuento en el pedido

        [Required]
        [StringLength(100)]
        public string? estadoPedido { get; set; }  // Estado del pedido

        [Required]
        [DataType(DataType.Date)]
        public DateTime fechaPedido { get; set; }  // Fecha del pedido

        [Required]
        [DataType(DataType.Date)]
        public DateTime? fechaEntrega { get; set; }  // Fecha de entrega (puede ser nula si no se ha entregado)

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal totalPedido { get; set; }  // Total del pedido

        // Relación con el cliente
        [Required]
        public int idCliente { get; set; }  // Llave foránea de Cliente

        [ForeignKey("idCliente")]
        public Cliente? cliente { get; set; }  // Propiedad de navegación hacia el Cliente
    }
}
