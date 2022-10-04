using MvcTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new []{"Buzdolabı",
            "Beyaz Eşya","Laptop"}, yValues: new[] {22,45,20}).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        Context c = new Context();

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width:900,height:800).AddTitle("Stoklar")
                .AddSeries(chartType:"Column",name:"Stok",xValue:xvalue,yValues:yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);

        }
        public List<sinif1> UrunListesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                UrunAd="Bilgisayar",
                StokSayisi=120
            });
            snf.Add(new sinif1()
            {
                UrunAd = "Beyaz Eşya",
                StokSayisi = 250
            });
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }


        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using(var c = new Context())
            {
                snf=c.Uruns.Select(x=>new sinif2
                {
                    UrnAd=x.UrunAd,
                    StkSayisi=x.Stok
                }).ToList();
            }
            return snf;
        }

        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult Index7()
        {
            return View();
        }
    }
}