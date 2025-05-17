using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak
{
    public partial class AnaMenu : Form
    {
        private Timer timer;
        public AnaMenu()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Her 5 saniyede bir veriyi yeniden yükle
            LoadEvSayilari();
        }
        private void LoadEvSayilari()
        {
            using (emlakDBEntities context = new emlakDBEntities())
            {
                var kiralikevsayisi = context.evSayilaris
                    .Where(x => x.evTuru == "Kiralik")
                    .Select(x => x.evSayisi)
                    .FirstOrDefault();
                var satilikEvSayisi = context.evSayilaris
                    .Where(x => x.evTuru == "Satilik")
                    .Select(x => x.evSayisi)
                    .FirstOrDefault();

                label2.Text = satilikEvSayisi.ToString();
                label4.Text = kiralikevsayisi.ToString();

            }
        }
        private void button_Ev_Ekleme_Click(object sender, EventArgs e)
        {
            SingletonClassEvEkleme.MainMenuEvEkleme().Show();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            LoadEvSayilari();
        }

        private void AnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Kapatmak İstediğinize Emin Misiniz?", "Kapattığınız Taktirde Uygulamadan Çıkacaksınız!", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
            else
                return;
        }

        private void button_Ev_Sorgulama_Click(object sender, EventArgs e)
        {
            SingletonClassEvSorgulamaListeleme.SorgulamaEkraniAc().Show();
        }

        private void button_Satilan_kiralanan_evler_Click(object sender, EventArgs e)
        {
            SinglethonClassMusteriSorgu.SorgulamaEkraniAc().Show();
        }
    }
}
