using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class BookManagementContext : DbContext
    {
        public class optionsBuild
        {
            public optionsBuild()
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<BookManagementContext>();
                optionsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOps = optionsBuilder.Options;
            }

            public DbContextOptionsBuilder<BookManagementContext> optionsBuilder { get; set; }

            public DbContextOptions<BookManagementContext> dbOps { get; set; }

            private AppConfiguration settings { get; set; }
        }

        public static optionsBuild options = new optionsBuild();

        public BookManagementContext(DbContextOptions<BookManagementContext> options) : base(options) { }

        public BookManagementContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthorMap>().HasKey(bam => new { bam.AuthorId, bam.BookId });
        }
    }
}
