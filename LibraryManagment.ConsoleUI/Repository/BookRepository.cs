

using LibraryManagment.ConsoleUI.Models;
using LibraryManagment.ConsoleUI.Models.Dtos;
using System.Linq;

namespace LibraryManagment.ConsoleUI.Repository;


public class BookRepository
{
    List<Author> authors = new List<Author>()
    {
    new Author(1,"Emile","Zola"),
    new Author(2,"Fyodor","Dostoyevski"),
    new Author(3,"Recaizade Mahmut","Ekrem"),
    new Author(4,"Halide edip","Adıvar"),
    new Author(5,"Ömer","Seyfettin"),
    new Author(6,"Ali","Koç"),

    };


    List<Book> books = new List<Book>()
   {
    new Book(1,1,1,"Germinal","Kömür Madeni",341,"2012 mayıs",15,"1234560"),
    new Book(2,1,2,"Suç ve Ceza","raskolnikaovun hayatı",315,"2010 Haziran",10,"1234570"),
    new Book(3,1,3,"Kumarbaz","Bir öğretmenin hayatı",210,"2009 ocak",10,"1234580"),
    new Book(4,1,4,"Araba sevdası","Arabayla alakası olmayan kitap",180,"1999 Haziran",10,"1234590"),
    new Book(5,2,5,"Ateşten Gömlek","Kurtuluş Savaş",315,"2001 Haziran",10,"1234510"),
    new Book(6,2,6,"Kaşağı","kitap",315,"1993 Haziran",10,"1234511"),
    new Book(7,3,6,"28 şampiyonluk","Hayak ürünü",150,"1993 Haziran",10,"1234512"),
    new Book(8,3,6,"16 yıl şampiyonluk","Hayak ürünü",350,"1995 Haziran",10,"1234513"),

   };


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
    List<Category> categories = new List<Category>()
    {
    new Category(1,"Dünya klasikleri"),
    new Category(2,"Türk Klasikleri"),
    new Category(3,"Bilim Kurgu"),

    };

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
    
}
