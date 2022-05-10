using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWorkerService
{
    public class DailyJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("             ");
            await Console.Out.WriteLineAsync($"Daily job is Executed! tme is '{DateTime.Now}'");
        }
    }
}
