using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilliOkul.Entity;

namespace YesilliOkul.Data.Context
{
    public class YesilliOkulContext :DbContext
    {
        public YesilliOkulContext():base("YesilliOkulContext")
        {

        }
        // static arastırma neden?
        private static YesilliOkulContext _context;
        public static YesilliOkulContext ContextOlustur()
        {
            if (_context == null)
            {
                _context = new YesilliOkulContext();
            }
            return _context;
        }

        public virtual DbSet<Ogrenci> Ogrenciler { get; set; }
        public virtual DbSet<Egitmen> Egitmenler { get; set; }
        public virtual DbSet<Ders> Dersler { get; set; }
        public virtual DbSet<Sinif> Siniflar { get; set; }
        public virtual DbSet<Yoklama> Yoklamalar { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //   // plurisşadliasdliaş işlemleri için araştırma
        //    //modelBuilder.Conventions.Remove
        //}
    }
}
