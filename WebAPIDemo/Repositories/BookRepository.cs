using WebAPIDemo.Entites;

namespace WebAPIDemo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;
        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int AddBook(Book book)
        {
            int result = 0;
            book.IsActive = 1;
            context.Books.Add(book);
            result=context.SaveChanges();
            return result;
        }

        public int DeleteBook(int id)
        {
            int result = 0;
            var book= context.Books.Where(x=>x.Id==id).FirstOrDefault();
            if (book != null)
            {
                book.IsActive = 0;
                result = context.SaveChanges();
            }
            return result;
        }

        public Book GetBookById(int id)
        {
            int result = 0;
            var book = context.Books.Where(x => x.Id == id).FirstOrDefault();
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.Where(x=>x.IsActive==1).ToList();
        }

        public int UpdateBook(Book book)
        {
            int result = 0;
            var b = context.Books.Where(x => x.Id == book.Id).FirstOrDefault();
            if (b != null)
            {
                b.Name = book.Name;
                b.Author = book.Author;
                b.Price=book.Price;
                b.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }
    }
}
