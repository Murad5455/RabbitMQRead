/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using RabbitMQRead.AppContext;
using RabbitMQRead.Base;
using RabbitMQRead.SipCdrCollector;
using Serilog;
using Serilog.Core;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(path: @"C:\Log\Test.txt", rollingInterval: RollingInterval.Day).CreateLogger();


        var configuration = new ConfigurationBuilder()

            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();



        var Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Now you can use the 'configuration' object.
        // Example: var connectionString = configuration.GetConnectionString("DefaultConnection");



        var services = new ServiceCollection();

         string connectionString = configuration.GetConnectionString("PostgreSQLConnection");
         var rabbitMqSettings = configuration.GetSection("RabbitMQConnection");
        var sipCdrSettings = configuration.GetSection("SipCdrSettings");



        services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));



        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(connectionString)
        );
        //var services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(Configuration);
      //  services.AddSingleton<Connection>();
        services.AddSingleton<CdrSipService>();

        var serviceProvider = services.BuildServiceProvider();

        var connection = serviceProvider.GetRequiredService< RabbitMQRead.SipCdrCollector.Connection>();

        connection.StartCollector();
    }
}*/
/*
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using RabbitMQRead.AppContext;
using RabbitMQRead.Base;
using RabbitMQRead.SipCdrCollector;
using Serilog;
using System;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(path: @"C:\Log\Test.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
*//*
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
*//*

        var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));



        var services = new ServiceCollection();

        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));

        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<Connection>();
        services.AddSingleton<CdrSipService>();

        var serviceProvider = services.BuildServiceProvider();

        try
        {
            var connection = serviceProvider.GetRequiredService<Connection>();
            connection.StartCollector();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application failed to start.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQRead.AppContext;
using RabbitMQRead.Base;
using RabbitMQRead.SipCdrCollector;
using Serilog;
using Serilog.Core;
using System;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(path: @"C:\Log\Test.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();


        var services = new ServiceCollection();

        // PostgreSQL DbContext ekleniyor
        services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));


        // IConfiguration servisi ekleniyor
        services.AddSingleton<IConfiguration>(configuration);

        // Connection servisi ekleniyor
        services.AddSingleton<Connection>();

        // CdrSipService servisi ekleniyor
        services.AddSingleton<CdrSipService>();

        // Service Provider oluşturuluyor
        using (var serviceProvider = services.BuildServiceProvider())
        {
            // Connection servisi alınıyor ve kolektör başlatılıyor
            var connection = serviceProvider.GetRequiredService<Connection>();
            connection.StartCollector();
        }
    }
}

