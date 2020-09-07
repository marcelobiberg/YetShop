using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Entidades.CestaAgregar;
using Yet.Core.Entidades.PedidoAgregar;

namespace Yet.Infrastructure.Data
{

    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options)
        {
        }

        public DbSet<Cesta> Cestas { get; set; }
        public DbSet<CatalogoItem> CatalogoItens { get; set; }
        public DbSet<CatalogoMarca> CatalogoMarcas { get; set; }
        public DbSet<CatalogoTipo> CatalogoTipos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<CestaItem> CestaItens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
