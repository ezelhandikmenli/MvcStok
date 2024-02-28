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
    }
}