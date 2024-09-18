using LibraryManagment.ConsoleUI.Models;
using LibraryManagment.ConsoleUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.ConsoleUI.Service;

public class BookService
{
    BookRepository bookRepository = new BookRepository();

    public void GetAll()
    {
        List<Book> books = bookRepository.GetAll();
        foreach (Book book in books) {
            Console.WriteLine(book);
        }
        
    }
    public void GetById(int id) {
        Book? book = bookRepository.GetById(id);
        if (book is null) {
            Console.WriteLine($"aradığını id ye kitap bulunamadı {id}");
            return;
        }
        Console.WriteLine(book);
    }
    public void Remove(int id) {
        Book? deletedBook = bookRepository.Remove(id);

        if (deletedBook is null) 
        {
            Console.WriteLine("aradığınız kitap bulunamadı");
            return;


        }
        Console.WriteLine(deletedBook);
        
    }
    public void GetBookByISBN(string isbn)
    {
        Book? book = bookRepository.GetBookByISBN(isbn);
        if (book is null) {
            Console.WriteLine($"Aradığınız ISNM numarına göre kitap bulunamadı {isbn}");
            return;
        }
        Console.WriteLine(book);
    }
}
