using Microsoft.EntityFrameworkCore;
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

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
           

            optionsBuilder.UseNpgsql("Host=localhost;Database=Rabbit;Username=postgres;Password=Murad3645;");
           
        }
        }
    }

