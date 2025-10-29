using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functiontest2
{
    public class PdfCreator
    {

        private readonly ILogger _logger;

        public PdfCreator(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FunctionSnapshot>();
        }
     
        [Function("PdfCreator")]
        public void Run(
            [SqlTrigger("[dbo].[Websites]", "azuretest")] IReadOnlyList<SqlChange<Websites>> changes,
                FunctionContext context)
        {
            _logger.LogInformation("SQL Changes: " + JsonConvert.SerializeObject(changes));

        }
    }
}
