

using LibraryManagment.ConsoleUI.Models;
using LibraryManagment.ConsoleUI.Models.Dtos;
using System.Linq;

namespace LibraryManagment.ConsoleUI.Repository;


public class BookRepository : BaseRepository, IBookRepository
{
    private List<Book> books;
    private List<Category> categories;
    private List<Author> authors;
    public BookRepository()
    {
        books = Books();
        categories = Categories();
        authors = Authors();
    }


    public List<Book> GetAll()
    {
        return books;
    }

    //language Ingtegrated Query
    public List<Book> GetAllBooksByPageSizeFilter(int min, int max)
    {
        //List<Book> filteredBooks = new List<Book>();

        //foreach (Book book in books)
        //{
        //    if (book.PageSize <= max && book.PageSize >= min)
        //    {
        //        filteredBooks.Add(book);
        //    }
        //}
        //return filteredBooks;
        //LİNQ
        //List<Book> result = (from b in books
        //                    where b.PageSize <=max && b.PageSize <=min
        //                    select b).ToList();
        //return result;
        List<Book> result =  books.Where(b => b.PageSize <= max && b.PageSize <= min).ToList();
        return result;



    }

    public double PageSizeTotalCalculator()
    {
        double total = books.Sum(x => x.PageSize);
        return total;
    }

    public List<Book> GetAllBooksByTitleContains(string text)
    {
        //List<Book> filteredTitleBooks = new List<Book>();

        //foreach (Book book in books)
        //{
        //    if (book.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        filteredTitleBooks.Add(book);
        //    }
        //}
        //return filteredTitleBooks;

        //List<Book> result = books.Where(x => x.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase)).ToList();

        List<Book> result = books.FindAll(x => x.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase));
        return result;
    }

    public Book? GetBookByISBN(string isbn)
    {
        //Book book1 = null;
        //foreach(Book item in books)
        //{
        //    if(item.ISBN == isbn)
        //    {
        //        book1 = item;

        //    }

        //}

        //return book1 == null ? null : book1;

        //Book book = (from b in books where b.ISBN == isbn select b).FirstOrDefault();

        //Book book = books.Where(x => x.ISBN == isbn).FirstOrDefault();

        Book book = books.SingleOrDefault(x => x.ISBN == isbn);

        return book;
    }

    public Book Add(Book created)
    {
        books.Add(created);
        return created;
    }

    public Book? GetById(int id) 
    {
        Book? book1 = null;

        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                book1 = book;
            }
        }
        return book1 == null ? null : book1;

    }

    public Book? Remove(int id) 
    {
        Book? deletedBook = GetById(id);

        if (deletedBook is null) {
            return null;
        }
        return deletedBook;
    }

    public List<Book> GetAllBookOrderByTitle()
    {
        List<Book> orderBooks = books.OrderBy(b => b.Title).ToList();
        return orderBooks;
    }
    public List<Book> GetAllBookOrderByTitleDescending()
    {
        List<Book> orderBooks = books.OrderByDescending(b => b.Title).ToList();
        return orderBooks;
    }

    public Book GetBookMinPageSize()
    {
        Book? book = books.OrderBy(b =>b.PageSize).FirstOrDefault();
        return book;
    }
    public Book GetBookMaxPageSize()
    {
        Book? book = books.OrderByDescending(b => b.PageSize).FirstOrDefault();
        return book;
    }
    

    public List<BookDetailDto> GetDetails()
    {
        var result =
            from b in books
            join c in categories
            on b.CategoryId equals c.Id
            select new BookDetailDto(
                Id: b.Id,
                CategoryName: c.Name,
                "",
                Title: b.Title,
                Description: b.Description,
                PageSize: b.PageSize,
                PublishDate: b.PublishDate,
                Stock:b.Stock,
                ISBN: b.ISBN
                );

        return result.ToList();
    }

    public List<BookDetailDto> GetDetailsV2()
    {
        List<BookDetailDto> details =
            books.Join(categories,

            b => b.CategoryId,
            c => c.Id,
            (book, category) => new BookDetailDto(
                Id: book.Id,
                CategoryName: category.Name,
                "",
                Title: book.Title,
                Description: book.Description,
                PageSize: book.PageSize,
                PublishDate: book.PublishDate,
                Stock: book.Stock,
                ISBN: book.ISBN
                )
            ).ToList();

        return details;
    }

    public List<BookDetailDto> GetAllBookAndAuthorDetails()
    {
        var result =
            from b in books
            join c in categories on b.CategoryId equals c.Id
            join a in authors on b.AuthorId equals a.Id
            
            select new BookDetailDto(
                Id: b.Id,
                CategoryName: c.Name,
                AuthorName : $"{a.Name} {a.Surname}",
                Title: b.Title,
                Description: b.Description,
                PageSize: b.PageSize,
                PublishDate: b.PublishDate,
                Stock: b.Stock,
                ISBN: b.ISBN
                );

        return result.ToList();

        
    }

    public List<BookDetailDto> GetAllDetailsByCategoryId(int categoryId)
    {
        var result =            
            from b in books
            where b.CategoryId == categoryId
            join c in categories on b.CategoryId equals c.Id
            join a in authors on b.AuthorId equals a.Id
            
            select new BookDetailDto(
                Id: b.Id,
                CategoryName: c.Name,
                AuthorName: $"{a.Name} {a.Surname}",
                Title: b.Title,
                Description: b.Description,
                PageSize: b.PageSize,
                PublishDate: b.PublishDate,
                Stock: b.Stock,
                ISBN: b.ISBN
                );

        return result.ToList();
    }

    public List<Book> GetAllBookOrderByDescendingTitle()
    {
        throw new NotImplementedException();
    }

    public List<BookDetailDto> GetAllAuthorAndBookDetails()
    {
        throw new NotImplementedException();
    }

    public List<string> GetAllTitles()
    {
        throw new NotImplementedException();
    }
}
