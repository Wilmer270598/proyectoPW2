using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentaDeComputadoras.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_producto { get; set; }  // Corresponde a idProduto en la tabla SQL

        [Required]
        [StringLength(255)]
        public string? NombreProducto { get; set; }

        [Required]
        [StringLength(255)]
        public string? descripcion { get; set; }

        [StringLength(255)]
        public string? estadoProducto { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]  // Cambio a decimal en lugar de int para precios monetarios
        public decimal precio { get; set; }

        [Required]
        [StringLength(100)]
        public string? marca { get; set; }
    }
}
