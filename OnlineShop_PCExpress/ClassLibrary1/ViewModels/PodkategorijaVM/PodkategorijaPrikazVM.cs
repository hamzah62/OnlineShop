using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.ViewModels {
    public class PodkategorijaPrikazVM {
        public int? ID{get;set;}
        public string Naziv{get;set;}
        public SelectListItem Kategorija_{get;set;}
        }
    }
