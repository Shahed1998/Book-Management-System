using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<BookManagementContext>
    {
        public BookManagementContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<BookManagementContext>();
            opsBuilder.UseSqlServer(appConfiguration.sqlConnectionString);
            return new BookManagementContext(opsBuilder.Options);
        }
    }
}
