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
    public partial class EvDuzenleme : Form
    {
        public string emlak_numarasi_form_aktarma { get; set; }

        public EvDuzenleme()
        {
            InitializeComponent();
        }

        public EvTur evtur;
        public enum EvTur
        {
            Bilinmiyor,
            Daire,
            Bahçeli,
            Dubleks,
            Müstakil,
            Havuzlu,
            Apart
        }

        private void EvDuzenleme_Load(object sender, EventArgs e)
        {
            groupBox_satilik_ev.Visible = true;
            groupBox_satilik_ev.Show();
            evtur = EvTur.Bilinmiyor;
            IlListYukleme();
            EvTurBelirleme();
            label_emlak_numarasi.Text = emlak_numarasi_form_aktarma;
            EvBilgileriIilkGirisYukleme(Convert.ToInt32(emlak_numarasi_form_aktarma));
            EvYasHesaplama();
        }
        private void EvTurBelirleme()
        {
            string[] evturleri = Enum.GetNames(typeof(EvTur));
            foreach (var item in evturleri)
            {
                comboBox_ev_turu.Items.Add(item);
            }
        }

        private void IlListYukleme()
        {
            try
            {
                using (emlakDBEntities context = new emlakDBEntities())
                {
                    var data = context.illers.Select(x => x.isim);
                    foreach (var item in data)
                    {
                        comboBox_il.Items.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void EvBilgileriIilkGirisYukleme(int emlak_numarasi_form_)
        {
            using (emlakDBEntities context = new emlakDBEntities())
            {
                var ev_bilgileri_kayitli = context.Evs.FirstOrDefault(x => x.emlakNumarasi == emlak_numarasi_form_);
                if (ev_bilgileri_kayitli == null)
                {
                    MessageBox.Show("Bu emlak numarasına ait kayıt bulunamadı.");
                    return;
                }

                comboBox_il.Text = ev_bilgileri_kayitli.il;
                comboBox_ilce.Text = ev_bilgileri_kayitli.ilce;
                textBox_adres.Text = ev_bilgileri_kayitli.semt;
                textBox_kat_numarasi.Text = ev_bilgileri_kayitli.katNumarasi.ToString();
                textBox_toplam_alan.Text = ev_bilgileri_kayitli.toplamEvAlani.ToString();
                textBox_oda_sayisi.Text = ev_bilgileri_kayitli.odaSayisi.ToString();
                comboBox_ev_turu.Text = ev_bilgileri_kayitli.evTuru;
                dateTimePicker_ev_yapim_tarihi.Value = ev_bilgileri_kayitli.yapimTarihi;

                string ev_durumu = ev_bilgileri_kayitli.evDurumu.Trim();
                if (ev_durumu == "aktif")
                    radioButton_aktif.Checked = true;
                else
                    radioButton_pasif.Checked = true;

                //Ev kiralik mi, kontrol, null dönerse satilik demek
                try
                {
                    var ev_kiralik_mi = context.KiralikEvs.Where(c => c.emlakNumarasi == emlak_numarasi_form_).First();
                    // Kiralik Ev İçin İşlemler
                    radioButton_kiralik_ev.Checked = true;
                    groupBox_satilik_ev.Hide();
                    groupBox_kiralik_ev.Show();

                    textBox_kiralikEv_kira.Text = ev_kiralik_mi.kira.ToString();
                    textBox_kiralikEv_depozito.Text = ev_kiralik_mi.depozito.ToString();
                }
                catch (Exception)
                {
                    var ev_satilik_mi = context.SatilikEvs.FirstOrDefault(c => c.emlakNumarasi == emlak_numarasi_form_);
                    if (ev_satilik_mi == null)
                    {
                        MessageBox.Show("Satılık ev bilgisi bulunamadı.");
                        return;
                    }


                    radioButton_satilik_ev.Checked = true;
                    groupBox_satilik_ev.Show();
                    groupBox_kiralik_ev.Hide();


                    textBox_satilikEv_fiyat.Text = ev_satilik_mi.fiyat.ToString();
                }
            }
        }

        private void button_ev_bilgileri_update_Click(object sender, EventArgs e)
        {
            groupBox_satilik_ev.Show();
            if (comboBox_il.Text == "")
            {
                MessageBox.Show("Lütfen İl Seçimi Yapınız.");
                return;
            }
            else if (comboBox_ilce.Text == "")
            {
                MessageBox.Show("Lütfen İlçe Seçimi Yapınız.");
                return;
            }
            else if (textBox_adres.Text == "")
            {
                MessageBox.Show("Lütfen Adres Bilgilerini Giriniz.");
                return;
            }
            else if (radioButton_aktif.Checked == false && radioButton_pasif.Checked == false)
            {
                MessageBox.Show("Lütfen Ev Durumunu Aktif veya Pasi Yapınız");
                return;
            }
            else if (textBox_kat_numarasi.Text == "")
            {
                MessageBox.Show("Kat Numarası Boş Olamaz.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox_toplam_alan.Text) || !int.TryParse(textBox_toplam_alan.Text, out int toplamAlan) || toplamAlan <= 0)
            {
                MessageBox.Show("Ev Toplam Alanı Boş, Sayı Dışı veya 0'dan Küçük Olamaz.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox_oda_sayisi.Text) || !int.TryParse(textBox_oda_sayisi.Text, out int odaSayisi) || odaSayisi <= 0)
            {
                MessageBox.Show("Ev Oda Sayısı Boş, Sayı Dışı veya 0'dan Küçük Olamaz.");
                return;
            }

            else if (comboBox_ev_turu.Text == "")
            {
                MessageBox.Show("Ev Türü Boş Olamaz.");
                return;
            }
            else if (textBox_ev_yasi.Text == "")
            {
                MessageBox.Show("Ev Yaşı Belirlemek İçin Yapım Tarihini Giriniz.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox_ev_yasi.Text) || !int.TryParse(textBox_ev_yasi.Text, out int evYasi) || evYasi <= 0)
            {
                MessageBox.Show("Ev Yaşı 0'dan Küçük veya Boş Olamaz. Yapım Tarihini Kontrol Ediniz.");
                return;
            }

            //else if (radioButton_kiralik_ev.Checked == false)
            //{
            //    groupBox_kiralik_ev.Visible = false;
            //    groupBox_satilik_ev.Visible = true;
            //    MessageBox.Show("Lütfen Ev Tercihini Yapınız");
            //    return;
            //}
            else if (radioButton_kiralik_ev.Checked == true)
            {
                groupBox_kiralik_ev.Visible = true;
                groupBox_satilik_ev.Visible = false;
                if (string.IsNullOrWhiteSpace(textBox_kiralikEv_kira.Text) || !int.TryParse(textBox_kiralikEv_kira.Text, out int kira) || kira < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir kira bedeli giriniz (0 veya daha büyük sayı).");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox_kiralikEv_depozito.Text) || !int.TryParse(textBox_kiralikEv_depozito.Text, out int depozito) || depozito < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir depozito bedeli giriniz (0 veya daha büyük sayı).");
                    return;
                }

            }
            else if (radioButton_satilik_ev.Checked == false)
            {
                groupBox_kiralik_ev.Visible = true;
                groupBox_satilik_ev.Visible = false;
                MessageBox.Show("Lütfen Ev Tercihini Yapınız");
                return;
            }
            else if (radioButton_satilik_ev.Checked == true)
            {
                groupBox_satilik_ev.Visible = true;
                groupBox_kiralik_ev.Visible = false;

                if (string.IsNullOrWhiteSpace(textBox_satilikEv_fiyat.Text) || !int.TryParse(textBox_satilikEv_fiyat.Text, out int fiyat) || fiyat < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir satış fiyatı giriniz (0 veya daha büyük sayı).");
                    return;
                }

            }

            try
            {
                int emlak_no_update = Convert.ToInt32(label_emlak_numarasi.Text);
                EvUpdate(emlak_no_update);
                MessageBox.Show("Ev Bilgileri Başarılı Bir Şekilde Güncellendi.");
                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void EvUpdate(int emlak_no_update)
        {
            groupBox_satilik_ev.Visible = true;

            string evDurumBilgisi = "";
            if (radioButton_aktif.Checked == true)
                evDurumBilgisi = "aktif";
            else
                evDurumBilgisi = "pasif";

            using (emlakDBEntities context = new emlakDBEntities())
            {
                var ev_update_ev = context.Evs.Where(x => x.emlakNumarasi == emlak_no_update).First();
                ev_update_ev.il = comboBox_il.Text;
                ev_update_ev.ilce = comboBox_ilce.Text;
                ev_update_ev.semt = textBox_adres.Text;
                ev_update_ev.katNumarasi = Convert.ToInt32(textBox_kat_numarasi.Text);
                ev_update_ev.toplamEvAlani = Convert.ToInt32(textBox_toplam_alan.Text);
                ev_update_ev.odaSayisi = Convert.ToInt32(textBox_oda_sayisi.Text);
                ev_update_ev.evTuru = comboBox_ev_turu.Text;
                ev_update_ev.yapimTarihi = Convert.ToDateTime(dateTimePicker_ev_yapim_tarihi.Text);
                ev_update_ev.evDurumu = evDurumBilgisi;

                if (radioButton_satilik_ev.Checked == true)
                {
                    groupBox_satilik_ev.Visible = true;
                    groupBox_kiralik_ev.Visible = false;
                    var ev_update_Satilik_ev = context.SatilikEvs.Where(y => y.emlakNumarasi == emlak_no_update).First();
                    ev_update_Satilik_ev.fiyat = Convert.ToInt32(textBox_satilikEv_fiyat.Text);
                    context.SaveChanges();
                }
                else
                {
                    groupBox_satilik_ev.Visible = false;
                    groupBox_kiralik_ev.Visible = true;
                    var ev_update_Kiralik_ev = context.KiralikEvs.Where(y => y.emlakNumarasi == emlak_no_update).First();
                    ev_update_Kiralik_ev.depozito = Convert.ToInt32(textBox_kiralikEv_depozito.Text);
                    ev_update_Kiralik_ev.kira = Convert.ToInt32(textBox_kiralikEv_kira.Text);
                    context.SaveChanges();
                }
            }
        }

        private void comboBox_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (emlakDBEntities context = new emlakDBEntities())
            {
                var data = context.il_listeleme(comboBox_il.Text.ToString());
                //yeni ilçe seçildiğinde combobox temizleniyor.
                comboBox_ilce.Items.Clear();
                foreach (var item in data)
                {
                    comboBox_ilce.Items.Add(item);
                }
            }
        }

        private void dateTimePicker_ev_yapim_tarihi_ValueChanged(object sender, EventArgs e)
        {
            EvYasHesaplama();
        }

        private void EvYasHesaplama()
        {
            DateTime yapimTarihi = dateTimePicker_ev_yapim_tarihi.Value;
            DateTime bugun = DateTime.Now;

            if (yapimTarihi > bugun)
            {
                textBox_ev_yasi.Text = "Hatalı Tarih";
                return;
            }

            int yas = bugun.Year - yapimTarihi.Year;
            if (bugun.Month < yapimTarihi.Month || (bugun.Month == yapimTarihi.Month && bugun.Day < yapimTarihi.Day))
            {
                yas--;
            }

            textBox_ev_yasi.Text = yas.ToString();
        }


        private void radioButton_satilik_ev_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_satilik_ev.Visible = true;
            groupBox_satilik_ev.Show();
            groupBox_kiralik_ev.Hide();
        }

        private void radioButton_kiralik_ev_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_satilik_ev.Hide();
            groupBox_kiralik_ev.Show();
        }

        private void button_ev_resimleri_Click(object sender, EventArgs e)
        {
            int emlakNo = Convert.ToInt32(emlak_numarasi_form_aktarma); // veya kullanıcıdan al

            using (emlakDBEntities context = new emlakDBEntities())
            {
                var resimListesi = context.EvResimlers
                    .Where(r => r.EmlakNo == emlakNo)
                    .Select(r => r.Resim)
                    .ToList();

                if (resimListesi.Any())
                {
                    FormResimGoster form = new FormResimGoster(resimListesi);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Bu emlak için kayıtlı resim yok.");
                }
            }
        }

        private void textBox_adres_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox_kat_numarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
