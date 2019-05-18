using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PNet_Again.Models;
using PNet_HomeWork.Models;

namespace PNet_Again.Controllers
{
    public class FishController : Controller
    {
        private WorldContext db = new WorldContext();
        private event FishDelegate SpecialFishEncountered;

        public FishController()
        {
            SpecialFishEncountered += OnSpecialFish;
        }

        private void OnSpecialFish(Fish fish)
        {
            Fish easterEggFish = new Fish()
            {
                Height = 69,
                Width = 69,
                Length = 69,
                ScientificName = fish.ScientificName + " 6ix9ine",
                ShortName = "Ohmy",
                FinType = FinType.Curved,
                //River = null,
                //RiverId = null,
            };
            easterEggFish.SwimmingCharacteristics = new SwimmingCharacteristics()
            {
                AverageDepth = 6.9,
                AverageSpeed = 6.9,
                Fish = easterEggFish,
                FishId = easterEggFish.FishId,
                HasBag = true,
            };

            db.Fishes.Add(easterEggFish);
            db.SaveChanges();
        }

        public ActionResult Proc()
        {
            var fishes = db.Database.SqlQuery<Fish>("GetSmallNameFishes");

            return View("Index", fishes);
        }

        public ActionResult Delayed()
        {
            IQueryable<Fish> fishes = db.Fishes
                .Include(f => f.River)
                .Include(f => f.SwimmingCharacteristics)
                .Where(x => x.Length < 10);

            return View("Index", fishes.ToList());
        }

        // GET: Fish
        public ActionResult Index()
        {
            var fishes = db.Fishes.Include(f => f.River).Include(f => f.SwimmingCharacteristics);
            return View(fishes.ToList());
        }

        // GET: Fish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.Fishes.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // GET: Fish/Create
        public ActionResult Create()
        {
            ViewBag.RiverId = new SelectList(db.Rivers, "RiverId", "Name");
            return View();
        }

        // POST: Fish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Fish fish)
        {
            if (ModelState.IsValid)
            {
                db.Fishes.Add(fish);
                db.SaveChanges();
                if (fish.ShortName.Contains("lesh") || fish.ScientificName.Contains("lesh"))
                {
                    SpecialFishEncountered?.Invoke(fish);
                    return View(viewName: "EasterEggView");
                }
                return RedirectToAction("Index");
            }

            ViewBag.RiverId = new SelectList(db.Rivers, "RiverId", "Name", fish.RiverId);
            return View(fish);
        }

        // GET: Fish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.Fishes.Include(f => f.SwimmingCharacteristics).FirstOrDefault(f => f.FishId == id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            ViewBag.RiverId = new SelectList(db.Rivers, "RiverId", "Name", fish.RiverId);
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind] Fish fish)
        {
            if (ModelState.IsValid)
            {
                // А иначе эта сволочь (мвц со своей моделью для вьюхи) обнуляла FishId и Fish у SwimmingCharacteristics
                fish.SwimmingCharacteristics.Fish = fish;
                fish.SwimmingCharacteristics.FishId = fish.FishId;
                // конец возмущенного комментария

                db.Entry(fish).State = EntityState.Modified;
                db.Entry(fish.SwimmingCharacteristics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RiverId = new SelectList(db.Rivers, "RiverId", "Name", fish.RiverId);
            return View(fish);
        }

        // GET: Fish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.Fishes.Include(f => f.SwimmingCharacteristics).FirstOrDefault(f => f.FishId == id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fish fish = db.Fishes.Include(f => f.SwimmingCharacteristics).FirstOrDefault(f => f.FishId == id);
            db.Entry(fish.SwimmingCharacteristics).State = EntityState.Deleted;
            db.Entry(fish).State = EntityState.Deleted;
            //db.Fishes.Remove(fish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
