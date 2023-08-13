using Microsoft.EntityFrameworkCore;
using PhotoBookRepository;

namespace PhotoBookWebService.PhotobookDbContext
{
    public class PhotobookDBContext :DbContext
    {
        public PhotobookDBContext(DbContextOptions<PhotobookDBContext> options):base(options)
        {
            
        }
        public DbSet<PhotobookUser> PhotobookUsers { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}
