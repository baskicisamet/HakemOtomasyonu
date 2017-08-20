using System;
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

     
    public partial class Form1 : Form
    {

        int id;
        public Form1()
        {
            InitializeComponent();
        }

        private void sporcuEkleB_Click(object sender, EventArgs e)
        {
            if (sporcuComboLig.SelectedIndex > -1)
            {
                SporcuController c = new SporcuController();
                c.ekle(SporcuTextAd.Text, SporcuTextSoyad.Text, sporcuComboLig.Text, SporcuTextOzellik.Text);
                MessageBox.Show("Başarılı");

                sporcuTablo.DataSource = c.arama("");
            }
            else
            {
                MessageBox.Show("Lütfen lig seçinizé");
            }

        }

        private void SporcuDuzenleB_Click(object sender, EventArgs e)
        {
            SporcuController c = new SporcuController();
            
            if (sporcuTablo.SelectedRows.Count > 0)
            {
                panel1.Visible = true;
                id = int.Parse(sporcuTablo.SelectedRows[0].Cells[0].Value.ToString());
            }

            //c.duzenle(id,);

            /*
            SporcuController c = new SporcuController();

            c.duzenle(9, "Samet Naber", "Baskıcı Ulen", "aroma voleybol ligi", "bla bla Özellik");
            MessageBox.Show("Başarılı");
             */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SporcuController c = new SporcuController();
            sporcuComboLig.Items.Clear();

            sporcuTablo.DataSource = c.arama("");

            foreach (var i in c.ligListele())
            {
                sporcuComboLig.Items.Add(i);
                PcomboLig.Items.Add(i);

            }

            panel1.Visible = false;
 
        }


        private void SporcuListeleB_Click(object sender, EventArgs e)
        {
            SporcuController c = new SporcuController();
            sporcuTablo.DataSource = c.arama(sporcuAramaText.Text);
            sporcuTablo.ClearSelection();
        }

        private void SporcuSilB_Click(object sender, EventArgs e)
        {
            if (sporcuTablo.SelectedRows.Count > 0)
            {
                DialogResult rs =MessageBox.Show(sporcuTablo.SelectedRows[0].Cells[1].Value.ToString()+" sporcuyu silmek istediğizden emin misin?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    int sid=Convert.ToInt32(sporcuTablo.SelectedRows[0].Cells[0].Value.ToString());
                    SporcuController c = new SporcuController();
                    c.sil(sid);
                    sporcuTablo.DataSource = c.arama("");
                    MessageBox.Show("Silindi veri");
                }
            }
            else
            {
                MessageBox.Show("tabloıdan deger seç");
            }
        }

        private void guncelleB_Click(object sender, EventArgs e)
        {
            SporcuController c = new SporcuController();
            c.duzenle(id, PtextAdi.Text, PtextSoyadi.Text, PcomboLig.Text, PtextOzellik.Text);
            sporcuTablo.DataSource = c.arama("");

            /*
            SporcuController c = new SporcuController();

            c.duzenle(9, "Samet Naber", "Baskıcı Ulen", "aroma voleybol ligi", "bla bla Özellik");
            MessageBox.Show("Başarılı");
             */
        }

        private void salonGidisButon_Click(object sender, EventArgs e)
        {

            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void sporcuTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(sporcuTablo.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hakem a = new Hakem();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FiksturForm a = new FiksturForm();
            a.Show();
            this.Hide();
        }

        private void test_Click(object sender, EventArgs e)
        {
            FiksturFormTestcs a = new FiksturFormTestcs();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FiksturFormm a = new FiksturFormm();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            testtcs a = new testtcs();
            a.Show();
            this.Hide();
        }

        
    }
}
