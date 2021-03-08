using System.IO;
using StoreModels;
using StoreBL;
using Serilog;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //get config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //set up db connection
            string connectionString = configuration.GetConnectionString("StoreDB");
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
            .UseSqlServer(connectionString)
            .Options;
            
            using var context = new StoreDBContext(options);

            IMenu menu = new StoreMenu(new MyStoreBL(new StoreRepoDB(context, new StoreMapper())));
            menu.Start();
        }
    }
}
