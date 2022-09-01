using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
            return await Task.FromResult(new NoContentResult());
        }
    }
}
