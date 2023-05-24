using LibraryManagement;
using System.Data;
using System.Data.SqlClient;
using Spectre.Console;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;

namespace LibraryManagement
{
    public class Library
    {
        public bool Login_Details(SqlConnection con)
        {
            Console.WriteLine("Enter User Name: ");
            string user_name = Console.ReadLine();
            Console.WriteLine("Enter User Password: ");
            string user_password =Console.ReadLine();
            SqlDataAdapter adp = new SqlDataAdapter($"select * from  Login_user where  user_name='{user_name}' and  user_password ='{user_password}' ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds,"userTable");
            SqlCommandBuilder cmd = new SqlCommandBuilder();
            adp.Fill(ds, "UserTable");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void AddBook(SqlConnection con)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Book", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "BookTable");
            var row = ds.Tables["BookTable"].NewRow();
            
            Console.WriteLine("Enter book Title:");
            row["bookTitle"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Author Name: ");
            row["authorname"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Publication:");
            row["publication"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Book Available Stock: ");
            row["stock"] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Book Price: ");
            row["price"] = Convert.ToInt32(Console.ReadLine());

            ds.Tables["BookTable"].Rows.Add(row);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds, "BookTable");
            Console.WriteLine("Book Added successfully");
        }
        public void EditBook(SqlConnection con)
        {

            Console.WriteLine("Enter Book Id to edit:");
            int bookId = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Book where bookId='{bookId}'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].Rows[0];

            Console.WriteLine("Enter Book Title for update: ");
            row["bookTitle"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Book Author Name: ");
            row["authorname"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Book Publication: ");
            row["publication"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Book Avilable Stock: ");
            row["stock"] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Book Price: ");
            row["price"] = Convert.ToInt32(Console.ReadLine());
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Book Edited Successfully!! ");

        }
        public void DeleteBook(SqlConnection con)
        {
            Console.WriteLine("Enter the Book id");
            int bookId = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Book where bookId = '{bookId}'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Rows[0].Delete();
                SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
                adp.Update(ds);
                Console.WriteLine("Book Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Book not found for this Id");
            }
        }
        public void AddStudent(SqlConnection con)
        {
           
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Student", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "StudTable");
            var row = ds.Tables["StudTable"].NewRow();
            
            Console.WriteLine("Enter Student Name:");
            row["stdName"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Roll no: ");
            row["rollno"] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Department:");
            row["department"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Email: ");
            row["email"] = Convert.ToString(Console.ReadLine());


            Console.WriteLine("Enter Phone no: ");
            row["phoneno"] = Convert.ToInt64(Console.ReadLine());

            ds.Tables["StudTable"].Rows.Add(row);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds, "StudTable"); 
            Console.WriteLine("Student details Added successfully");
        }
        public void EditStudent(SqlConnection con)
        {
            Console.WriteLine("Enter Student Id");
            int stdId = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Student where stdId='{stdId}'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].Rows[0];

            Console.WriteLine("Enter Student Name for update:");
            row["stdName"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Rollno for update: ");
            row["rollno"] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Department for update:");
            row["department"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Email for update: ");
            row["email"] = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Phone no: ");
            row["phoneno"] = Convert.ToInt64(Console.ReadLine());
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Student details Edited Successfully!! ");
        }
        public void DeleteStudent(SqlConnection con)
        {
            Console.WriteLine("Enter the Student id");
            int stdId = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Student where stdId = '{stdId}'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Rows[0].Delete();
                SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
                adp.Update(ds);
                Console.WriteLine("Student details Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Student not found for this Id");
            }
        }
        
        public void Book_issue(SqlConnection con)
        {
            try
            {

                Console.WriteLine("Enter Book ID:");
                int bookId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student ID:");
                int stdId = Convert.ToInt32(Console.ReadLine());
                DateTime issue_date = DateTime.Now;
                SqlDataAdapter adp = new SqlDataAdapter($"select * from  Book where bookId='{bookId}'", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow Row = ds.Tables[0].Rows[0];
                    int stock = Convert.ToInt32(Row["stock"]);
                    if (stock > 0)
                    {

                        SqlDataAdapter adp1 = new SqlDataAdapter($"select * from Book_issue", con);
                        DataSet ds1 = new DataSet();
                        adp1.Fill(ds1);
                        var row = ds1.Tables[0].NewRow();
                        row["stdId"] = stdId;
                        row["bookId"] = bookId;
                        row["issue_date"] = issue_date;
                        ds1.Tables[0].Rows.Add(row);
                        SqlCommandBuilder cmd = new SqlCommandBuilder(adp1);
                        adp1.Update(ds1);
                        Console.WriteLine(" Book Issued to student successfully");
                        SqlDataAdapter adp2 = new SqlDataAdapter($"select * from  Book where bookId='{bookId}'", con);
                        DataSet ds2 = new DataSet();
                        adp2.Fill(ds2);
                        var row1 = ds2.Tables[0].Rows[0];
                        row1["stock"] = stock - 1;
                        SqlCommandBuilder cmd2 = new SqlCommandBuilder(adp2);
                        adp2.Update(ds2);
                    }
                    else
                    {
                        Console.WriteLine("No more copies of the book are available");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found in the Database.");
                }
            }
            catch
            {
                Console.WriteLine("Error !!The Book is already issued.. Plz return the book and try again");
            }
        }
        public void ReturnBook(SqlConnection con)
        {
            Console.WriteLine("Enter Student Id");
            int stdId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the book id");
            int bookId = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from  Book_issue where  bookId='{bookId}' and  stdId ='{stdId}' ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                SqlDataAdapter adp1 = new SqlDataAdapter($"select * from Book_issue where bookId='{bookId}' and stdId='{stdId}'", con);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                ds1.Tables[0].Rows[0].Delete();
                SqlCommandBuilder cmd = new SqlCommandBuilder(adp1);
                adp1.Update(ds1);
                Console.WriteLine("Book Returned Successfully !");
                SqlDataAdapter adp2 = new SqlDataAdapter($"select * from Book where bookId={bookId}", con);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                DataRow row = ds2.Tables[0].Rows[0];
                int stock = Convert.ToInt32(row["stock"]);
                row["stock"] = stock + 1;
                SqlCommandBuilder cmd1 = new SqlCommandBuilder(adp2);
                adp2.Update(ds2);
            }
            else
            {
                Console.WriteLine("Book is not issued!!");
            }
        }
        public void SearchStudent(SqlConnection con)
        {
            Console.WriteLine("Enter Student Id to Search: ");
            int stdId = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Student where stdId ='{stdId}'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {

                        Console.Write($"{ds.Tables[0].Rows[i][j]}\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Student Found");
            }

        }
        public void SearchBook(SqlConnection con)
        {
            Console.WriteLine("Enter Book Publication to Search: ");
            string publication = Console.ReadLine();
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Book where publication ='{publication}'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {

                        Console.Write($"{ds.Tables[0].Rows[i][j]}\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid publication name!");
            }
        }
        public void TotalBooks(SqlConnection con)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Book_issue ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Console.WriteLine("Total no of book issued is:");
            Console.WriteLine(ds.Tables[0].Rows.Count);

        }

        internal class Program
        {
            static void Main(string[] args)
            {
                SqlConnection con = new SqlConnection("Server=IN-2HRQ8S3; database=LibraryManagement; Integrated Security=true");
                Library library = new Library();
                if (library.Login_Details(con))
                {
                    while (true)
                    {

                        
                        AnsiConsole.MarkupLine("[bold green]****Welcome To Library Management App****[/]");
                        AnsiConsole.MarkupLine("[bold yellow]1  Add Book[/]");
                        AnsiConsole.MarkupLine("[bold yellow]2  Edit Book[/]");
                        AnsiConsole.MarkupLine("[bold yellow]3  Delete Book[/]");
                        AnsiConsole.MarkupLine("[bold yellow]4  Add Student[/]");
                        AnsiConsole.MarkupLine("[bold yellow]5  Edit Student[/]");
                        AnsiConsole.MarkupLine("[bold yellow]6  Delete Student[/]");
                        AnsiConsole.MarkupLine("[bold yellow]7  BookIssue[/]");
                        AnsiConsole.MarkupLine("[bold yellow]8  Return Books[/]");
                        AnsiConsole.MarkupLine("[bold yellow]9  Search Student[/]");
                        AnsiConsole.MarkupLine("[bold yellow]10 Search Book by Publication[/]");
                        AnsiConsole.MarkupLine("[bold yellow]11 Total book student have[/]");
                        try
                        {
                            AnsiConsole.MarkupLine("[bold red]Enter your choice[/]");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    {
                                        library.AddBook(con);
                                        break;
                                    }
                                case 2:
                                    {
                                        library.EditBook(con);
                                        break;
                                    }
                                case 3:
                                    {
                                        library.DeleteBook(con);
                                        break;
                                    }
                                case 4:
                                    {
                                        library.AddStudent(con);
                                        break;
                                    }
                                case 5:
                                    {
                                        library.EditStudent(con);
                                        break;
                                    }
                                case 6:
                                    {
                                        library.DeleteStudent(con);
                                        break;
                                    }
                                case 7:
                                    {
                                        library.Book_issue(con);
                                        break;
                                    }
                                case 8:
                                    {
                                        library.ReturnBook(con);
                                        break;
                                    }
                                case 9:
                                    {
                                        library.SearchStudent(con);
                                        break;
                                    }
                                case 10:
                                    {
                                        library.SearchBook(con);
                                        break;
                                    }
                                case 11:
                                    {
                                        library.TotalBooks(con);
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Enter a valid option");
                                        break;
                                    }

                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter Numbers Only From 1 to 5");
                        }
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Wrong user id or password you Entered! Please Provide a valid one[/]");
                }
            }
        }
    }
}

     
     
       
  
