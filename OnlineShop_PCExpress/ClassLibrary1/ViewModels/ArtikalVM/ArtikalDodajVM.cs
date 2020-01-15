using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.ViewModels {
    public class ArtikalDodajVM {
        public string Naziv {get;set;}
        public string Opis{get;set;}
        public double Cijena{get;set;}
        public double Popust{get;set;}
        public byte[] Slika{get;set;}

        public PodkategorijaPrikazVM Podkategorija {get;set;}
        }
      
    }
