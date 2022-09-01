using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
            return await Task.FromResult(new ContentResult());
        }
    }
}
