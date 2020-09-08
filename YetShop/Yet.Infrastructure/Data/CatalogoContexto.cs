using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Entidades.CestaAgregar;
using Yet.Core.Entidades.PedidoAgregar;

namespace Yet.Infrastructure.Data
{
    public class CatalogoContexto : DbContext
    {
        #region Campos
        public DbSet<Cesta> Cestas { get; set; }
        public DbSet<CatalogoItem> CatalogoItens { get; set; }
        public DbSet<CatalogoMarca> CatalogoMarcas { get; set; }
        public DbSet<CatalogoTipo> CatalogoTipos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<CestaItem> CestaItens { get; set; }
        #endregion

        #region Ctor
        public CatalogoContexto(DbContextOptions<CatalogoContexto> options) : base(options) { }
        #endregion

        #region Métodos
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasDefaultSchema("Yet-Shop");
        }
        #endregion
    }
}
