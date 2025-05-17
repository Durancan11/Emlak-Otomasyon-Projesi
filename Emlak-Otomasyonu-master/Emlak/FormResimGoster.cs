using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak
{
    public partial class FormResimGoster : Form
    {
        private List<byte[]> resimListesi;
        private int aktifIndex = 0;

        public FormResimGoster(List<byte[]> resimler)
        {
            InitializeComponent();
            this.resimListesi = resimler;
            ResmiGoster();
        }

        private void ResmiGoster()
        {
            if (resimListesi.Count > 0)
            {
                byte[] aktifResim = resimListesi[aktifIndex];
                using (MemoryStream ms = new MemoryStream(aktifResim))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
                pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;   
            }

            btnOnceki.Enabled = aktifIndex > 0;
            btnSonraki.Enabled = aktifIndex < resimListesi.Count - 1;
        }


        private void btnOnceki_Click_1(object sender, EventArgs e)
        {
            if (aktifIndex > 0)
            {
                aktifIndex--;
                ResmiGoster();
            }

        }

        private void btnSonraki_Click_1(object sender, EventArgs e)
        {
            if (aktifIndex < resimListesi.Count - 1)
            {
                aktifIndex++;
                ResmiGoster();
            }
        }
    }
}
