
using ASP_NET_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_WEB_API.Data;
public class DBAccess : DbContext
{
    public DBAccess(DbContextOptions<DBAccess> options):base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder){}
    public DbSet<Book> Books { get; set;}

}