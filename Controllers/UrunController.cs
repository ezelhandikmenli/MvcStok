using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entitiy;
namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities(); 
        public ActionResult UrunList()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }

        public dynamic GetViewBag()
        {
            return ViewBag;
        }

        [HttpGet]
        public ActionResult UrunEkle() 
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text =i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
           
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER u)
        {
            var ktg = db.TBLKATEGORI.Where(m => m.KATEGORIID == u.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            u.TBLKATEGORI = ktg;
            db.TBLURUNLER.Add(u);
            db.SaveChanges();
            return RedirectToAction("UrunList");
        }
        public ActionResult Sil(int id)
        {
            var deger = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("UrunList");
        }
    }
}