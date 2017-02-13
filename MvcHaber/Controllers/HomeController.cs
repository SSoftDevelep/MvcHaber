using MvcHaber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHaber.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (MvcHaberDB database = new MvcHaberDB())
            {
                List<Haber> haberListesi;
                IndexModel model = new IndexModel();
                if (TempData["TempHaberListesi"]!=null)
                {
                    haberListesi = (List<Haber>)TempData["TempHaberListesi"];
                }
                else
                {
                    haberListesi = new List<Haber>();
                }
                model.Kategoriler = database.Kategori.ToList();
                model.Haberler = haberListesi;



                return View(model);
            }

        }

        public ActionResult HaberleriListele(string secilenKategori)
        {
            using (MvcHaberDB database = new MvcHaberDB())
            {
                var haberListesi = database.Haber.Include("Yorumlar").Where(hb => hb.Kategori.KategoriAdi == secilenKategori).ToList(); //Linq kullandik.
                TempData["TempHaberListesi"] = haberListesi;

                //List<Kategori> kategorim = database.Kategori.ToList();  //select * from Kategori
                //return View(kategorim);
            }

            return RedirectToAction("Index");
        }

        public ActionResult HaberDetay(int haberID)
        {
            using (MvcHaberDB database = new MvcHaberDB())
            {
                Haber model = database.Haber.Include("Yorumlar").Where(hbr => hbr.Id == haberID).FirstOrDefault();
                return View(model);
            }
                
        }

        public void DataDoldur()  //veritabanina baglanip tablolari olusturduk.
        {
            using (MvcHaberDB dataBase = new MvcHaberDB()) //database e erisme ani.
            {

                Kategori kategori1 = new Kategori();
                kategori1.KategoriAdi = "Spor";
                dataBase.Kategori.Add(kategori1);  //add() metoduyla tabloya kayit ekledik.

                Kategori kategori2 = new Kategori();
                kategori2.KategoriAdi = "Ekonomi";
                dataBase.Kategori.Add(kategori2);

                Kategori kategori3 = new Kategori();
                kategori3.KategoriAdi = "Magazin";
                dataBase.Kategori.Add(kategori3);

                Kategori kategori4 = new Kategori();
                kategori4.KategoriAdi = "Haber";
                dataBase.Kategori.Add(kategori4);

                Yorum yorum1 = new Yorum();
                yorum1.Icerik = "Dun aksamki mac cok guzeldi";
                yorum1.Tarih = DateTime.Today;

                dataBase.Yorum.Add(yorum1);

                Yorum yorum2 = new Yorum();
                yorum2.Icerik = "Paran var mi derdin var!";
                yorum2.Tarih = DateTime.Today;

                dataBase.Yorum.Add(yorum2);

                Yorum yorum3 = new Yorum();
                yorum3.Icerik = "Engin abi dun aksam koptu!!";
                yorum3.Tarih = DateTime.Today;
                dataBase.Yorum.Add(yorum3);

                Yorum yorum4 = new Yorum();
                yorum4.Icerik = "Bu galibiyetle sampiyon olduk!";
                yorum4.Tarih = DateTime.Today;
                dataBase.Yorum.Add(yorum4);

                Haber haber1 = new Haber();
                haber1.Baslik = "Yine yendik !";
                haber1.Detay = "Turkiye Almanya karsisinda yine mutlak zafere ulasti";
                haber1.Kategori = kategori1;
                haber1.Yorumlar = new List<Yorum>();
                haber1.Yorumlar.Add(yorum1);
                haber1.Yorumlar.Add(yorum4);
                dataBase.Haber.Add(haber1);


                Haber haber2 = new Haber();
                haber2.Baslik = "Aksam Eglencesi";
                haber2.Detay = "Unlu Mvp Engin Yine Döktürdü ";
                haber2.Kategori = kategori3;
                haber2.Yorumlar = new List<Yorum>();
                haber2.Yorumlar.Add(yorum3);
                dataBase.Haber.Add(haber2);


                Haber haber3 = new Haber();
                haber3.Baslik = "Parasi olan düşünsün";
                haber3.Detay = "Özel jet fiyatlari artti";
                haber3.Kategori = kategori2;
                haber3.Yorumlar = new List<Yorum>();
                haber3.Yorumlar.Add(yorum2);
                dataBase.Haber.Add(haber3);

                dataBase.SaveChanges();  // eklenen classlarin database e kaydolmasini sagladik. (depolanmasini)



            }   // parantezden cikinca database ramden memoryden temizlenir. (Garbage Collecter)
        }
    }
}


