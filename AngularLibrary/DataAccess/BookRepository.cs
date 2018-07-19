using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using AngularLibrary.Models;

namespace AngularLibrary.DataAccess
{
    public class BookRepository
    {
        private static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public static List<Book> GetBooksFromDB()
        {
            List<Book> Books = db.Query<Book>("Select * From Books").ToList();
            return Books;
        }

        public static Book AddBook(Book book)
        {
            db.Execute("Insert INTO Books (BookTitle, BookAuthor, BookPages) VALUES ( @BookTitle, @BookAuthor, @BookPages)", new {
                @BookTitle = book.BookTitle, @BookAuthor = book.BookAuthor, @BookPages = book.BookPages });

            book = db.Query<Book>("Select * From Books Where BookTitle = @BookTitle", new { @BookTitle = book.BookTitle }).FirstOrDefault();
            return book;
        }

        public static bool EditBook(Book book)
        {
            bool success = false;
            int result = db.Execute("Update Books Set BookTitle = @BookTitle, BookAuthor = @BookAuthor, BookPages = @BookPages Where Id = @Id", new
            {
                @BookTitle = book.BookTitle,
                @BookAuthor = book.BookAuthor,
                @BookPages = book.BookPages,
                @id = book.Id
            });
            if(result == 1)
            {
                success = true;
            }
            return success;
        }

        public static bool DeleteBook(Book book)
        {
            bool success = false;
            int result = db.Execute("DELETE FROM Books WHERE BookTitle = @BookTitle", new
            {
                @BookTitle = book.BookTitle
            });
            if (result == 1)
            {
                success = true;
            }
            return success;
        }
    }
}