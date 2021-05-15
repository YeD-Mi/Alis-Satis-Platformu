using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace alissatis_proje
{
   public sealed class Singleton
    {
      private Singleton()
        {

        }
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public veriler veri = new veriler();
        public uyeler uye = new uyeler();
        public kayit uyekayit = new kayit();
        public anasayfa home = new anasayfa();
        public Adminpanel apanel = new Adminpanel();
        public girisform girispage = new girisform();
        public uyelikedit uyeedit = new uyelikedit();
        public urunedit urunedit = new urunedit();
        public bakiyeyukle cuzdan = new bakiyeyukle();
    }
}
