namespace MvcHaber.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class MvcHaberDB : DbContext
    {
        // Your context has been configured to use a 'MvcHaberDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MvcHaber.Models.MvcHaberDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MvcHaberDB' 
        // connection string in the application configuration file.
        public MvcHaberDB()
            : base("name=MvcHaberDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }   //tablolarimizi olusturduk.
        public virtual DbSet<Yorum> Yorum { get; set; }
        public virtual DbSet<Haber> Haber { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}



        //buarada databasemizde oluscak tum classlari tanimladik. Henuz veritabanini tanimlamadik ama classlarimizdan tablolari olusturacagiz.
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
    }

    public class Yorum
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public Haber Haber { get; set; }

    }

    public class Haber
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public Kategori Kategori { get; set; }

        public ICollection<Yorum> Yorumlar { get; set; }

    }
}