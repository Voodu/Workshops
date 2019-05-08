using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Redirect
{
    public static class Kittens
    {
        [FunctionName("Kittens")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            var response = req.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = Helpers.PickNextMeeting(Helpers.GetData()) ?? new Uri("https://placekitten.com");
            return response;
        }
    }
}
