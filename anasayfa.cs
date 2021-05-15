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
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }      
        private void anasayfa_Load(object sender, EventArgs e)
        {
            Singleton.Instance.veri.pazarigoster();
            Singleton.Instance.veri.profilim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string barkod;
                barkod = item.SubItems[5].Text;
                Singleton.Instance.veri.satinal(barkod);
            }
            else if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Ürün seçmediniz...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView2.Items[0];
            Singleton.Instance.uyeedit.textBox1.Text = item.SubItems[0].Text;
            Singleton.Instance.uyeedit.textBox2.Text = item.SubItems[1].Text;
            Singleton.Instance.uyeedit.textBox3.Text = item.SubItems[2].Text;
            Singleton.Instance.uyeedit.textBox4.Text = item.SubItems[5].Text;
            Singleton.Instance.uyeedit.textBox5.Text = item.SubItems[3].Text;
            Singleton.Instance.uyeedit.textBox6.Text = item.SubItems[4].Text;
            Singleton.Instance.uyeedit.textBox7.Text = item.SubItems[6].Text;
            Singleton.Instance.uyeedit.textBox8.Text = item.SubItems[7].Text;
            Singleton.Instance.uyeedit.ShowDialog();

        }
        private void button3_Click(object sender, EventArgs e)
        {
                if (listView3.SelectedItems.Count>0)
            {
                ListViewItem item = listView3.SelectedItems[0];
                Singleton.Instance.urunedit.textBox1.Text = item.SubItems[0].Text;
                Singleton.Instance.urunedit.textBox2.Text = item.SubItems[1].Text;
                Singleton.Instance.urunedit.textBox5.Text = item.SubItems[2].Text;
                Singleton.Instance.urunedit.textBox6.Text = item.SubItems[3].Text;
                Singleton.Instance.urunedit.textBox3.Text = item.SubItems[5].Text;
                Singleton.Instance.urunedit.ShowDialog();
            }
            else if(listView3.SelectedItems.Count<1)
                {
                MessageBox.Show("Düzenlenecek ürünü seçmediniz...");
                }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Singleton.Instance.veri.urunekle();
            urunad_txt.Text = "";
            urunkategori_txt.Text = "";
            urunmiktar_txt.Text = "";
            urunfiyat_txt.Text = "";
            urunbarkod_txt.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Singleton.Instance.cuzdan.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView3.Items.Clear();
            Singleton.Instance.uye.cmbbox = Singleton.Instance.home.comboBox1.SelectedIndex;
            Singleton.Instance.veri.pazarigoster();
        }

        private void button8_Click(object sender, EventArgs e)
        {            
            this.Visible = false;
            Singleton.Instance.veri.adminhome();
            Singleton.Instance.apanel.Visible = true;
        }
    }
}
