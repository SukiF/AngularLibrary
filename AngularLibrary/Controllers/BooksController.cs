using AngularLibrary.DataAccess;
using AngularLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularLibrary.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBooks()
        {
            List<Book> Books = BookRepository.GetBooksFromDB();
            return Json(Books, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditBook(Book book)
        {
            return Json(BookRepository.EditBook(book), JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult AddBook (Book book)
        {
            return Json(BookRepository.AddBook(book), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteBook(Book book)
        {
            return Json(BookRepository.DeleteBook(book), JsonRequestBehavior.AllowGet);
        }
    }
}