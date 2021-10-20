using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilliOkul.Business;
using YesilliOkul.Entity;

namespace YesilliOkul.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OgrenciBusiness busiOgrenci;
        SinifBusiness busiSinif;
        DersBusiness busiDers;

        private void Form1_Load(object sender, EventArgs e)
        {
            busiOgrenci = new OgrenciBusiness();
            busiSinif = new SinifBusiness();
            busiDers = new DersBusiness();

            dataGridView1.DataSource = busiOgrenci.HepsiniGetir();

            foreach (Sinif item in busiSinif.HepsiniGetir())
            {
                cmbSinifi.Items.Add(item);
            }

            foreach (Ders item in busiDers.HepsiniGetir())
            {
                clbDersleri.Items.Add(item);
            }

            //2milyar170mil = 2.000.000.000
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenci o = new Ogrenci();
            o.TC = Convert.ToInt64(txtTC.Text.Trim());
            o.Ad = txtAdi.Text.Trim();
            o.Soyad = txtSoyadi.Text.Trim();
            o.DogumTarihi = dtpDogumTarihi.Value;

            if (cmbSinifi.SelectedIndex > 0)
            {
                o.Sinifi = cmbSinifi.SelectedItem as Sinif; //Unboxing
                // o.Sinifi = (Sinif)cmbSinifi.SelectedItem  // Casting
            }

            foreach (Ders item in clbDersleri.CheckedItems)
            {
                o.Dersleri.Add(item);
            }

            busiOgrenci.Ekle(o);

            dataGridView1.DataSource = busiOgrenci.HepsiniGetir();
        }
    }
}
