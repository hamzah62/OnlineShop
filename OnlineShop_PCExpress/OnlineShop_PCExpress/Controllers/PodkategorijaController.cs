using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop_PCExpress.Controllers {
    public class PodkategorijaController : Controller {
        private readonly MojDbContext db;

        public object Kategorija_ { get; private set; }

        public PodkategorijaController(MojDbContext con) {
            db = con;
            }

        public IActionResult Index() {
            return View();
            }

        [HttpGet]
        public IActionResult Dodaj() {
            PodkategorijaPrikazVM k = new PodkategorijaPrikazVM();
            ViewBag.Kategorija = db.Kategorija.Select(p => new SelectListItem {
                Value = p.ID.ToString(),
                Text = p.Naziv
                }).ToList();

            return PartialView("Dodaj", k);
            }

        [HttpPost]
        public IActionResult Dodaj(PodkategorijaPrikazVM k) {
            db.Podkategorija.Add(new Podkategorija {
                Naziv = k.Naziv,
                KategorijaID = int.Parse(k.Kategorija_.Value)
                });

            db.SaveChanges();
            return RedirectToAction("Index");
            }

        [HttpGet]
        public IActionResult Uredi(int id) {

            Podkategorija p = db.Podkategorija.Find(id);
            PodkategorijaPrikazVM vm = new PodkategorijaPrikazVM {
                ID = p.ID,
                Naziv = p.Naziv,
                Kategorija_ = new SelectListItem {
                    Value = p.KategorijaID.ToString()
                    }
                };

            ViewBag.Kategorije = db.Kategorija.Select(p => new SelectListItem {
                Value = p.ID.ToString(),
                Text = p.Naziv
                }).ToList();

            return PartialView("Uredi", vm);
            }

        [HttpPost]
        public IActionResult Uredi(PodkategorijaPrikazVM k) {
            Podkategorija o = db.Podkategorija.Find(k.ID);
            o.Naziv = k.Naziv;
            o.KategorijaID = int.Parse(k.Kategorija_.Value);

            db.SaveChanges();
            return RedirectToAction("Index");
            }

        public IActionResult Obrisi(int id) {
            db.Podkategorija.Remove(db.Podkategorija.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
            }

        public IActionResult ListaPodkategorijaUposlenik() {

            List<PodkategorijaPrikazVM> kategorije = db.Podkategorija.Select(k => new PodkategorijaPrikazVM {
                Naziv = k.Naziv,
                ID = k.ID,
                Kategorija_ = new SelectListItem {
                    Value = k.KategorijaID.ToString(),
                    Text = db.Kategorija.Where(x => x.ID == k.KategorijaID).FirstOrDefault().Naziv
                    }
                }).ToList();



            return PartialView("ListaPodkategorijaUposlenik", kategorije);
            }


        }
    }