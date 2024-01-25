/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQRead.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQRead.AppContext
{

        public class ApplicationContext : DbContext
        {
            public DbSet<CallInformation> CallInformations { get; set; }
            public DbSet<CallInformationDetailed> CallInformationDetaileds { get; set; }

        *//* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {

         optionsBuilder.UseNpgsql("Host=localhost;Database=Rabbit;Username=postgres;Password=Murad3645;");

     }*//*


        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PostgreSQLConnection"));
        }


        *//*    private readonly IConfiguration _configuration;

            public ApplicationContext(IConfiguration configuration)
            {
                _configuration = configuration;
            }*/

/*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQLConnection"));
   }*/
/*
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
            {
            }
*//*
            // DbSet'ler ve diğer özellikler...

        
*//*
        public ApplicationContext() { }
*//*


    }
}

*/

/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQRead.Entity;

public class ApplicationContext : DbContext
{
  
        public DbSet<CallInformation> CallInformations { get; set; }
        public DbSet<CallInformationDetailed> CallInformationDetaileds { get; set; }

        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQLConnection"));
        }
    }
*/


/*
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQRead.Entity;

public class ApplicationContext : DbContext
{
    private readonly IConfiguration _configuration;

  //  public ApplicationContext() { }

    public ApplicationContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<CallInformation> CallInformations { get; set; }
    public DbSet<CallInformationDetailed> CallInformationDetaileds { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}

*/












using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQRead.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQRead.AppContext
{

    public class ApplicationContext : DbContext
    {


        private readonly IConfiguration _configuration;

        public ApplicationContext() { }

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Rabbit100;Username=postgres;Password=Murad3645;");
        }

        public DbSet<CallInformation> CallInformations { get; set; }
        public DbSet<CallInformationDetailed> CallInformationDetaileds { get; set; }
    }
}























/*
        private readonly IConfiguration _configuration;

        public ApplicationContext() { }

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // appsettings.json dosyasından bağlantı bilgilerini al
                string connectionString = _configuration.GetConnectionString("PostgreSQLConnection");
                Console.WriteLine(connectionString);
                // PostgreSQL için bağlantı dizesini ayarla
                optionsBuilder.UseNpgsql(connectionString);

            }
        }

public DbSet<CallInformation> CallInformations { get; set; }
        public DbSet<CallInformationDetailed> CallInformationDetaileds { get; set; }
    }
}

*/
/*
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQRead.Entity;
//using RabbitMQRead.Models;

namespace RabbitMQRead.AppContext
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext() { }

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // appsettings.json dosyasından PostgreSQL bağlantı dizesini al
                string connectionString = _configuration.GetConnectionString("PostgreSQLConnection");

                // Bağlantı dizesini kullanarak PostgreSQL'e bağlan
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<CallInformation> CallInformations { get; set; }
        public DbSet<CallInformationDetailed> CallInformationDetaileds { get; set; }
    }
}
*/