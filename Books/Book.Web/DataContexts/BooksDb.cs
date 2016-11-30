using System.Data.Entity;

namespace Book.Web.DataContexts
{
    public class BooksDb: DbContext
    {
        public DbSet<Books.Entities.Book> Books { get; set; }
    }
}