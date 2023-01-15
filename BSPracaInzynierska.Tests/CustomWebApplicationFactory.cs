using Microsoft.AspNetCore.Mvc.Testing;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using BSPracaInzynierska.Server.DB;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace BSPracaInzynierska.Tests
{
    public class CustomWebApplicationFactory<TProgram>
        :WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault
                    (d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                if(descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<DataContext>
                ((_, context) => context.UseInMemoryDatabase("TestingDB"));

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();
            });
        }
    }
}


