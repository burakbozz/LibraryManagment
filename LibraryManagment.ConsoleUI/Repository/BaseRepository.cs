using LibraryManagment.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.ConsoleUI.Repository;

public abstract class BaseRepository{
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
    List<Category> categories = new List<Category>()
    {
    new Category(1,"Dünya klasikleri"),
    new Category(2,"Türk Klasikleri"),
    new Category(3,"Bilim Kurgu"),

    };
    private List<Member> members = new List<Member>()
    {
        new Member
        {
            Id=1,
            Age= 25,
            Name = "Eva",
            Surname = "Neva"
        },
        new Member
        {
            Id=2,
            Name ="Sosyal Ankastre 1",
            Surname = "Sosyal Ankastre 1",
            Age = 25,
        }
    };


    public List<Book> Books()
    {
        return books;
    }

    public List<Category> Categories()
    {
        return categories;
    }

    public List<Author> Authors()
    {
        return authors;
    }

    public List<Member> Members()
    {
        return members;
    }
}

