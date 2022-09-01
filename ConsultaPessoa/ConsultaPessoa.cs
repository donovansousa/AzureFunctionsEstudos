using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
            return await Task.FromResult(new OkObjectResult(null));
        }
    }
}
