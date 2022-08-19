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
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db= new DbEntityUrunEntities();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.Tbl_Admin where x.Kullanici==TxtKullaniciAd.Text && x.Sifre==TxtSifre.Text select x;
            if (sorgu.Any()) //sorgu bişey geri döndürüyorsa
            {
                FrmAnaForm frm=new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
            }
        }
    }
}
