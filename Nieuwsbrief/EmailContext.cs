using Microsoft.EntityFrameworkCore;

namespace Nieuwsbrief
{
    public class EmailContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }

        public string DbPath { get; }

        public EmailContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder, Environment.SpecialFolderOption.Create);
            DbPath = System.IO.Path.Join(path, "email.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Email
    {
        public int EmailId { get; set; }
        public string EmailAddress { get; set; }
    }
}
