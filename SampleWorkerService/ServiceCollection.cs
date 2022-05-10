using Quartz;

namespace SampleWorkerService
{
    public static class ServiceCollection
    {
        public static void AddDailyJobs<T>(this IServiceCollectionQuartzConfigurator quarts) where T : IJob
        {

            quarts.ScheduleJob<T>(s => s.WithIdentity("TestJobQuarts")
            .StartAt(DateBuilder.DateOf(19, 05, 01))
            //.StartNow()
            //.WithDailyTimeIntervalSchedule(i => i.StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(19,10,1)))
            .WithDailyTimeIntervalSchedule(x => x.WithIntervalInSeconds(1)
                                                 .StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(19,27,1))
                                                 .EndingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(19,29,1)))
            //.EndAt(DateBuilder.DateOf(18,59,1))
            .WithDescription("Daily schedule"));

            quarts.AddJob<T>(j => j.StoreDurably()
            .WithDescription("daily Job"));
        }

    }
}
