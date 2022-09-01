using Aplicacao.DTO;
using Aplicacao.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace InserePessoa
{
    public class InserePessoa
    {
        [FunctionName("InserirPessoa")]
        public async Task<IActionResult> InserirPessoa(
            [HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                         methods: "POST",
                         Route = null)] HttpRequest req)
        {
            string json = await new StreamReader(req.Body).ReadToEndAsync();
            PessoaDTO pessoa = JsonConvert.DeserializeObject<PessoaDTO>(json);

            if (pessoa == null)
            {
                return new BadRequestResult();
            }

            pessoa.Id = Storage.Pessoas.Count + 1;
            Storage.Pessoas.Add(pessoa);

            return await Task.FromResult(new CreatedResult(string.Empty, pessoa));
        }
    }
}
