using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.ConsoleUI.Models.Dtos;

public record BookDetailDto(int CategoryName,
    string Title,
    string Description,
    int PageSize,
    string PublisDate,
    int Stock,
    string ISBN);

