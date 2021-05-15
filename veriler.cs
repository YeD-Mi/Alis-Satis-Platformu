using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace alissatis_proje
{
    public class veriler
    {
        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\alisveris.mdb");
        public void pazarigoster()
        {
            Singleton.Instance.home.listView1.Items.Clear();
            Singleton.Instance.home.listView3.Items.Clear();
            if (baglanti.State != ConnectionState.Open) { baglanti.Open(); }
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from urunler where urun_miktar>0";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["urun_adi"].ToString();
                ekle.SubItems.Add(oku["urun_kategori"].ToString());
                ekle.SubItems.Add(oku["urun_miktar"].ToString());
                ekle.SubItems.Add(oku["urun_fiyat"].ToString());
                ekle.SubItems.Add(oku["urun_satici"].ToString());
                ekle.SubItems.Add(oku["urun_barkod"].ToString());
                if (oku["urun_onay"].ToString() == true.ToString() && oku["urun_satici"].ToString() != Singleton.Instance.uye.nick.ToString())
                {
                    Singleton.Instance.home.listView1.Items.Add(ekle);
                }
                else if (oku["urun_onay"].ToString() == true.ToString() && oku["urun_satici"].ToString() == Singleton.Instance.uye.nick.ToString())
                {
                    if (Singleton.Instance.uye.cmbbox == 0)
                    Singleton.Instance.home.listView3.Items.Add(ekle);
                }
                else if (oku["urun_onay"].ToString() == false.ToString() && oku["urun_satici"].ToString() == Singleton.Instance.uye.nick.ToString())
                {
                    if (Singleton.Instance.uye.cmbbox == 1)
                    Singleton.Instance.home.listView3.Items.Add(ekle);
                } 
            }
            baglanti.Close();
        }
        public void profilim()
        {
            Singleton.Instance.home.listView2.Items.Clear();
            if (baglanti.State != ConnectionState.Open) { baglanti.Open(); }
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from uyelik where uye_nick='"+ Singleton.Instance.uye.nick + "'";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["uye_tc"].ToString();
                ekle.SubItems.Add(oku["uye_ad"].ToString());
                ekle.SubItems.Add(oku["uye_soyad"].ToString());
                ekle.SubItems.Add(oku["uye_nick"].ToString());
                ekle.SubItems.Add(oku["uye_sifre"].ToString());
                ekle.SubItems.Add(oku["uye_tel"].ToString());
                ekle.SubItems.Add(oku["uye_mail"].ToString());
                ekle.SubItems.Add(oku["uye_adres"].ToString());
                Singleton.Instance.home.listView2.Items.Add(ekle);
                Singleton.Instance.home.label3.Text = Singleton.Instance.uye.nick;
                Singleton.Instance.home.label4.Text = oku["uye_bakiye"].ToString();
                Singleton.Instance.uye.onaylibakiye = Convert.ToDecimal(Singleton.Instance.home.label4.Text);
                if (oku["psf_bakiye"].ToString()=="")
                {
                    Singleton.Instance.home.label15.Visible = false;
                    Singleton.Instance.home.label16.Visible = false;
                }
                else
                {
                    Singleton.Instance.home.label15.Text= oku["psf_bakiye"].ToString();
                    Singleton.Instance.uye.psfbakiye = Convert.ToDecimal(Singleton.Instance.home.label15.Text);
                }
            }
            baglanti.Close();
        }
        public void uyeguncelle()
        {
            string tc = Singleton.Instance.uyeedit.textBox1.Text;
            string ad = Singleton.Instance.uyeedit.textBox2.Text;
            string soyad = Singleton.Instance.uyeedit.textBox3.Text;
            string telefon = Singleton.Instance.uyeedit.textBox4.Text;
            string kad = Singleton.Instance.uyeedit.textBox5.Text;
            string sifre = Singleton.Instance.uyeedit.textBox6.Text;
            string mail = Singleton.Instance.uyeedit.textBox7.Text;
            string adres = Singleton.Instance.uyeedit.textBox8.Text;
            if (tc == "")
             {
                 MessageBox.Show("Tc alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox1.Select();
             }
             else if (ad == "")
             {
                 MessageBox.Show("Ad alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox2.Select();
             }
             else if (soyad == "")
             {
                 MessageBox.Show("Soyad alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox3.Select();
             }
             else if (telefon == "")
             {
                 MessageBox.Show("Telefon alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox4.Select();
             }
             else if (kad == "")
             {
                 MessageBox.Show("Kullanıcı adı alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox5.Select();
             }
             else if (sifre == "")
             {
                 MessageBox.Show("Şifre alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox6.Select();
             }
             else if (mail == "")
             {
                 MessageBox.Show("Mail alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox7.Select();
             }
             else if (adres == "")
             {
                 MessageBox.Show("Adres alanı boş olamaz...");
                Singleton.Instance.uyeedit.textBox8.Select();
             }
             else
             {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = "update uyelik set uye_tc='"+tc+"', uye_ad='"+ad+ "',uye_soyad='" + soyad + "',uye_tel='" + telefon + "',uye_nick='" + kad + "',uye_sifre='" + sifre + "',uye_mail='" + mail + "',uye_adres='" + adres + "' where uye_nick='" + kad + "' ";
                komut.ExecuteNonQuery();
                baglanti.Close();
                Singleton.Instance.uyeedit.Close();
               }
            Singleton.Instance.home.listView2.Items.Clear();
            Singleton.Instance.apanel.listView2.Items.Clear();
            adminhome();
            profilim();
        }
        public void urunekle()
        {
            string yeniad = Singleton.Instance.home.urunad_txt.Text;
            string yenikat = Singleton.Instance.home.urunkategori_txt.Text;
            int yenimiktar = Convert.ToInt32(Singleton.Instance.home.urunmiktar_txt.Text);
            decimal yenifiyat = Convert.ToDecimal(Singleton.Instance.home.urunfiyat_txt.Text);
            string yenibarkod = Singleton.Instance.home.urunbarkod_txt.Text;
            baglanti.Open();
            string uye = Singleton.Instance.uye.nick;
            OleDbCommand komut = new OleDbCommand("insert into urunler (urun_satici,urun_adi,urun_kategori,urun_miktar,urun_fiyat,urun_barkod) values ('" + uye + "','" + yeniad + "','" + yenikat + "','" +yenimiktar+ "','" + yenifiyat + "','"+yenibarkod+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürününüz eklenmiştir. Onay sonrası görüntüleyebilirsiniz...");
        }
        public void urunguncelle()
        {
            string urunadi = Singleton.Instance.urunedit.textBox1.Text;
            string kategori = Singleton.Instance.urunedit.textBox2.Text;
            int miktar = Convert.ToInt32(Singleton.Instance.urunedit.textBox5.Text);
            decimal fiyat = Convert.ToDecimal(Singleton.Instance.urunedit.textBox6.Text);
            string barkod= Singleton.Instance.urunedit.textBox3.Text;
            if (urunadi == "")
            {
                MessageBox.Show("Ürün adı alanı boş olamaz...");
                Singleton.Instance.urunedit.textBox1.Select();
            }
            else if (kategori == "")
            {
                MessageBox.Show("Kategori alanı boş olamaz...");
                Singleton.Instance.urunedit.textBox2.Select();
            }
            else if (miktar < 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz...");
                Singleton.Instance.urunedit.textBox5.Select();
            }
            else if (fiyat < 0)
            {
                MessageBox.Show("Fiyatı kontrol ediniz...");
                Singleton.Instance.urunedit.textBox6.Select();
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = "update urunler set urun_adi='" + urunadi + "', urun_kategori='" + kategori + "',urun_miktar='" + miktar + "',urun_fiyat='" + fiyat + "', urun_onay='"+"0"+"' where urun_barkod='" + barkod + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                Singleton.Instance.urunedit.Close();
            }
            adminhome();
            pazarigoster();
            
        }
        public void bakiyeyukle()
        {
            if (Singleton.Instance.cuzdan.textBox1.Text == "")
            {
                MessageBox.Show("Tutar girmediniz!");
                Singleton.Instance.cuzdan.textBox1.Select();
            }
            else
            {
                decimal tutar = Convert.ToDecimal(Singleton.Instance.cuzdan.textBox1.Text);
                if (tutar <= 0)
                {
                    MessageBox.Show("Yüklemek istediğiniz tutarı kontrol edin.");
                    Singleton.Instance.cuzdan.textBox1.Select();
                }
                else
                {
                    MessageBox.Show("Yatırma emriniz alınmıştır. Onay işleminden sonra cüzdanınızda görebilirsiniz.");
                    string uye = Singleton.Instance.uye.nick;
                    decimal yenibakiye;
                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand();
                    komut.Connection = baglanti;
                    yenibakiye = tutar + Singleton.Instance.uye.psfbakiye;
                    komut.CommandText = "update uyelik set psf_bakiye='" + yenibakiye + "' where uye_nick='" + uye + "' ";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Singleton.Instance.home.label15.Text = yenibakiye.ToString();
                    Singleton.Instance.home.label15.Visible = true;
                    Singleton.Instance.home.label16.Visible = true;
                    Singleton.Instance.uye.psfbakiye = yenibakiye;
                    Singleton.Instance.cuzdan.Hide();
                }
            }   
        }
        public void bakiyecek()
        {
            if (Singleton.Instance.cuzdan.textBox2.Text == "")
            {
                MessageBox.Show("Banka adı girmediniz!");
                Singleton.Instance.cuzdan.textBox2.Select();
            }
            else if (Singleton.Instance.cuzdan.textBox3.Text == "")
            {
                MessageBox.Show("Ad soyad girmediniz!");
                Singleton.Instance.cuzdan.textBox3.Select();
            }
            else if (Singleton.Instance.cuzdan.textBox4.Text == "")
            {
                MessageBox.Show("IBAN girmediniz!");
                Singleton.Instance.cuzdan.textBox4.Select();
            }
            else if (Singleton.Instance.cuzdan.textBox5.Text == "")
            {
                MessageBox.Show("Tutar girmediniz!");
                Singleton.Instance.cuzdan.textBox5.Select();
            }
            else if (Convert.ToDecimal(Singleton.Instance.cuzdan.textBox5.Text)>Convert.ToDecimal(Singleton.Instance.home.label4.Text))
            {
                MessageBox.Show("İşlem için bakiyeniz yetersiz!");
                Singleton.Instance.cuzdan.textBox5.Select();
            }
            else
            {
                MessageBox.Show("Çekim talebiniz alınmıştır. 2 iş gününde ücret hesabınızda olacaktır.");
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string uye = Singleton.Instance.uye.nick;
                decimal yenibakiye = Convert.ToDecimal(Singleton.Instance.home.label4.Text) - Convert.ToDecimal(Singleton.Instance.cuzdan.textBox5.Text);
                komut.CommandText = "update uyelik set uye_bakiye='" + yenibakiye + "' where uye_nick='" + uye + "' ";
                komut.ExecuteNonQuery();
                baglanti.Close();
                Singleton.Instance.home.label4.Text = yenibakiye.ToString();
                Singleton.Instance.cuzdan.Hide();

            }
        }
        public void satinal(string barkod)
        {
            if (Singleton.Instance.home.textBox1.Text == "")
            {
                MessageBox.Show("Alım miktarı girmediniz.");
                Singleton.Instance.home.textBox1.Select();
            }
            else
            {
                int almiktar = Convert.ToInt32(Singleton.Instance.home.textBox1.Text);
                if (almiktar < 1)
                {
                    MessageBox.Show("Geçerli bir miktar giriniz...");
                    Singleton.Instance.home.textBox1.Select();
                }
                else
                {
                    if (baglanti.State != ConnectionState.Open) { baglanti.Open(); }
                    int satmiktar, yenimiktar;
                    decimal fiyatim, yenibakiye;
                    decimal cuzdan = Convert.ToDecimal(Singleton.Instance.uye.onaylibakiye);
                    OleDbCommand komutum = new OleDbCommand();
                    komutum.Connection = baglanti;
                    komutum.CommandText = "Select * from urunler where urun_barkod='"+barkod+"'";
                    OleDbDataReader getir = komutum.ExecuteReader();
                    while (getir.Read())
                    {
                        satmiktar = Convert.ToInt32(getir["urun_miktar"]);
                        fiyatim = Convert.ToDecimal(getir["urun_fiyat"]);
                        Singleton.Instance.uye.satici = getir["urun_satici"].ToString();
                        if (almiktar > satmiktar)
                        {
                            MessageBox.Show("Satılandan Fazla Alamazsınız.");
                            Singleton.Instance.home.textBox1.Select();
                        }
                        else if (cuzdan < (almiktar * fiyatim))
                        {
                            MessageBox.Show("Bütçeniz yetersiz. Bakiye işlemlerinden yükleme yapabilirsiniz.");
                        }
                        else
                        {
                            MessageBox.Show("Satın alma işlemi başarı ile gerçekleşmiştir.");
                            yenimiktar = satmiktar-almiktar;
                            Singleton.Instance.uye.siparisfiyat = almiktar * fiyatim;
                            yenibakiye = cuzdan - Singleton.Instance.uye.siparisfiyat;
                            OleDbCommand komut = new OleDbCommand();
                            komut.Connection = baglanti;
                            komut.CommandText = "update urunler set urun_miktar='" + yenimiktar + "' where urun_barkod='" + barkod + "'";
                            komut.ExecuteNonQuery();
                            OleDbCommand komut1 = new OleDbCommand();
                            komut1.Connection = baglanti;
                            komut1.CommandText = "update uyelik set uye_bakiye='" + yenibakiye + "' where uye_nick='" + Singleton.Instance.uye.nick + "'";
                            komut1.ExecuteNonQuery();
                            Singleton.Instance.home.label4.Text = yenibakiye.ToString();
                        }
                    }
                    Singleton.Instance.home.textBox1.Text = "";
                    saticiislem();
                    Singleton.Instance.home.listView1.Items.Clear();
                    pazarigoster();
                    if (baglanti.State != ConnectionState.Open) { baglanti.Close(); }
                }
            }
        }
        public void saticiislem()
        {
            if (baglanti.State != ConnectionState.Open) { baglanti.Open(); }
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = baglanti;
            komut2.CommandText = "Select * from uyelik where uye_nick='" + Singleton.Instance.uye.satici + "'";
            OleDbDataReader getir1 = komut2.ExecuteReader();
            while (getir1.Read())
            {
                Singleton.Instance.uye.saticibakiye = Convert.ToDecimal(getir1["uye_bakiye"]);
                Singleton.Instance.uye.saticibakiye = Singleton.Instance.uye.saticibakiye + Singleton.Instance.uye.siparisfiyat;
                OleDbCommand komut3 = new OleDbCommand();
                komut3.Connection = baglanti;
                komut3.CommandText = "update uyelik set uye_bakiye='" + Singleton.Instance.uye.saticibakiye + "' where uye_nick='" + Singleton.Instance.uye.satici + "'";
                komut3.ExecuteNonQuery();
            }
            baglanti.Close();
        }
        public void adminhome()
        {
            Singleton.Instance.apanel.listView3.Items.Clear();
            Singleton.Instance.apanel.listView2.Items.Clear();
            if (baglanti.State != ConnectionState.Open) { baglanti.Open(); }
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from urunler";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["urun_adi"].ToString();
                ekle.SubItems.Add(oku["urun_kategori"].ToString());
                ekle.SubItems.Add(oku["urun_miktar"].ToString());
                ekle.SubItems.Add(oku["urun_fiyat"].ToString());
                ekle.SubItems.Add(oku["urun_satici"].ToString());
                ekle.SubItems.Add(oku["urun_barkod"].ToString());
                ekle.SubItems.Add(oku["urun_onay"].ToString());
                if (oku["urun_onay"].ToString() == false.ToString())
                {
                    if (Singleton.Instance.uye.admincmbbox2 == 1)
                        Singleton.Instance.apanel.listView3.Items.Add(ekle);
                }
                else if (oku["urun_onay"].ToString() == true.ToString())
                {
                    if (Singleton.Instance.uye.admincmbbox2 == 0)
                        Singleton.Instance.apanel.listView3.Items.Add(ekle);
                }
            }
            OleDbCommand komut1 = new OleDbCommand();
            komut1.Connection = baglanti;
            komut1.CommandText = "Select * from uyelik";
            OleDbDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku1["uye_tc"].ToString();
                ekle1.SubItems.Add(oku1["uye_ad"].ToString());
                ekle1.SubItems.Add(oku1["uye_soyad"].ToString());
                ekle1.SubItems.Add(oku1["uye_nick"].ToString());
                ekle1.SubItems.Add(oku1["uye_sifre"].ToString());
                ekle1.SubItems.Add(oku1["uye_tel"].ToString());
                ekle1.SubItems.Add(oku1["uye_mail"].ToString());
                ekle1.SubItems.Add(oku1["uye_adres"].ToString());
                ekle1.SubItems.Add(oku1["uye_bakiye"].ToString());
                ekle1.SubItems.Add(oku1["psf_bakiye"].ToString());
                ekle1.SubItems.Add(oku1["uye_admin"].ToString());
                Singleton.Instance.uye.uyepsfbakiye = Convert.ToDecimal(oku1["psf_bakiye"]);
                Singleton.Instance.uye.uyeonaylibakiye= Convert.ToDecimal(oku1["uye_bakiye"]);
                if (Singleton.Instance.uye.admincmbbox1 == 0)
                {
                    Singleton.Instance.apanel.listView2.Items.Add(ekle1);
                }
                if (Singleton.Instance.uye.admincmbbox1 == 1 && Singleton.Instance.uye.uyepsfbakiye>0)
                {
                    Singleton.Instance.apanel.listView2.Items.Add(ekle1);
                }
                
            }
            baglanti.Close();
        }
        public void bakiyeonayla()
        {
            Singleton.Instance.uye.uyeonaylibakiye += Singleton.Instance.uye.uyepsfbakiye;
            Singleton.Instance.uye.uyepsfbakiye = 0;    
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "update uyelik set uye_bakiye='" + Singleton.Instance.uye.uyeonaylibakiye + "', psf_bakiye='" + Singleton.Instance.uye.uyepsfbakiye + "' where uye_nick='" + Singleton.Instance.uye.onaylanacakuye + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bakiye onaylama işlemi yapıldı.", "Başarılı");
            adminhome();
        }
        public void urunonayla(string barkod)
        {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = "update urunler set urun_onay='"+"1"+ "' where urun_barkod='" + barkod + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün onaylanarak satışa hazır hale getirildi");
                adminhome();
                pazarigoster();
        }
        public void urunsil(string barkod)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from urunler where urun_barkod='" + barkod + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün silme işlemi başarılı.");
            adminhome();
            pazarigoster();
        }
        public void adminyap(string yeniadmin)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "update uyelik set uye_admin='" + "1" + "' where uye_nick='" + yeniadmin + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Admin olarak atandı", yeniadmin);
            adminhome();
            profilim();
    }
        public void yeniuye(TextBox ad, TextBox soyad, TextBox tc, TextBox tel, TextBox nick,TextBox sifre,TextBox mail, TextBox adres)
        {
            if (baglanti.State != ConnectionState.Open) { baglanti.Open(); }
            OleDbCommand komut = new OleDbCommand("insert into uyelik (uye_ad,uye_soyad,uye_tc,uye_tel,uye_nick,uye_sifre,uye_mail,uye_adres) values ('" + ad.Text.ToString() + "','" + soyad.Text.ToString() + "','" + tc.Text.ToString() + "','" + tel.Text.ToString() + "','" + nick.Text.ToString() + "','" + sifre.Text.ToString() + "','" + mail.Text.ToString() + "','" + adres.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üyelik işlemi tamamlandı. Giriş yapabilirsin.");
            Singleton.Instance.uyekayit.Close();
        }
    }
}
