using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Taskhost.Jobs
{
    public interface IImportJob
    {
        Task RunAll();
        Task ImportTask();
        Task ValidateTask();
        Task SaveTask();
        Task CleanTask();

    }
    public class ImportJob : IImportJob
    {

        [DisableConcurrentExecution(timeoutInSeconds: 30)]
        public async Task RunAll()
        {
            await ImportTask();
            await ValidateTask();
            await SaveTask();
            await CleanTask();
        }

        [DisableConcurrentExecution(timeoutInSeconds: 30)]
        public async Task ImportTask()
        {
            
            Console.WriteLine($"Importing stuff");
            Thread.Sleep(2000);
            Console.WriteLine("Done importing");
            await Task.CompletedTask;

        }

        [DisableConcurrentExecution(timeoutInSeconds: 30)]
        public async Task ValidateTask()
        {
            Console.WriteLine($"Validating stuff");
            await Task.CompletedTask;

        }

        [DisableConcurrentExecution(timeoutInSeconds: 30)]
        public async Task SaveTask()
        {
            Console.WriteLine($"Saving stuff");
            await Task.CompletedTask;
        }

        [DisableConcurrentExecution(timeoutInSeconds: 30)]
        public async Task CleanTask()
        {
            Console.WriteLine($"Cleaning stuff");
            await Task.CompletedTask;
        }
    }
}
