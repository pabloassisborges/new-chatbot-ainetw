using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BellaAPIs.Function
{
    public static class MessageController
    {
        [FunctionName("MessageController")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Message Controller: C# HTTP trigger function processed a request.");

            string userMessage = req.Query["userMessage"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            userMessage = userMessage ?? data?.userMessage;

            //call function: Intent
            // intent == "None"
            // retryResponse
            string responseMessage = string.IsNullOrEmpty(userMessage)
                ? "Echo bot: Empty message! Please enter anything."
                : $"Echo bot: {userMessage}";

            return new OkObjectResult(responseMessage);
        }
    }
}
