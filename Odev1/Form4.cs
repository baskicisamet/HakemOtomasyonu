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
    public partial class Form4 : Form
    {

        int id;

        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void salonTextAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void takimTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(takimTablo.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TakimController c = new TakimController();

            takimComboLig.Items.Clear();
            takimComboSalon.Items.Clear();

            takimTablo.DataSource = c.arama("");

            foreach (var i in c.ligListele())
            {
                takimComboLig.Items.Add(i);
                P2comboLig.Items.Add(i);

            }
            foreach (var i in c.salonListele())
            {
                takimComboSalon.Items.Add(i);
                P2comboSalon.Items.Add(i);

            }

            panel2.Visible = false;
        }

        private void takimListeleB_Click(object sender, EventArgs e)
        {
            TakimController c = new TakimController();
            takimTablo.DataSource = c.arama(takimAramaText.Text);
            takimTablo.ClearSelection();
        }

        private void takimSilB_Click(object sender, EventArgs e)
        {
            if (takimTablo.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show(takimTablo.SelectedRows[0].Cells[1].Value.ToString() + " takımı silmek istediğizden emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    int sid = Convert.ToInt32(takimTablo.SelectedRows[0].Cells[0].Value.ToString());
                    TakimController c = new TakimController();
                    c.sil(sid);
                    takimTablo.DataSource = c.arama("");
                    MessageBox.Show("Silindi veri");
                }
            }
            else
            {
                MessageBox.Show("tabloıdan deger seç");
            }
        }

        private void takimDuzenleB_Click(object sender, EventArgs e)
        {
            TakimController c = new TakimController();

            if (takimTablo.SelectedRows.Count > 0)
            {
                panel2.Visible = true;
                id = int.Parse(takimTablo.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void P2guncelleB_Click(object sender, EventArgs e)
        {
            TakimController c = new TakimController();
            c.duzenle(id, P2textAdi.Text, P2comboLig.Text, P2comboSalon.Text);
            takimTablo.DataSource = c.arama("");
        }

        private void takimEkleB_Click(object sender, EventArgs e)
        {
            if (takimComboLig.SelectedIndex > -1 && takimComboSalon.SelectedIndex > -1)
            {
                TakimController c = new TakimController();
                

                


                c.ekle(takimTextAdi.Text, takimComboLig.Text, takimComboSalon.Text);
                MessageBox.Show("Başarılı");

                takimTablo.DataSource = c.arama("");
            }
            else
            {
                MessageBox.Show("Lütfen lig seçinizé");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testtcs f = new testtcs();
            f.Show();
            this.Hide();
        }
    }
}
