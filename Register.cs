using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Functiontest2;

public class Register
{
    private readonly ILogger<Register> _logger;

    public Register(ILogger<Register> logger)
    {
        _logger = logger;
    }

    [Function("Register")]
    [SqlOutput("dbo.Websites", connectionStringSetting: "azuretest")]
    public async Task<Websites> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        var website = JsonSerializer.Deserialize<Websites>(body, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        website.Id = Guid.NewGuid();
        return website; // <-- Esto inserta 1 fila en dbo.Websites
    }
    
}
public class Websites
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? XPathExpression { get; set; }
}