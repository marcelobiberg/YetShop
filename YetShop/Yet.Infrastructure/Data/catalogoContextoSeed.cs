using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Infrastructure.Data
{
    /// <summary>
    /// Seed do catálogo de produtos
    /// </summary>
    public class catalogoContextoSeed
    {
        // Máximo de tentativas para popolar os objetos e salvar no banco de dados
        private const Int16 LIMITADOR_TENTATIVAS = 3;

        /// <summary>
        /// opula o banco de dados do catálogo com informações aleatórias para fins de teste
        /// </summary>
        /// <param name="catalogoContexto">Contexto do catálogo</param>
        /// <param name="loggerFactory">Produz instâncias de classes de ILogger com base em determinados provedores.</param>
        /// <param name="tentativa">Nro de tentativas de criar o contexto async</param>
        public static async Task SeedAsync(CatalogoContexto catalogoContexto,
            ILoggerFactory loggerFactory, int? tentativa = 0)
        {
            //. . Limita as tantativas 
            Int16 contadorDeTentativas = (Int16)tentativa.Value;
            try
            {
                // Valida se existe contexto atual para os objetos ( CatalogoMarcas, CatalogoTipos, CatalogoTipos )
                // Popula o objeto com informações pré-configuradas e salva no DB
                if (!await catalogoContexto.CatalogoMarcas.AnyAsync())
                {
                    await catalogoContexto.CatalogoMarcas.AddRangeAsync(
                        ObterPreConfiguradoCatalogoMarcas());
                    await catalogoContexto.SaveChangesAsync();
                }
                if (!await catalogoContexto.CatalogoTipos.AnyAsync())
                {
                    await catalogoContexto.CatalogoTipos.AddRangeAsync(
                        ObterPreConfiguradoCatalogoTipos());
                    await catalogoContexto.SaveChangesAsync();
                }
                if (!await catalogoContexto.CatalogoItens.AnyAsync())
                {
                    await catalogoContexto.CatalogoItens.AddRangeAsync(
                        ObterPreConfiguradoCatalogoItens());
                    await catalogoContexto.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //. . Valida o limitador
                if (contadorDeTentativas < LIMITADOR_TENTATIVAS)
                {
                    //. . Incrementa o contador 
                    contadorDeTentativas++;

                    //. . Registra no log de LogError
                    var log = loggerFactory.CreateLogger<catalogoContextoSeed>();
                    log.LogError(ex.Message);

                    //. . Recursivamente chama o método SeedAsync até o máximo de tentativas ( LIMITADOR_TENTATIVAS )
                    await SeedAsync(catalogoContexto, loggerFactory, contadorDeTentativas);
                }
                throw;
            }
        }

        #region Modelo de demonstração Pré-configurado
        /// <summary>
        /// Retorna uma lista de List<CatalogoMarca> pré-configurada
        /// </summary>
        static IEnumerable<CatalogoMarca> ObterPreConfiguradoCatalogoMarcas()
        {
            return new List<CatalogoMarca>()
            {
                new CatalogoMarca("Azure"),
                new CatalogoMarca(".NET"),
                new CatalogoMarca("Visual Studio"),
                new CatalogoMarca("SQL Server"),
                new CatalogoMarca("Outros")
            };
        }

        /// <summary>
        /// Retorna uma lista de List<CatalogoTipo> pré-configurada
        /// </summary>
        static IEnumerable<CatalogoTipo> ObterPreConfiguradoCatalogoTipos()
        {
            return new List<CatalogoTipo>()
            {
                new CatalogoTipo("Canecas"),
                new CatalogoTipo("Camisetas")
            };
        }

        /// <summary>
        /// Retorna uma lista de List<CatalogoItem> pré-configurada
        /// </summary>
        static IEnumerable<CatalogoItem> ObterPreConfiguradoCatalogoItens()
        {
            return new List<CatalogoItem>()
            {
                new CatalogoItem(2,2, "Camiseta .NET Bot Preta", ".NET Bot Preta", 39.5M,  "/Imagens/Produto/1.png"),
                new CatalogoItem(1,2, "Caneca .NET preto & branco", ".NET preto & branco", 8.50M, "/Imagens/Produto/2.png"),
                new CatalogoItem(2,5, "Camiseta Prism branca", "Prism branca", 49.9M,  "/Imagens/Produto/3.png"),
                new CatalogoItem(2,2, "Camiseta .NET Foundation", "Camiseta .NET Foundation", 59.90M, "/Imagens/Produto/4.png"),
                new CatalogoItem(2,2, "Camiseta .NET Azul", ".NET Azul", 12, "/Imagens/Produto/6.png"),
                new CatalogoItem(2,5, "Camiseta Roslyn Vermelha", "Roslyn Vermelha",  12, "/Imagens/Produto/7.png"),
                new CatalogoItem(2,5, "Camiseta Kudu Roza", "Kudu Rosa", 8.5M, "/Imagens/Produto/8.png"),
                new CatalogoItem(1,5, "Caneca Cup<T> Branca", "Cup<T> Branca", 12, "/Imagens/Produto/9.png"),
                new CatalogoItem(2,5, "Camiseta Prism White TShirt", "Prism White TShirt", 12, "/Imagens/Produto/12.png")
            };
        }
        #endregion
    }
}
