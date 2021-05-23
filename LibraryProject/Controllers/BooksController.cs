using LibraryProject.Data;
using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Htto Get Index
        public IActionResult Index()
        {
            IEnumerable<Book> listBooks = _context.Book;
            return View(listBooks);
        }
        //Htto Get Create
        public IActionResult Create()
        {
            return View();
        }
        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
                _context.SaveChanges();

                TempData["message"] = $"The book '{book.Title}' was created successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Get Book
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Update(book);
                _context.SaveChanges();

                TempData["message"] = $"The book \"{book.Title}\" was edited successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Get Book
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }
            _context.Book.Remove(book);
            _context.SaveChanges();

            TempData["message"] = $"The book \"{book.Title}\" was deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
