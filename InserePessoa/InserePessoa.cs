using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
            return await Task.FromResult(new CreatedResult(string.Empty, null));
        }
    }
}
