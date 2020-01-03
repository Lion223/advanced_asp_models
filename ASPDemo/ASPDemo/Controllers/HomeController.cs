using ASPDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ASPDemo.Controllers
{
    public class HomeController : Controller
    {
        private GameDistributorContext context = new GameDistributorContext();

        public ActionResult Index()
        {
            var games = context.Games.Include(g => g.Distributor);
            return View(games.ToList());
        }

        public ActionResult DistributorDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Distributor distributor = context.Distributors.Include(d => d.Games).FirstOrDefault(d => d.Id == id);

            if (distributor == null)
            {
                return HttpNotFound();
            }

            return View(distributor);
        }

        [HttpGet]
        public ActionResult Add()
        {
            SelectList distributors = new SelectList(context.Distributors, "Id", "Name");
            ViewBag.Distributors = distributors;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Game game = context.Games.Find(id);

            if (game != null)
            {
                SelectList distributors = new SelectList(context.Distributors, "Id", "Name", game.DistributorId);
                ViewBag.Distributors = distributors;
                return View(game);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Game g = context.Games.Include(model => model.Distributor).FirstOrDefault(model => model.Id == id);

            if (g == null)
            {
                return HttpNotFound();
            }

            return View(g);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            Game g = context.Games.Find(id);

            if (g == null)
            {
                return HttpNotFound();
            }

            context.Games.Remove(g);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}