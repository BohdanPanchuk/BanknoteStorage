using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanknoteStorage_MVC.Models;

namespace BanknoteStorage_MVC.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.BanknoteServiceClient banknoteServiceClient = new ServiceReference1.BanknoteServiceClient();

        public ActionResult Index()
        {
            List<Banknote> banknotesList = new List<Banknote>();

            var banknotesInDatabase = banknoteServiceClient.GetAllBanknotes();

            foreach (var item in banknotesInDatabase)
            {
                Banknote banknote = new Banknote();

                banknote.Id = item.Id;
                banknote.Value = item.Value;
                banknote.Count = item.Count;

                banknotesList.Add(banknote);
            }

            return View(banknotesList);
        }

        public ActionResult AddBanknote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBanknote(Banknote newBanknote)
        {
            int resultValue = banknoteServiceClient.AddBanknote(newBanknote.Value, newBanknote.Count);

            if (resultValue > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Error");
        }

        public ActionResult EditBanknote(int id)
        {
            Banknote currentBanknote = new Banknote();
            var banknoteInDatabase = banknoteServiceClient.GetBanknoteById(id);

            currentBanknote.Id = banknoteInDatabase.Id;
            currentBanknote.Value = banknoteInDatabase.Value;
            currentBanknote.Count = banknoteInDatabase.Count;

            return View(currentBanknote);
        }

        [HttpPost]
        public ActionResult EditBanknote(Banknote newBanknote)
        {
            banknoteServiceClient.EditBanknote(newBanknote.Id, newBanknote.Value, newBanknote.Count);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteBanknote(int id)
        {
            banknoteServiceClient.DeleteBanknote(id);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetBanknotesByValue()
        {
            return View();
        }

        public ActionResult GetBanknotesByCount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBanknotesByValue(int value)
        {
            List<Banknote> banknotesList = new List<Banknote>();

            var banknotesInDatabase = banknoteServiceClient.GetBanknotesByValue(value);

            foreach (var item in banknotesInDatabase)
            {
                Banknote banknote = new Banknote();

                banknote.Id = item.Id;
                banknote.Value = item.Value;
                banknote.Count = item.Count;

                banknotesList.Add(banknote);
            }

            return View("BanknotesByValue", banknotesList);
        }

        [HttpPost]
        public ActionResult GetBanknotesByCount(int count)
        {
            List<Banknote> banknotesList = new List<Banknote>();

            var banknotesInDatabase = banknoteServiceClient.GetBanknotesByCount(count);

            foreach (var item in banknotesInDatabase)
            {
                Banknote banknote = new Banknote();

                banknote.Id = item.Id;
                banknote.Value = item.Value;
                banknote.Count = item.Count;

                banknotesList.Add(banknote);
            }

            return View("BanknotesByCount", banknotesList);
        }
    }
}