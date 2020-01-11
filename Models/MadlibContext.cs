using Microsoft.EntityFrameworkCore;

namespace Models
{
    /// <summary>
    /// Entity framework context for creating a madlib
    /// </summary>
    public class MadlibContext : DbContext
    {
        /// <summary>
        /// Connection string to the database
        /// </summary>
        private string connectionString;

        public MadlibContext()
        {
            this.connectionString = (@"Server = (localdb)\mssqllocaldb; Database = Northrich; Integrated Security = True");
        }

        /// <summary>
        /// Provides the connection string and settings to EF
        /// </summary>
        /// <param name="options">Options object containing connection string</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60));

        /// <summary>
        /// DB Set for the madlibs
        /// </summary>
        public DbSet<Madlib> Madlibs { get; set; }
    }
}
