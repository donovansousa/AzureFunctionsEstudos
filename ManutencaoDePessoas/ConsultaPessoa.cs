using Aplicacao.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPessoa
{
    public class ConsultaPessoa
    {
        [FunctionName("ConsultarPessoa")]
        public async Task<IActionResult> ConsultarPessoa(
          [HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                         methods: "GET",
                         Route = null)] HttpRequest req)
        {
            if (req.Query["nome"].Count > 0)
            {
                Storage.Pessoas.Where(p => p.Nome.Contains(req.Query["nome"])).Select(p => p).ToList();

                return await Task.FromResult(new OkObjectResult(Storage.Pessoas
                                        .Where(p => p.Nome.Contains(req.Query["nome"]))
                                        .Select(p => p).ToList()));
            }

            return await Task.FromResult(new OkObjectResult(Storage.Pessoas.ToList()));
        }
    }
}
