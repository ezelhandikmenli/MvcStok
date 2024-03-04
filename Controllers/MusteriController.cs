using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entitiy;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult MusteriListele()
        {
            var degerler = db.TBLMUSTERI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI m)
        {
            db.TBLMUSTERI.Add(m);
            db.SaveChanges();
            return RedirectToAction("MusteriListele");
        }
        public ActionResult Sil(int id)
        {
            var value = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(value);
            db.SaveChanges();
            return RedirectToAction("MusteriListele");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(TBLMUSTERI p1)
        {
            var musteri = db.TBLMUSTERI.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("MusteriListele");
        }
    }
}