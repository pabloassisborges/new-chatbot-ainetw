using System;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BellaAPIs.Function
{
    public static class SelectAnswerSQL
    {
        [FunctionName("SelectAnswerSQL")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            string Intent = req.Query["Intent"];
            // It must be enabled in the connection string.
            string connectionString = GetConnectionString();

            //SqlTransaction updateTx = null;
            SqlCommand answerCmd = null;
            //int answerID = 0;
            string answer = null;

            string answerSQL =
                "SELECT [Answer] FROM dbo.IntentAnswer ";// +
                                                         //"WHERE [IntentName]"+ $" = @{Intent}";

            using (SqlConnection awConnection = new SqlConnection(connectionString))
            {
                await awConnection.OpenAsync();
                //updateTx = await Task.Run(() => awConnection.BeginTransaction());
                answerCmd = new SqlCommand(answerSQL, awConnection);
                //answerCmd.Transaction = updateTx;
                SqlDataReader answerReader = answerCmd.ExecuteReader();// = await answerCmd.ExecuteReaderAsync();
                while (await answerReader.ReadAsync())
                {
                    Console.WriteLine(answerReader["Answer"]);
                    //answerID = (int)answerReader["ID"];
                    answer = (string)answerReader["Answer"];
                }

                string answerMessage = string.IsNullOrEmpty(answer)
                    ? "Resposta não encontrada."
                    : $"{answer}";

                return new OkObjectResult(answerMessage);
            }
        }
        private static string GetConnectionString()
        {
            //return "Data Source=(local);Integrated Security=SSPI;Initial Catalog=AdventureWorks;MultipleActiveResultSets=True";
            return "Data Source= ainetworksprod.database.windows.net; Initial Catalog=BellaEduSuite; Pooling=True; Min Pool Size=25; Max Pool Size=500; Persist Security Info=False; User ID = amintas; Password = @3ki8YUjdj29!#F;";
        }
    }
}
