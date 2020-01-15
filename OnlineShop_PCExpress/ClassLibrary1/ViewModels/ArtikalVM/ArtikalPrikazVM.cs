using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ClassLibrary1.ViewModels {
    public class ArtikalPrikazVM {
        public int ID{get;set;}
        public string Sifra{get;set;}
        public string Naziv {get;set;}
        public string Opis{get;set;}
        public double Cijena{get;set;}
        public double Popust{get;set;}
        public byte[] Slika{get;set;}
        
        public PodkategorijaPrikazVM Podkategorija{get;set;}
        }
    }
