using Aplicacao.DTO;
using Aplicacao.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlteraPessoa
{
    public class AlteraPessoa
    {
        [FunctionName("AlterarPessoa")]
        public async Task<IActionResult> AlterarPessoa(
        [HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                     methods: "PATCH",
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

            pessoa.Nome = req.Query["nome"];
           
            return await Task.FromResult(new NoContentResult());
        }
    }
}
