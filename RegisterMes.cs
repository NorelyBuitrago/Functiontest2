using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

public class RegisterMes
{
    private readonly ILogger<RegisterMes> _logger;

    public RegisterMes(ILogger<RegisterMes> logger)
    {
        _logger = logger;
    }

    [Function("RegisterMes")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "RegisterMes")]
        HttpRequestData req)
    {
        // Leer el cuerpo del request
        var body = await new StreamReader(req.Body).ReadToEndAsync();

        // Deserializar el JSON enviado desde Postman
        var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body);

        // Crear la respuesta
        var res = req.CreateResponse(HttpStatusCode.OK);
        res.Headers.Add("Content-Type", "application/json; charset=utf-8");

        // Obtener el valor de "Url" enviado
        var valor = data != null && data.ContainsKey("Url") ? data["Url"] : "sin valor";

        // Escribir mensaje de respuesta
        await res.WriteStringAsync($"Hermosa Norely, lograste verlo, eres una diosa. Recibí: {valor}");

        return res;
    }
}