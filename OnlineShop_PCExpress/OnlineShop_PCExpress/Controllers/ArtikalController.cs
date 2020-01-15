using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop_PCExpress.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop_PCExpress.Controllers {
    public class ArtikalController : Controller {

        private readonly MojDbContext db;

        public ArtikalController(MojDbContext con) {
            db = con;
            }

        public IActionResult Index() {
            return View();
            }

        public IActionResult ListaArtikliUposlenik() {
            ArtikalPrikaziSveVM artikli = new ArtikalPrikaziSveVM {
                artikli = db.Artikal.Select(x => new ArtikalPrikazVM {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Popust = x.Popust,
                    Sifra = x.Sifra,
                    Opis = x.Opis,
                    Slika = x.Slika.ToArray(),
                    Podkategorija = new PodkategorijaPrikazVM {
                        ID = x.PodkategorijaID,
                        Naziv = db.Podkategorija.Where(a => a.ID == x.PodkategorijaID).FirstOrDefault().Naziv,
                        Kategorija_ = new SelectListItem {
                            Value = x.KategorijaID.ToString(),
                            Text=db.Kategorija.Where(k=>k.ID==x.KategorijaID).FirstOrDefault().Naziv
                            }
                        }
                    }).OrderByDescending(x => x.ID).ToList()
                };

            return PartialView("ListaArtikliUposlenik", artikli);
            }

        public IActionResult ListaArtikli() {
            ArtikalPrikaziSveVM artikli = new ArtikalPrikaziSveVM {
                artikli = db.Artikal.Select(x => new ArtikalPrikazVM {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Popust = x.Popust,
                    Sifra = x.Sifra,
                    Opis = x.Opis,
                    Slika = x.Slika.ToArray(),
                    Podkategorija = new PodkategorijaPrikazVM {
                        ID = x.PodkategorijaID,
                        Naziv = db.Podkategorija.Where(a => a.ID == x.PodkategorijaID).FirstOrDefault().Naziv,
                        Kategorija_ = new SelectListItem {
                            Value = x.KategorijaID.ToString(),
                            Text=db.Kategorija.Where(k=>k.ID==x.KategorijaID).FirstOrDefault().Naziv
                            }
                        }
                    }).OrderByDescending(x => x.ID).ToList()
                };

            return PartialView("ListaArtikli", artikli);
            }


        [HttpGet]
        public IActionResult Dodaj() {
            ArtikalDodajVM a = new ArtikalDodajVM();

            ViewBag.Podkategorije = db.Podkategorija.Select(p => new PodkategorijaPrikazVM {
                ID = p.ID,
                Naziv = p.Naziv,
                Kategorija_ = new SelectListItem {
                    Value = p.KategorijaID.ToString()
                    }
                }).ToList();

            return PartialView("Dodaj", a);
            }

        [HttpPost]
        public IActionResult Dodaj(ArtikalDodajVM artikal, IFormFile Slika) {


            Artikal a = new Artikal {
                Naziv = artikal.Naziv,
                Cijena = artikal.Cijena,
                Popust = artikal.Popust,
                Opis = artikal.Opis,
                PodkategorijaID = artikal.Podkategorija.ID,
                KategorijaID = db.Podkategorija.Where(x=>x.ID==artikal.Podkategorija.ID).FirstOrDefault().KategorijaID
                };

            if ( Slika != null && Slika.Length > 0 ) {
                using ( MemoryStream stream = new MemoryStream() ) {
                    Slika.CopyToAsync(stream);
                    a.Slika = stream.ToArray();
                    }
                }
            else {

                a.Slika = new byte[1];
                }

            int brojArtikala = db.Artikal.Count();
            if ( brojArtikala == 0 ) {
                a.Sifra = "10001";
                }
            else {
                Artikal zadnji = db.Artikal.ToList().Last();
                int sifra = int.Parse(zadnji.Sifra);
                a.Sifra = (sifra + 1).ToString();
                }

            db.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
            }


        public IActionResult Obrisi(int ID) {

            Artikal a = db.Artikal.Find(ID);

            db.Remove(a);
            db.SaveChanges();

            return RedirectToAction("Index");
            }


        [HttpGet]
        public IActionResult Uredi(int id) {

            Artikal a = db.Artikal.Find(id);

            ViewBag.Podkategorije = db.Podkategorija.Select(p => new PodkategorijaPrikazVM {
                ID = p.ID,
                Naziv = p.Naziv,
                Kategorija_ = new SelectListItem {
                    Value = p.KategorijaID.ToString()
                    }
                }).ToList();

            ArtikalPrikazVM ap = new ArtikalPrikazVM {
                ID = a.ID,
                Sifra = a.Sifra,
                Naziv = a.Naziv,
                Opis = a.Opis,
                Cijena = a.Cijena,
                Popust = a.Popust,
                Slika = a.Slika.ToArray(),
                Podkategorija = new PodkategorijaPrikazVM {
                    ID = a.PodkategorijaID,
                    Naziv = db.Podkategorija.Where(x => x.ID == a.PodkategorijaID).FirstOrDefault().Naziv,
                    Kategorija_ = new SelectListItem {
                        Value = a.KategorijaID.ToString()
                        }
                    }
                };

            return PartialView("Uredi", ap);
            }

        [HttpPost]
        public IActionResult Uredi(ArtikalPrikazVM artikal, IFormFile Slika) {


            Artikal a = db.Artikal.Find(artikal.ID);

            a.Naziv = artikal.Naziv;
            a.Cijena = artikal.Cijena;
            a.Popust = artikal.Popust;
            a.Opis = artikal.Opis;
            a.PodkategorijaID = artikal.Podkategorija.ID;
            a.KategorijaID = db.Podkategorija.Where(x=>x.ID==a.PodkategorijaID).FirstOrDefault().KategorijaID;


            if ( Slika != null && Slika.Length > 0 ) {
                using ( MemoryStream stream = new MemoryStream() ) {
                    Slika.CopyToAsync(stream);
                    a.Slika = stream.ToArray();
                    }
                }
            else {
                a.Slika = new byte[1];
                }

            db.SaveChanges();

            return RedirectToAction("Index");
            }

        public IActionResult Detalji(int id) {
            Artikal a = db.Artikal.Find(id);
            ArtikalPrikazVM vm = new ArtikalPrikazVM {
                ID = a.ID,
                Sifra = a.Sifra,
                Naziv = a.Naziv,
                Opis = a.Opis,
                Cijena = a.Cijena,
                Popust = a.Popust,
                Slika = a.Slika.ToArray(),
                Podkategorija = new PodkategorijaPrikazVM {
                    ID = a.PodkategorijaID,
                    Naziv = db.Podkategorija.Where(x => x.ID == a.PodkategorijaID).FirstOrDefault().Naziv,
                    Kategorija_ = new SelectListItem {
                        Value = a.KategorijaID.ToString()
                        }
                    }
                };

            return View("Detalji", vm);
            }

        public IActionResult FilterPodkategorija(int id) {


            ArtikalPrikaziSveVM artikli = new ArtikalPrikaziSveVM {
                artikli = db.Artikal.Where(a => a.PodkategorijaID == id).Select(x => new ArtikalPrikazVM {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Popust = x.Popust,
                    Sifra = x.Sifra,
                    Opis = x.Opis,
                    Slika = x.Slika.ToArray(),
                    Podkategorija = new PodkategorijaPrikazVM {
                        ID = x.PodkategorijaID,
                        Naziv = db.Podkategorija.Where(a => a.ID == x.PodkategorijaID).FirstOrDefault().Naziv,
                        Kategorija_ = new SelectListItem {
                            Value = x.KategorijaID.ToString()
                            }
                        }
                    }).OrderByDescending(x => x.ID).ToList()
                };
            return PartialView("ListaArtikli", artikli);
            }

        public IActionResult FilterKategorija(int id) {

            ArtikalPrikaziSveVM artikli = new ArtikalPrikaziSveVM {
                artikli = db.Artikal.Where(a => a.KategorijaID == id).Select(x => new ArtikalPrikazVM {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Popust = x.Popust,
                    Sifra = x.Sifra,
                    Opis = x.Opis,
                    Slika = x.Slika.ToArray(),
                    Podkategorija = new PodkategorijaPrikazVM {
                        ID = x.PodkategorijaID,
                        Naziv = db.Podkategorija.Where(a => a.ID == x.PodkategorijaID).FirstOrDefault().Naziv,
                        Kategorija_ = new SelectListItem {
                            Value = x.KategorijaID.ToString()
                            }
                        }
                    }).OrderByDescending(x => x.ID).ToList()
                };
            return PartialView("ListaArtikli", artikli);
            }

        }
    }