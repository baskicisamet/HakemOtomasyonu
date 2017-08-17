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

    
    public partial class Form2 : Form
    {

        int id;
        public Form2()
        {
            InitializeComponent();
        }

        private void guncelleB_Click(object sender, EventArgs e)
        {
            SalonController c = new SalonController();
            c.duzenle(id, P2textAdi.Text, P2textSehir.Text, P2comboLig.Text, P2textOzellik.Text);
            salonTablo.DataSource = c.arama("");
        }

        private void salonEkleB_Click(object sender, EventArgs e)
        {
            if (salonComboLig.SelectedIndex > -1)
            {
                SalonController c = new SalonController();
                c.ekle(salonTextAdi.Text, salonTextSehir.Text, salonComboLig.Text, salonTextOzellik.Text);
                MessageBox.Show("Başarılı");

                salonTablo.DataSource = c.arama("");











            }
            else
            {
                MessageBox.Show("Lütfen lig seçinizé");
            }
        }

        private void SalonListeleB_Click(object sender, EventArgs e)
        {
            SalonController c = new SalonController();
            salonTablo.DataSource = c.arama(salonAramaText.Text);
            salonTablo.ClearSelection();
        }

        private void SalonSilB_Click(object sender, EventArgs e)
        {

            if (salonTablo.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show(salonTablo.SelectedRows[0].Cells[1].Value.ToString() + " sporcuyu silmek istediğizden emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    int sid = Convert.ToInt32(salonTablo.SelectedRows[0].Cells[0].Value.ToString());
                    SalonController c = new SalonController();
                    c.sil(sid);
                    salonTablo.DataSource = c.arama("");
                    MessageBox.Show("Silindi veri");
                }
            }
            else
            {
                MessageBox.Show("tablodan deger seç");
            }


        }

        private void SalonDuzenleB_Click(object sender, EventArgs e)
        {
            SalonController c = new SalonController();

            if (salonTablo.SelectedRows.Count > 0)
            {
                panel2.Visible = true;
                id = int.Parse(salonTablo.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void sporcuGidisButon_Click(object sender, EventArgs e)
        {
            testtcs f = new testtcs();
            f.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SalonController c = new SalonController();
            salonComboLig.Items.Clear();

            salonTablo.DataSource = c.arama("");

            foreach (var i in c.ligListele())
            {
                salonComboLig.Items.Add(i);
                P2comboLig.Items.Add(i);

            }

            panel2.Visible = false;
        }

        private void salonTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(salonTablo.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
