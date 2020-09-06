using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Infrastructure.Data
{
    public class CatalogoContextSeed
    {
        public static async Task SeedAsync(CatalogoContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();
                if (!await catalogContext.CatalogoMarcas.AnyAsync())
                {
                    await catalogContext.CatalogoMarcas.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogoTipos.AnyAsync())
                {
                    await catalogContext.CatalogoTipos.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogoItens.AnyAsync())
                {
                    await catalogContext.CatalogoItens.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogoContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<CatalogoMarca> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogoMarca>()
            {
                new CatalogoMarca("Azure"),
                new CatalogoMarca(".NET"),
                new CatalogoMarca("Visual Studio"),
                new CatalogoMarca("SQL Server"),
                new CatalogoMarca("Outro")
            };
        }

        static IEnumerable<CatalogoTipo> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogoTipo>()
            {
                new CatalogoTipo("Mug"),
                new CatalogoTipo("T-Shirt"),
                new CatalogoTipo("Sheet"),
                new CatalogoTipo("USB Memory Stick")
            };
        }

        static IEnumerable<CatalogoItem> GetPreconfiguredItems()
        {
            return new List<CatalogoItem>()
            {
                new CatalogoItem(2,2, ".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M,  "/images/products/1.png"),
                new CatalogoItem(1,2, ".NET Black & White Mug", ".NET Black & White Mug", 8.50M, "/images/products/2.png"),
                new CatalogoItem(2,5, "Prism White T-Shirt", "Prism White T-Shirt", 12,  "/images/products/3.png"),
                new CatalogoItem(2,2, ".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12, "/images/products/4.png"),
                new CatalogoItem(3,5, "Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M, "/images/products/5.png"),
                new CatalogoItem(2,2, ".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12, "/images/products/6.png"),
                new CatalogoItem(2,5, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt",  12, "/images/products/7.png"),
                new CatalogoItem(2,5, "Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5M, "/images/products/8.png"),
                new CatalogoItem(1,5, "Cup<T> White Mug", "Cup<T> White Mug", 12, "/images/products/9.png"),
                new CatalogoItem(3,2, ".NET Foundation Sheet", ".NET Foundation Sheet", 12, "/images/products/10.png"),
                new CatalogoItem(3,2, "Cup<T> Sheet", "Cup<T> Sheet", 8.5M, "/images/products/11.png"),
                new CatalogoItem(2,5, "Prism White TShirt", "Prism White TShirt", 12, "/images/products/12.png")
            };
        }
    }
}
