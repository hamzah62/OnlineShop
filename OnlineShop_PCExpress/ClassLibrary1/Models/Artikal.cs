using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Models {
    public class Artikal {
        
        public int ID {get;set;}
        public string Sifra{get;set;}
        public string Naziv {get;set;}
        public string Opis{get;set;}
        public double Cijena{get;set;}
        public double Popust{get;set;}
        public byte[] Slika{get;set;}

        public int? PodkategorijaID { get; set; }
        public Podkategorija Podkategorija { get; set; }

        public int? KategorijaID{get;set;}
        public Kategorija Kategorija { get; set; }
        }
    }
