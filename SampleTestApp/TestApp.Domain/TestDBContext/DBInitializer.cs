using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.TestDBContext
{
    public static class DBInitializer
    {
        public async static Task<bool> Initialize(SampleDBContext context, IServiceProvider services)
        {

            //var st= context.Database.EnsureCreated();
            var databaseCreator = context.GetService<IRelationalDatabaseCreator>();
            var st = databaseCreator.EnsureCreated();
            await databaseCreator.CreateTablesAsync();
            // Add Seed Data...
            //context.Database.Migrate();
            //context.SaveChanges();
            return true;
        }
    }
}
