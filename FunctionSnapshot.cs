using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace Functiontest2;

public class FunctionSnapshot
{
    private readonly ILogger _logger;

    public FunctionSnapshot(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FunctionSnapshot>();
    }

    [Function("FunctionSnapshot")]
    public async Task Run(
     [SqlTrigger("[dbo].[Websites]", "azuretest")] IReadOnlyList<SqlChange<Websites>> changes,
     FunctionContext context)
    {
        _logger.LogInformation("SQL Changes: " + JsonConvert.SerializeObject(changes));
        await Task.CompletedTask;
    }
}

public class ToDoItem
{
    public string Id { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }
}