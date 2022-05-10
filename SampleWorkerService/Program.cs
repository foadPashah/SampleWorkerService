using Quartz;
using SampleWorkerService;
using System.Configuration;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        //services.AddHostedService<Worker>();
        services.AddQuartz(q => 
        {
            q.UseInMemoryStore();
            q.UseMicrosoftDependencyInjectionJobFactory();
            q.AddDailyJobs<DailyJob>();
        });
        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });
    })
    .Build();

await host.RunAsync();
