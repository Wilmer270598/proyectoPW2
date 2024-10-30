using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VentaDeComputadoras.Models;

namespace VentaDeComputadoras.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // DbSets para tus modelos
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Llama al método base para configurar Identity

            // Configura tus entidades aquí
            modelBuilder.Entity<Cliente>().HasKey(c => c.id_cliente);

            modelBuilder.Entity<Producto>().HasKey(p => p.id_producto);

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.idPedido);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.idCliente);

            modelBuilder.Entity<Pago>()
                .HasKey(p => p.idPago);

            modelBuilder.Entity<DetallePedido>()
                .HasKey(dp => dp.idDetallePedido);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.producto)
                .WithMany()
                .HasForeignKey(dp => dp.idProduto);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.pedido)
                .WithMany()
                .HasForeignKey(dp => dp.idPedido);
        }
    }
}
