using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Projedeneme1
{
    public class kisiselkayıtolgetset
    {
        public string key { get; set; }
        public string isim { get; set; }
        public string email { get; set; }
        public string sifre { get; set; }
        public string netgelir { get; set; }
        public string evgider { get; set; }
        public string mutfakgider { get; set; }
        public string alisverisgider { get; set; }
        public string kisiselgider { get; set; }
        public string borcgider { get; set; }
        public string digergider { get; set; }
        public string aracgider { get; set; }

        public List<kisiler> borclist; 
    }
    public class kisiler
    {
        public string isimK { get; set; }
        public string aciklama { get; set; }
        public string borcmiktar { get; set; }
        public string tarih { get; set; }
        public string tur { get; set; }
        public Color color { get; set; }
        
    }
}
