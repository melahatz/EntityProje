using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProje
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db=new DbEntityUrunEntities(); //SINIFIMDAN NESNE TÜRETTİM

        public void temizle()
        {
            Txtid.Text = " ";
            TxtAd.Text = " ";
            TxtMarka.Text = " ";
            TxtStok.Text = " ";
            TxtFiyat.Text = " ";
            TxtDurum.Text = " ";
            CmbKategori.Text = " ";

        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();


        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.Urunid,
                                            x.UrunAd,
                                            x.UrunMarka,
                                            x.Stok,
                                            x.Fiyat,
                                            x.Durum,
                                            x.Tbl_Kategori.AD //kategori no su geliyordu bağlı olduğu tabloya ulaşıp ismini aldık
                                        }).ToList();

            
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun(); //urun sınıfımdan t isminde nesne türettim
            t.UrunAd = TxtAd.Text;
            t.UrunMarka = TxtMarka.Text;
            t.Stok = short.Parse(TxtStok.Text);
            t.Kategori=int.Parse(CmbKategori.SelectedValue.ToString());
            t.Fiyat = decimal.Parse(TxtFiyat.Text);
            t.Durum = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text); //id yi aldım
            var urun = db.Tbl_Urun.Find(x); //x den gönderdiğim değeri bul
            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Kaldırıldı");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text); //id yi aldım
            var urun = db.Tbl_Urun.Find(x); //x den gönderdiğim değeri bul
            urun.UrunAd=TxtAd.Text;
            urun.Stok = short.Parse(TxtStok.Text);
            urun.UrunMarka = TxtMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        //combobaxa veri çekme lınq sorguları ile oluyuor
        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategori
                               select new
                               { 
                                   x.ID, x.AD 
                               }
                               ).ToList();

            CmbKategori.ValueMember = "ID"; //ARKA planda çalışıcak DEĞER
            CmbKategori.DisplayMember = "AD"; //ÖN TARAFTA GÖZÜKÜCEK OLAN
            CmbKategori.DataSource= kategoriler; //veri kaynağı kategorşlerden gelen değer olucak

            
        }
    }

}
