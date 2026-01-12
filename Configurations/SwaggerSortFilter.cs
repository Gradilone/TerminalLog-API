using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TerminalLog.Api.Configurations
{
    public class SwaggerSortFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Criamos um dicionário novo e ordenado
            var paths = new OpenApiPaths();

            // Ordenamos os caminhos existentes baseado no nosso peso de Verbo
            var orderedPaths = swaggerDoc.Paths
                .OrderBy(path => GetMethodWeight(path.Value))
                .ToList();

            foreach (var path in orderedPaths)
            {
                paths.Add(path.Key, path.Value);
            }

            swaggerDoc.Paths = paths;
        }

        private int GetMethodWeight(OpenApiPathItem pathItem)
        {
            // Pega o primeiro método disponível na rota e dá o peso
            if (pathItem.Operations.ContainsKey(OperationType.Get)) return 1;
            if (pathItem.Operations.ContainsKey(OperationType.Post)) return 2;
            if (pathItem.Operations.ContainsKey(OperationType.Patch)) return 3;
            if (pathItem.Operations.ContainsKey(OperationType.Delete)) return 4;
            return 5;
        }
    }
}
