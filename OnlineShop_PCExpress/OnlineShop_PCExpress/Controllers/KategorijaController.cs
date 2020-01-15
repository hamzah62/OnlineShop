using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop_PCExpress.Controllers {
    public class KategorijaController : Controller {
        private readonly MojDbContext db;

        public KategorijaController(MojDbContext con) {
            db = con;
            }

        public IActionResult Index() {
            return View();
            }

        [HttpGet]
        public IActionResult Dodaj() {
            KategorijaPrikazVM k = new KategorijaPrikazVM();

            return PartialView("Dodaj", k);
            }

        [HttpPost]
        public IActionResult Dodaj(KategorijaPrikazVM k) {
            db.Kategorija.Add(new Kategorija {
                Naziv = k.Naziv
                });

            db.SaveChanges();
            return RedirectToAction("Index");
            }

        [HttpGet]
        public IActionResult Uredi(int id) {

            Kategorija k = db.Kategorija.Find(id);
            KategorijaPrikazVM vm = new KategorijaPrikazVM {
                ID = k.ID,
                Naziv = k.Naziv
                };

            return PartialView("Uredi", vm);
            }

        [HttpPost]
        public IActionResult Uredi(KategorijaPrikazVM k) {
            Kategorija o = db.Kategorija.Find(k.ID);
            o.Naziv = k.Naziv;

            db.SaveChanges();
            return RedirectToAction("Index");
            }

        public IActionResult Obrisi(int id) {
            db.Kategorija.Remove(db.Kategorija.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
            }

        public IActionResult ListaKategorijaUposlenik() {
            List<KategorijaPrikazVM> kategorije = db.Kategorija.Select(k => new KategorijaPrikazVM {
                Naziv = k.Naziv,
                ID = k.ID,
                podkategorije = db.Podkategorija.Where(p => p.KategorijaID == k.ID).Select(p => new PodkategorijaPrikazVM {
                    ID = p.ID,
                    Naziv = p.Naziv
                    }).ToList()
                }).ToList();

            return PartialView("ListaKategorijaUposlenik", kategorije);
            }

        public IActionResult ListaKategorijaMeni() {
            List<KategorijaPrikazVM> kategorije = db.Kategorija.Select(x => new KategorijaPrikazVM {
                ID = x.ID,
                Naziv = x.Naziv,
                podkategorije = db.Podkategorija.Where(p=>p.KategorijaID==x.ID).Select(p=> new PodkategorijaPrikazVM {
                    ID = p.ID,
                    Naziv = p.Naziv,
                    Kategorija_=new SelectListItem {
                        Value=x.ID.ToString()
                        }
                    }).ToList()
                }).ToList();

            return PartialView("ListaKategorijaMeni", kategorije);
            }
        }
    }