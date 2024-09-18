

using LibraryManagment.ConsoleUI.Models;

namespace LibraryManagment.ConsoleUI.Repository;


public class BookRepository
{
    List<Book> books = new List<Book>()
   {
    new Book(1,"Germinal","Kömür Madeni",341,"2012 mayıs",15,"1234560"),
    new Book(2,"Suç ve Ceza","raskolnikaovun hayatı",315,"2010 Haziran",10,"1234570"),
    new Book(3,"Kumarbaz","Bir öğretmenin hayatı",210,"2009 ocak",10,"1234580"),
    new Book(4,"Araba sevdası","Arabayla alakası olmayan kitap",180,"1999 Haziran",10,"1234590"),
    new Book(5,"Ateşten Gömlek","Kurtuluş Savaş",315,"2001 Haziran",10,"1234510"),
    new Book(6,"Kaşağı","kitap",315,"1993 Haziran",10,"1234511"),
    new Book(7,"28 şampiyonluk","Hayak ürünü",150,"1993 Haziran",10,"1234512"),
    new Book(8,"16 yıl şampiyonluk","Hayak ürünü",350,"1995 Haziran",10,"1234513"),

   };


    public List<Book> GetAll()
    {
        return books;
    }

    public List<Book> GetAllBooksByPageSizeFilter(int min, int max)
    {
        List<Book> filteredBooks = new List<Book>();

        foreach (Book book in books)
        {
            if (book.PageSize <= max && book.PageSize >= min)
            {
                filteredBooks.Add(book);
            }
        }
        return filteredBooks;
    }

    public double PageSizeTotalCalculator()
    {
        double total = books.Sum(x => x.PageSize);
        return total;
    }

    public List<Book> GetAllBooksByTitleContains(string text)
    {
        List<Book> filteredTitleBooks = new List<Book>();

        foreach (Book book in books)
        {
            if (book.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
            {
                filteredTitleBooks.Add(book);
            }
        }
        return filteredTitleBooks;
    }

    public Book? GetBookByISBN(string isbn)
    {
        Book book1 = null;
        foreach(Book item in books)
        {
            if(item.ISBN == isbn)
            {
                book1 = item;

            }
            
        }

        return book1 == null ? null : book1;
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
}
