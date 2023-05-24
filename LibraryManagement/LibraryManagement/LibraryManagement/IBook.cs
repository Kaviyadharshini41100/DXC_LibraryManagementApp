using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public interface IBook
    {
        int AddStudent();
        int AddBook();
        int EditStudent();
        int EditBook();
        int DeleteStudent();
        int DeleteBook();
    }
}

