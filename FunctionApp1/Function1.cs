using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Data.Entity;
using MVC_AspDotNet_Identity.Models;
using System.Linq;
using System.Configuration;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("*/20 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            var connString=ConfigurationManager.AppSettings["sqldb-connectionstring"];

            using (var dbContext = new ApplicationDbContext(connString))
            {
                var ybEvents = dbContext.YogaSpaceEvent.FirstOrDefault();
                log.Info("event id = " + ybEvents?.YogaSpaceEventId);
            }
        }
    }

    //public partial class YogabandyContext : DbContext
    //{
    //    public YogabandyContext()
    //        : base("Server=tcp:yoga2017.database.windows.net,1433;Initial Catalog=Yoga2017;Persist Security Info=False;User ID=chuckd;Password=**********!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    //    {
    //    }

    //    public DbSet<YogaSpaceEvent> YogaSpaceEvent { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        //base.OnModelCreating(modelBuilder);
    //    }
    //}
}
