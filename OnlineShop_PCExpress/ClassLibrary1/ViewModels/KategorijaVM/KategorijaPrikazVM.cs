using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.ViewModels {
    public class KategorijaPrikazVM {
        public int ID{get;set;}
        public string Naziv{get;set;}

        public List<PodkategorijaPrikazVM> podkategorije{get;set;}
        }
    }
