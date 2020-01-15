using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models {
    public class Podkategorija {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public int? KategorijaID{get;set; }
        public Kategorija Kategorija{get;set;}
        }
    }
