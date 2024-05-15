using KisiselWebSite.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.Anasayfas.ToList();
            return View(deger);
        }

        public ActionResult AnaSayfaGetir(int id)
        {
            var ag = c.Anasayfas.Find(id);
            return View("AnaSayfaGetir", ag);
        }
        public ActionResult AnaSayfaGüncelle(Anasayfa x)
        {
            var ag= c.Anasayfas.Find(x.id);
            ag.isim = x.isim;
            ag.profil = x.profil;
            ag.unvan = x.unvan;
            ag.aciklama = x.aciklama;
            ag.iletisim = x.iletisim;
            c.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult ikonlist()
        {
            var deger = c.ikonlars.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult yeniIkon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniIkon(ikonlar p)
        {
            var ikonlar= c.ikonlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("ikonlist");
        }

        public ActionResult ikongetir(int id)
        {
            var ig = c.ikonlars.Find(id);
            return View("ikongetir",ig);

        }

        public ActionResult ikonGuncelle(ikonlar x)
        {
            var ig = c.ikonlars.Find(x.id);
            ig.ikon = x.ikon;
            ig.link = x.link;
            c.SaveChanges();
            return RedirectToAction("ikonlist");

        }

        public ActionResult ikonSil(int id)
        {
            var sl = c.ikonlars.Find(id);
            c.ikonlars.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("ikonlist");
        }




    }
}