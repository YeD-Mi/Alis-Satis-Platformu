using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace alissatis_proje
{
        public partial class girisform : Form
    {
        public girisform()
        {
            InitializeComponent();
        }
        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\alisveris.mdb");
        public void uyegirisi()
        {
            Singleton.Instance.uye.nick = nick_txt.Text;
            string sifre = sifre_txt.Text;
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from uyelik where uye_nick='" + Singleton.Instance.uye.nick + "' AND uye_sifre='" + sifre + "'";
            OleDbDataReader oku = komut.ExecuteReader();
            Singleton.Instance.girispage.Close();
            if (oku.Read())
            {
                this.Hide();
                if (oku["uye_admin"].ToString() == true.ToString())
                {
                    Singleton.Instance.home.button8.Visible = true;
                    Singleton.Instance.home.ShowDialog();
                }
                else
                {
                    Singleton.Instance.home.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }
            baglanti.Close();
        }
        private void btngiris_Click(object sender, EventArgs e)
        {
            uyegirisi();
        }
        private void btnkayit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.uyekayit.ShowDialog();
            this.ShowDialog();
        }
    }
}
