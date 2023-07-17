using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using MovieDb.Hangfire;
using MovieDb.Models;
using MovieDb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IJobService), typeof(JobService));
builder.Services.AddDbContext<ApplicationDbContext>(options
=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfire(options => options.UseMemoryStorage());
builder.Services.AddHangfireServer();
JobStorage.Current = new MemoryStorage();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHangfireDashboard();
app.UseAuthorization();

app.MapControllers();
var serviceProvider = builder.Services.BuildServiceProvider();
var _coreService = serviceProvider.GetService<IJobService>();
var configuration = builder.Configuration;

var obj = new RecurringJobs(configuration, _coreService);
obj.GetHourlyMovieReport();
app.Run();
