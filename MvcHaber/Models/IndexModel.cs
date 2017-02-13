using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHaber.Models
{
    public class IndexModel
    {
        public List<Kategori> Kategoriler { get; set; }
        public List<Haber> Haberler { get; set; }
       
    }

}