using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentaDeComputadoras.Models
{
    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDetallePedido { get; set; }  // Clave primaria, generada automáticamente

        [Required]
        public int idProduto { get; set; }  // Llave foránea hacia Producto

        [ForeignKey("idProduto")]
        public Producto? producto { get; set; }  // Propiedad de navegación hacia Producto

        [Required]
        public int idPedido { get; set; }  // Llave foránea hacia Pedido

        [ForeignKey("idPedido")]
        public Pedido? pedido { get; set; }  // Propiedad de navegación hacia Pedido

        [Required]
        public int cantidad { get; set; }  // Cantidad de productos en el pedido

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal precio { get; set; }  // Precio del producto en el detalle del pedido
    }
}
