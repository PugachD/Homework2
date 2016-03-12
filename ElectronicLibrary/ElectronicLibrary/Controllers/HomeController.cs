using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicLibrary.Models;
using System.Data.Entity;

namespace ElectronicLibrary.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Main()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(User user)
        {
            user.Date = DateTime.Now;
            user.VisitDate = DateTime.Now;
            user.Balance = 200;
            //Добавляем инфу о пользователе в БД
            db.Users.Add(user);
            db.SaveChanges();
            return View("SuccessfulRegistration", user);
        }

        [HttpGet]
        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(User user)
        {
            bool userWasRegistered = true;

            foreach (User us in db.Users)
            {
                if (us == user)
                {
                    userWasRegistered = true;
                    user.VisitDate = DateTime.Now;
                    break;
                }
                else userWasRegistered = false;
            }
            if (db.Users.Count() == 0)
                userWasRegistered = false;
            db.SaveChanges();

            if (userWasRegistered) return View("UserWasRegistered", user);
            else return View("CheckInPlease");
        }
        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }

        public ActionResult Assortment()
        {

            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            return View();
        }

        [HttpGet]
        public ActionResult GetBook(int id)
        {

            if (id != 0)
            {
                User curClient = new User();
                foreach (var one in db.Users)
                {
                    if (curClient.VisitDate < one.VisitDate)
                    {
                        curClient = one;
                    }
                }

                if (curClient.BookId == null)
                {
                    IEnumerable<Book> books = db.Books;
                    Book book = new Book();
                    foreach (var item in db.Books)
                    {
                        if (item.Id == id)
                        {
                            item.OnHand++;
                            item.InLibrary--;
                            book = item;
                            break;
                        }
                    }
                    db.SaveChanges();
                    foreach (var user in db.Users)
                    {
                        if (user == curClient)
                        {
                            user.BookId = id;
                            user.Date = DateTime.Now;
                            break;
                        }
                    }
                    db.SaveChanges();
                    return View(book);
                }
                else return View("AlreadyHasBook");
            }
            else return View("NoBook");
        }

        public ActionResult ReturnBook()
        {
            User curClient = new User();
            foreach (var one in db.Users)
            {
                if (curClient.VisitDate < one.VisitDate)
                {
                    curClient = one;
                }
            }

            if (curClient.BookId != null)
            {
                IEnumerable<Book> books = db.Books;
                Book book = new Book();
                foreach (var item in db.Books)
                {
                    if (item.Id == curClient.BookId)
                    {
                        item.OnHand--;
                        item.InLibrary++;
                        book = item;
                        break;
                    }
                }
                db.SaveChanges();
                foreach (var person in db.Users)
                {
                    if (person == curClient)
                    {
                        person.BookId = null;
                        break;
                    }
                }
                db.SaveChanges();
                return View();
            }
            else return View("HasNoBook");

        }

        public ActionResult GetStatistics()
        {
            var users = db.Users.Include(p => p.Book);
            return View(users.ToList());
        }
    }
}