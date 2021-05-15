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
    public partial class Adminpanel : Form
    {
        public Adminpanel()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Singleton.Instance.veri.pazarigoster();
            Singleton.Instance.veri.profilim();
            Singleton.Instance.home.Visible = true;
            
        }
        private void Adminpanel_Load(object sender, EventArgs e)
        {
            label3.Text = Singleton.Instance.uye.nick;
            Singleton.Instance.veri.adminhome();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            Singleton.Instance.uye.admincmbbox2 = comboBox2.SelectedIndex;
            if (Singleton.Instance.uye.admincmbbox2 == 1)
               button10.Visible = true; 
            else
               button10.Visible = false;
            Singleton.Instance.veri.adminhome();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            Singleton.Instance.uye.admincmbbox1 = Singleton.Instance.apanel.comboBox1.SelectedIndex;
            Singleton.Instance.veri.adminhome();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];
                Singleton.Instance.uye.onaylanacakuye = item.SubItems[3].Text;
                Singleton.Instance.uye.uyepsfbakiye = Convert.ToDecimal(item.SubItems[9].Text);
                Singleton.Instance.uye.uyeonaylibakiye = Convert.ToDecimal(item.SubItems[8].Text);
                 if (Singleton.Instance.uye.uyepsfbakiye == 0)
                {
                  MessageBox.Show("Seçtiğiniz üyenin onaylanacak bakiyesi yok...");
                }
                else
                {
                    Singleton.Instance.veri.bakiyeonayla();
                }
            }
            else if (listView2.SelectedItems.Count < 1)
            {
                MessageBox.Show("Onaylanacak üyeyi seçmediniz...");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];
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
            else if (listView2.SelectedItems.Count < 1)
            {
                MessageBox.Show("Düzenlenecek üyeyi seçmediniz...");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool adminkontrol;
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];
                adminkontrol = Convert.ToBoolean(item.SubItems[10].Text);
                if (adminkontrol == false)
                {
                    Singleton.Instance.veri.adminyap(item.SubItems[3].Text);
                }
                else
                {
                    MessageBox.Show("Seçtiğiniz üye zaten admin.");
                    listView2.Select();
                }    
            }
            else if (listView2.SelectedItems.Count < 1)
            {
                MessageBox.Show("Üye seçmediniz...");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem item = listView3.SelectedItems[0];
                Singleton.Instance.veri.urunonayla(item.SubItems[5].Text);
            }
            else if (listView3.SelectedItems.Count < 1)
            {
                MessageBox.Show("Ürün seçmediniz...");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem item = listView3.SelectedItems[0];
                Singleton.Instance.veri.urunsil(item.SubItems[5].Text);
            }
            else if (listView3.SelectedItems.Count < 1)
            {
                MessageBox.Show("Ürün seçmediniz...");
            }
        }
    }
}
