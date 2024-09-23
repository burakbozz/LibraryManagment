using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.ConsoleUI.Models.Dtos;

public record BookDetailDto(
    int Id,
    string CategoryName,
    string AuthorName,
    string Title,
    string Description,
    int PageSize,
    string PublishDate,
    int Stock,
    string ISBN
    );

