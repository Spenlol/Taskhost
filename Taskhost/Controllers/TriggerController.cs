using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskhost.Jobs;

namespace Taskhost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriggerController : ControllerBase
    {
        private readonly ILogger<TriggerController> _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IImportJob _importJob;
        public TriggerController(ILogger<TriggerController> logger, IBackgroundJobClient backgroundJobClient, IImportJob importJob)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
            _importJob = importJob;
        }


        [HttpGet]
        public string Get()
        {
            _backgroundJobClient.Enqueue(() => _importJob.RunAll());
            return "blabla";
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            switch (id) 
            {
                case 1:
                    _backgroundJobClient.Enqueue(() => _importJob.ImportTask());
                    break;
                case 2:
                    _backgroundJobClient.Enqueue(() => _importJob.ValidateTask());
                    break;
                case 3:
                    _backgroundJobClient.Enqueue(() => _importJob.SaveTask());
                    break;
                case 4:
                    _backgroundJobClient.Enqueue(() => _importJob.CleanTask());
                    break;
                default:
                    break;
            }
            return "blabla";
        }
    }
}
