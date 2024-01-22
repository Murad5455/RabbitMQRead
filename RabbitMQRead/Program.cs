using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQRead.AppContext;
using RabbitMQRead.Base;
using RabbitMQRead.SipCdrCollector;
using Serilog;
using Serilog.Core;

class Program
{
    static void Main(string[] args)
    {
        
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(path: @"C:\Log\Test.txt", rollingInterval: RollingInterval.Day).CreateLogger();

       
        var configuration = new ConfigurationBuilder()
          
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();

        string connectionString = configuration.GetConnectionString("PostgreSQLConnection");
       // var rabbitMqSettings = configuration.GetSection("RabbitMQConnection");
       // var sipCdrSettings = configuration.GetSection("SipCdrSettings");

        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(connectionString)
        );
        //var services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<Connection>();
        services.AddSingleton<CdrSipService>();

        var serviceProvider = services.BuildServiceProvider();
      
        var connection = serviceProvider.GetRequiredService<Connection>();

        connection.StartCollector();
    }
}