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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db=new DbEntityUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            lblkatagorisayısı.Text=db.Tbl_Kategori.Count().ToString();  //KATEGORİLER TABLOSUNDAN SAY VE YAZ.
            lbltoplamürün.Text = db.Tbl_Urun.Count().ToString();
            lblaktifmusteri.Text=db.Tbl_Musteri.Count(x=>x.Durum==true).ToString();
            lblpasifmusteri.Text = db.Tbl_Musteri.Count(x => x.Durum == false).ToString();
            lbltoplamstok.Text = db.Tbl_Urun.Sum(y => y.Stok).ToString(); //urun tablosundaki toplam stoğu saymasını istedim
            lblkasadakitutar.Text = db.Tbl_Satıs.Sum(z => z.Fiyat).ToString() + " TL";
            lblenyüksekfiyaturn.Text = (from x in db.Tbl_Urun orderby x.Fiyat
                                       descending select x.UrunAd).FirstOrDefault(); //tblurun içersinde fiyata göre sıralama yap nasıl sıralama descending z den a ya
            lblendusukurn.Text=(from x in db.Tbl_Urun orderby x.Fiyat
                                ascending select x.UrunAd).FirstOrDefault(); 
            lblbeyazesya.Text=db.Tbl_Urun.Count(x=>x.Kategori==1).ToString();
            lbltoplambuzdolabısayı.Text=db.Tbl_Urun.Count(x=>x.UrunAd=="Buzdolabı").ToString();
            //from x in TblMuateri: musteri tablosu içerisinde bulucaksın.
            //dıstınct komutu tekrarsız olarak getşr.Seçtiğin şehri tekrarsız olarak getir.
            lblsehirsayısı.Text=(from x in db.Tbl_Musteri select x.MusteriSehir).Distinct().Count().ToString();
            lblenfazlaurunlumarka.Text = db.MarkaGetir().FirstOrDefault();
        }
    }
}
