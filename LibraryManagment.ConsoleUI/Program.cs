//(Record)Kitap ->Id, Title,Description,PageSize,PublishDate,ISBN
//(Record)Author ->Id, Name,Surname
//(Class)Category ->Id, Name,

//Category eklerken ıd ve name alanları benzersiz olmalı
//Author eklerken ıd (name Surname)

//Kitaplar listesi oluşturunuz.
//yazarlar listesi oluşturunuz.
//kategoriler listesi oluşturunız.

//Yazarları, kitapları, kategorileri ekrana yazdırın.
//Kitapları sayfa sayısına göre filtreleyen kodu yazın
//tüm kitapların sayfasını hesaplayan kodu yazın.
//kitap başlığına göre filtreleme yapın.
//kitap ISBN numarasına göre ilgili kitabı getiriniz.

// kitaplar listesine yeni bir kitap ekleyip,listenin ekran çıktısını tekrar yazdırın.
// kitap eklerken Id si veya ISBN numarası dahga önceki eklenen kitaplarda varsa "Benzersiz bira girmeniz gerekmektedir. " yazısı çıksın 
//Verileri kullanıcdan alınız.

//Kullanıcı bir ıd girdiği zaamn o id ye göre kitabı silme ve listeyi tekrar yazdıran kodu yazınız.

//Kullanıcıdan ilk başta Id değeri alıp arama yaptıktan sonra eğer o id ye ait bir kitap yoksa "ilgili ıd ye ait bir kitap bulunamadı."
//güncellenecek olan değerler kullanıcdan alınacak.

//Kullanıcdan bir kitap alınmasını isteyen kodu yazınız.
//eğer o kitap stok da varsa kitap alındı yazısı çıksın 
//1 tane varsa o kitap alınsın ve 0 olursa listenen silinsin.

//Prime örnekler
//BookDetail adında bir record oluşturup şu değerler listlenecek
//Kitap Id, Kitap başlığı, kitap açıklaması,kitap sayfa sayısı,ISBN
//Yazar adı, Kategori Adı.

//kullanıcıdan page index ve page size değerleri alarak sayfalama desteği getiriniz.

using LibraryManagment.ConsoleUI.Models;
using LibraryManagment.ConsoleUI.Service;


BookService bookService = new BookService();

bookService.GetAll();
//bookService.GetById(2);
//bookService.Remove(55);
//bookService.GetBookByISBN("1234560");
//bookService.GetAllBooksByTitleContains("Kumarbaz");
//bookService.GetBookMinPageSize();
//bookService.GetBookMaxPageSize();


List<Author> authors = new List<Author>()
{
    new Author(1,"Emile","Zola"),
    new Author(2,"Fyodor","Dostoyevski"),
    new Author(3,"Recaizade Mahmut","Ekrem"),
    new Author(4,"Halide edip","Adıvar"),
    new Author(5,"Ömer","Seyfettin"),
    new Author(6,"Ali","Koç"),

};


//foreach (Author author in authors)
//{
//    Console.WriteLine(author);
//}
//foreach (Book book in books)
//{
//    Console.WriteLine(book);
//}
//foreach (Category category in categories)
//{
//    Console.WriteLine(category);
//}

//void GetAllBooks()
//{
//    Console.WriteLine("Kitapları Listele");
//    Console.WriteLine("--------------------------------");
//    foreach (Book book in books)
//    {
//        Console.WriteLine(book);
//    }
//}
void GetAllAuthors()
{
    Console.WriteLine("Yazarları Listele");
    Console.WriteLine("------------------------");
    foreach (Author author in authors)
    {
        Console.WriteLine(author);
    }
}
void GetAllCategories()
{
    Console.WriteLine("Kategorileri Listele");
    Console.WriteLine("---------------------------");
    foreach (Category category in categories)
    {
        Console.WriteLine(category);
    }
}

//GetAllBooks();
//GetAllAuthors();
//GetAllCategories();


//var filteredBooks = books.Where(book => book.PageSize > 100 && book.PageSize < 200);



void PrintAyrac(string metin)
{
    Console.WriteLine(metin);
    Console.WriteLine("-------------------");
}



//GetBookByISBN();

Book GetBookInputs2()
{
    Console.WriteLine("Lütfen kitap id sini giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    string title = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    string description = Console.ReadLine();

    Console.WriteLine("Lütfen kitap sayfasını giriniz: ");
    int pageSize = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    string publishDate = Console.ReadLine();

    Console.WriteLine("Lütfen kitap ISBN numarasını giriniz: ");
    string isbn = Console.ReadLine();

    Console.WriteLine("Lütfen stok giriniz: ");
    int stock = Convert.ToInt32(Console.ReadLine());


    Book book = new Book(id,1, title, description, pageSize, publishDate,stock,isbn);
    return book;
}

//bool AddBookValidator(Book book)
//{
//    bool isUnique = true;

//    foreach (Book item in books)
//    {
//        if (item.Id == book.Id || item.ISBN == book.ISBN)
//        {
//            isUnique = false;
//            break;
//        }
//    }

//    return isUnique;
//}

void GetBookInputs(out int id,
     out string title,
     out string description,
     out int pageSize,
     out string publishDate,
     out int stock,
     out string isbn)
{
    Console.WriteLine("Lütfen kitap id sini giriniz: ");
    id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    title = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    description = Console.ReadLine();

    Console.WriteLine("Lütfen kitap sayfasını giriniz: ");
    pageSize = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    publishDate = Console.ReadLine();

    Console.WriteLine("Lütfen kitap ISBN numarasını giriniz: ");
    isbn = Console.ReadLine();

    Console.WriteLine("lütfen stok girin");
    stock = Convert.ToInt32(Console.ReadLine());
}

//void AddBook()
//{
//    //1. Yöntem
//    //int id;
//    //string title;
//    //string description;
//    //int pageSize;
//    //string publishDate;
//    //stock
//    //string isbn;


//    //GetBookInputs(out id,out title,out description,out pageSize,out publishDate,out isbn);
//    Book book = GetBookInputs2();

//    bool isUnique = AddBookValidator(book);

//    if (!isUnique)
//    {
//        Console.WriteLine("Girmiş olduğunuz kitap Benzersiz değil.");
//        return;
//    }

//    books.Add(book);
//    GetAllBooks();
//}

//AddBook();
Category GetCategoryInputs()
{
    Console.WriteLine("Lütfen kategori id si giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    string name = Console.ReadLine();


    Category category = new Category(id,name);
    return category;
}

bool AddCategoryValidator(Category category)
{
    bool isUniqueCategory = true;

    foreach (Category item in categories)
    {
        if (item.Id == category.Id || item.Name == category.Name)
        {
            isUniqueCategory = false;
            break;
        }
    }

    return isUniqueCategory;
}


void AddCategory()
{
    Category category = GetCategoryInputs();
    bool isUniqueCategory = AddCategoryValidator(category);

    if (!isUniqueCategory)
    {
        Console.WriteLine("Girmiş olduğunuz category Benzersiz değil.");
        return;
    }

    categories.Add(category);
    GetAllCategories();
}

//AddCategory();


Author GetAuthorInputs()
{

    Console.WriteLine("Lütfen yazar id si giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen  yazar ismi başlığını giriniz: ");
    string name = Console.ReadLine();
    Console.WriteLine("Lütfen  yazar soy ismi başlığını giriniz: ");
    string surname = Console.ReadLine();


    Author author = new Author(id, name,surname);
    return author;
}

bool AddAuthorValidator(Author author)
{
    bool isUniqueAuthor = true;

    foreach (Author item in authors)

    {
        if (item.Id == author.Id || (item.Name == author.Name && item.Surname == author.Surname))
        {
            isUniqueAuthor = false;
            break;
        }
    }

    return isUniqueAuthor;
}

void AddAuthor()
{
    Author author = GetAuthorInputs();
    bool isUniqueAuthor = AddAuthorValidator(author);

    if (!isUniqueAuthor)
    {
        Console.WriteLine("Girmiş olduğunuz Yazar Benzersiz değil.");
        return;
    }

    authors.Add(author);
    GetAllAuthors();
}

//AddAuthor();




