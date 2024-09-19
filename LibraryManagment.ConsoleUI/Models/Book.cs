namespace LibraryManagment.ConsoleUI.Models;

public record Book(
    int Id,
    int CategoryId,
    string Title,
    string Description,
    int PageSize,
    string PublisDate,
    int Stock,
    string ISBN

    );

