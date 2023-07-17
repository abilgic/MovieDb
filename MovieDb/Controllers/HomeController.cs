using Microsoft.AspNetCore.Mvc;
using MovieDb.Models;
using MovieDb.Services;
using Newtonsoft.Json;

namespace MovieDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        readonly IConfiguration configuration;
        readonly IJobService jobService;
        public HomeController(IConfiguration iConfig, IJobService jobService)
        {
            configuration = iConfig;
            this.jobService = jobService;
        }

        [HttpGet]
        public async Task<MovieModel> Get()
        {
            var services = this.HttpContext.RequestServices;

            MovieModel movieList = new MovieModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(configuration.GetValue<string>("Settings:apiurl")))
                {
                    try
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        movieList = JsonConvert.DeserializeObject<MovieModel>(apiResponse);
                        jobService.AddJob(movieList);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return movieList;
        }
    }
}
