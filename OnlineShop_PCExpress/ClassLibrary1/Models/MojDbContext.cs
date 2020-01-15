using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models {
    public class MojDbContext:DbContext {

        public MojDbContext(DbContextOptions<MojDbContext> o):base(o){}

        public DbSet<Artikal> Artikal{get;set;}
        public DbSet<Kategorija> Kategorija{get;set;}
        public DbSet<Podkategorija> Podkategorija{get;set;}
        } }
