using Hangfire;
using MovieDb.Controllers;
using MovieDb.Services;

namespace MovieDb.Hangfire
{
    public class RecurringJobs
    {
        readonly IConfiguration configuration;
        readonly IJobService jobService;
        public RecurringJobs(IConfiguration iConfig, IJobService jobService)
        {
            configuration = iConfig;
            this.jobService = jobService;
        }

        public void GetHourlyMovieReport()
        {
            var oController = new MovieDb.Controllers.HomeController(configuration, jobService);

            RecurringJob.RemoveIfExists(nameof(oController.Get));
            RecurringJob.AddOrUpdate<HomeController>(nameof(oController.Get), x =>
                  x.Get(), Cron.Hourly); //hourly

        }
    }
}
