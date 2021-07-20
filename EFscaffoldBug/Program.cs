using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EFscaffoldBug
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Scaffold bug test");

            // TODO: change connection string for your server
            const string cs = "Server=ServerName;Database=Test;Trusted_Connection=True;";
            // test query
            var options = new DbContextOptionsBuilder<TestDB.TestDBcontext>()
                .UseSqlServer(cs)
                .LogTo(Console.WriteLine)
                .Options;

            using var db = new TestDB.TestDBcontext(options);

            // attempt to query will cause exception
            var partners = await db.Partners.ToListAsync();
        }
    }
}