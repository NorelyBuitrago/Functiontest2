using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

public class RegisterMes
{
    private readonly ILogger<RegisterMes> _logger;
    public RegisterMes(ILogger<RegisterMes> logger) => _logger = logger;

    [Function("RegisterMes")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "RegisterMes")]
        HttpRequestData req)
    {
        var res = req.CreateResponse(HttpStatusCode.OK);
        res.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        await res.WriteStringAsync("Hermosa Norely lograsteveres una diosa");
        return res;
    }
}