using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Yet.API.Helpers
{
    public class FiltroPersonalizadoScheme : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            //. . Evita que a variável CorrelacaoId utilizada nos request & response seja exibida via SwaggerGen ( Swagger ) 
            var excludeProperties = new[] { "CorrelacaoId" };

            foreach (var prop in excludeProperties)
                if (schema.Properties.ContainsKey(prop))
                    schema.Properties.Remove(prop);
        }
    }
}
