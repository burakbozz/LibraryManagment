using LibraryManagment.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.ConsoleUI.Repository;

public interface IMemberRepository
{
    List<Member> GetAll();
    Member? GetById(int id);
    Member? Add(Member member);
    Member? Update(Member member);
    Member? Remove(int id);
}
