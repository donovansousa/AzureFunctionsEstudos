using Aplicacao.DTO;
using Aplicacao.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExcluiPessoa
{
    public class ExcluiPessoa
    {
        [FunctionName("ExcluirPessoa")]
        public async Task<IActionResult> ExcluirPessoa(
           [HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                         methods: "DELETE",
                         Route = null)] HttpRequest req)
        {
            if (req.Query["id"].Count == 0)
            {
                return await Task.FromResult(new BadRequestResult());
            }

            PessoaDTO pessoa = Storage.Pessoas
                              .Where(p => p.Id == Convert.ToInt32(req.Query["id"]))
                              .Select(p => p).FirstOrDefault();

            if (pessoa == null)
            {
                return await Task.FromResult(new NotFoundResult());
            }

            Storage.Pessoas.Remove(pessoa);

            return await Task.FromResult(new NoContentResult());
        }
    }
}
