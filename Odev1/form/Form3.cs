using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev1
{
    public partial class Hakem : Form,IObservable
    {
        int id;
        log _log = new log();
        List<IObserver> observers = new List<IObserver>();




        public Hakem()
        {
            //observer tanimlama
            Logger fileLogger = FileLogger.getInstance("log.log");
            Logger dbLogger = DBLogger.getInstance();

            //observer ekle
            registerObserver(fileLogger);
            registerObserver(dbLogger);


            InitializeComponent();
        }

        private void hakemButonEkle_Click(object sender, EventArgs e)
        {
            if (hakemComboTuru.SelectedIndex > -1 && hakemComboClassman.SelectedIndex > -1 && hakemComboBolge.SelectedIndex > -1)
            {
                HakemController h = new HakemController();
                hakem hkm = new hakem();

                

                hkm.hakem_adi = hakemTextAdi.Text;
                hkm.hakem_soyadi = hakemTextSoyadi.Text;
                hkm.hakem_turu = hakemComboTuru.Text;
                hkm.hakem_classman = hakemComboClassman.Text;
                hkm.hakem_bolge = hakemComboBolge.Text;


                h.ekle(hkm);
                MessageBox.Show("Başarılı");


                this._log.tarih = DateTime.Now;
                this._log.tur = "hakem";
                this._log.isim = hakemTextAdi.Text + " " + hakemTextSoyadi.Text;
                this._log.islem = "eklendi";
                notifyObservers(); // log dosyasi butun observer lara gonderiliyor

                hakemTablo.DataSource = h.arama("");
            }
            else
            {
                MessageBox.Show("Lütfen combo  box'ları boş bırakmayın");
            }
        }

        private void Hakem_Load(object sender, EventArgs e)
        {
            HakemController h = new HakemController();
            hakemComboTuru.Items.Clear();
            hakemComboClassman.Items.Clear();
            hakemComboBolge.Items.Clear();

            hakemTablo.DataSource = h.arama("");

                hakemComboTuru.Items.Add("baş hakem");
                P2comboHakemTuru.Items.Add("baş hakem");

                hakemComboTuru.Items.Add("yardımcı hakem");
                P2comboHakemTuru.Items.Add("yardımcı hakem");

                hakemComboTuru.Items.Add("yazıcı hakem");
                P2comboHakemTuru.Items.Add("yazıcı hakem");

                hakemComboTuru.Items.Add("çizgi hakemi");
                P2comboHakemTuru.Items.Add("çizgi hakemi");

            
            foreach (var i in h.hakemClassmanListele())
            {
                hakemComboClassman.Items.Add(i);
                P2comboHakemClassman.Items.Add(i);

            }

            hakemComboBolge.Items.Add("baş hakem");
            P2comboHakemBolge.Items.Add("baş hakem");

            hakemComboBolge.Items.Add("yardımcı hakem");
            P2comboHakemBolge.Items.Add("yardımcı hakem");

            hakemComboBolge.Items.Add("yazıcı hakem");
            P2comboHakemBolge.Items.Add("yazıcı hakem");

            hakemComboBolge.Items.Add("çizgi hakemi");
            P2comboHakemBolge.Items.Add("çizgi hakemi");

                hakemComboBolge.Items.Add("fark etmez");
                P2comboHakemBolge.Items.Add("fark etmez");

         

            panel2.Visible = false;

            /*########################### burada form elemanları ayarlanıcak*/


            /*tiplere gore ayarlanıcak olan form elemanları tutuluyor */
            List<TextBox> textBoxTip1 = new List<TextBox>();
            List<ComboBox> comboBoxTip1 = new List<ComboBox>();
            List<Button> buttonTip1 = new List<Button>();

            textBoxTip1.Add(hakemTextAdi);
            textBoxTip1.Add(hakemTextSoyadi);
            comboBoxTip1.Add(hakemComboTuru);
            comboBoxTip1.Add(hakemComboClassman);
            comboBoxTip1.Add(hakemComboBolge);
            buttonTip1.Add(hakemButonEkle);

            ComponentConfiguration c = ComponentConfiguration.Instance();

            // burda componentler dizayn ediliyor
            c.textBoxDizaynEt(textBoxTip1,"birinci");
            c.comboBoxDizaynEt(comboBoxTip1,"birinci");
            c.buttonDizaynEt(buttonTip1,"birinci");
            
            

            
        }

        private void hakemListeleB_Click(object sender, EventArgs e)
        {
            
            HakemController h = new HakemController();
            hakemTablo.DataSource = h.arama(hakemAramaText.Text);
            hakemTablo.ClearSelection();
        }

        private void hakemSilB_Click(object sender, EventArgs e)
        {
            if (hakemTablo.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show(hakemTablo.SelectedRows[0].Cells[1].Value.ToString() + " hakemi silmek istediğizden emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    int sid = Convert.ToInt32(hakemTablo.SelectedRows[0].Cells[0].Value.ToString());
                    HakemController h = new HakemController();
                    h.sil(sid);

                    this._log.tarih = DateTime.Now;
                    this._log.tur = "hakem";
                    this._log.isim = hakemTablo.SelectedRows[0].Cells[1].Value.ToString() + " " + hakemTablo.SelectedRows[0].Cells[2].Value.ToString();
                    this._log.islem = "silindi";
                    notifyObservers(); // log dosyasi butun observer lara gonderiliyor

                    hakemTablo.DataSource = h.arama("");
                    MessageBox.Show("Silindi veri");


                  
                }
            }
            else
            {
                MessageBox.Show("tablodan deger seç");
            }
        }

        private void hakemDuzenleB_Click(object sender, EventArgs e)
        {
            HakemController h = new HakemController();

            if (hakemTablo.SelectedRows.Count > 0)
            {
                panel2.Visible = true;
                id = int.Parse(hakemTablo.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void P2guncelleB_Click(object sender, EventArgs e)
        {
            HakemController h = new HakemController();
            h.duzenle(id, P2textAdi.Text, P2textSoyadi.Text, P2comboHakemTuru.Text, P2comboHakemClassman.Text, P2comboHakemBolge.Text);
            hakemTablo.DataSource = h.arama("");

            //log dolduruluyor
            this._log.tarih = DateTime.Now;
            this._log.tur = "hakem";
            this._log.isim = P2textAdi.Text + " " + P2textSoyadi.Text;
            this._log.islem = "güncellendi";
            notifyObservers(); // log dosyasi butun observer lara gonderiliyor
        }

        private void hakemTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(hakemTablo.SelectedRows[0].Cells[0].Value.ToString());
        }




        

        public void registerObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

       public void notifyObservers()
        {
            for (int i = 0; i < observers.Count; i++ )
            {
                observers[i].update(this._log);
            }
        }

       private void button1_Click(object sender, EventArgs e)
       {
           testtcs f = new testtcs();
           f.Show();
           this.Hide();
       }

       private void tabPage1_Click(object sender, EventArgs e)
       {

       }

       private void label2_Click(object sender, EventArgs e)
       {

       }

       private void label4_Click(object sender, EventArgs e)
       {

       }


      
    }
}
