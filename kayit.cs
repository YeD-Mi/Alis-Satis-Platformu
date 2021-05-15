using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alissatis_proje
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        private void btnuyelik_Click(object sender, EventArgs e)
        {
            Singleton.Instance.veri.yeniuye(newad_txt, newsoyad_txt, newtc_txt,newtel_txt,newnick_txt,newsifre_txt,newmail_txt,newadres_txt);
        }
    }
}
