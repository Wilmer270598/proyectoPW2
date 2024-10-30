using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentaDeComputadoras.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cliente { get; set; }

        [Required]
        [StringLength(255)]
        public string? nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string? apellido { get; set; }

        [Required]
        [StringLength(25)]
        public string? telefono { get; set; }

        [Required]
        [StringLength(255)]
        public string? correo { get; set; }

        [Required]
        [StringLength(255)]
        public string? calle { get; set; }

        [Required]
        [StringLength(255)]
        public string? codigoPostal { get; set; }

        // Propiedad de navegación para los pedidos
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>(); // Asegúrate de que esto esté presente

    }
}
