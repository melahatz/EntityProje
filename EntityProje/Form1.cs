using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//klasör tanımlasaydın burda çağırıcaktın 

namespace EntityProje
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities(); //sınıfımdan nesne ürettim burda tablolarımı çağırabilmem için
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler=db.Tbl_Kategori.ToList(); //değişken oluşturup katagoriler tablosundaki verileri listele dedim.
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //sütunlarına direk ulaşamıyorum önce o sınıftan nesne oluşturup onun üzerinden erişmem lazım.
            Tbl_Kategori t = new Tbl_Kategori();
            t.AD = textBox2.Text; //Ad isimli sütuna textbox2 den gelen değeri atadım.
            db.Tbl_Kategori.Add(t); //t den gelen değerleri ekle.
            db.SaveChanges(); //değişiklikleri kaydet ilgili sorguyu çalıştır
            MessageBox.Show("Kategori Eklendi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //kategoriid int olduğu için değişkenimi de int olarak tanımladım
            int x = Convert.ToInt32(textBox1.Text); //sileceğim id değerini textbox1 den girip silicem
            var ktgr = db.Tbl_Kategori.Find(x); //X i hafızaya al
            db.Tbl_Kategori.Remove(ktgr); //tablodaki ktgr den gelen değeri kaldır
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text); //güncellme işlemi id te göre olduğu için
            var ktgr=db.Tbl_Kategori.Find(x);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
        }

    }
}
