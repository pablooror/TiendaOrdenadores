using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ComponentesMVC.Models
{
    public class DesignTimeComponenteContextFactory : IDesignTimeDbContextFactory<TiendaOrdenadoresContext>
    {
        public TiendaOrdenadoresContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<TiendaOrdenadoresContext>();
            var connectionString = "Server = tcp:obdulioserver.database.windows.net,1433; Initial Catalog = TiendaOrdenadores; Persist Security Info = False; User ID = cloudadmin; Password =Pablo.98; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";

            dbContextBuilder.UseSqlServer(connectionString);
            return new TiendaOrdenadoresContext(dbContextBuilder.Options);
        }
    }
}
