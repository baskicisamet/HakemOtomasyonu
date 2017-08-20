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
    public partial class FiksturForm : Form
    {

        int panel_sayisi_lig1;
        int panel_sayisi_lig2;
        int panel_sayisi_lig3;

        int haftadaki_panel_sayisi_lig1;
        int haftadaki_panel_sayisi_lig2;
        int haftadaki_panel_sayisi_lig3;

        List<musabaka> musabakalarLig1;
        List<musabaka> musabakalarLig2;
        List<musabaka> musabakalarLig3;

        FiksturConfiguration fiksturConfiguration;
        
        public FiksturForm()
        {
            
            InitializeComponent();
        }

        private void FiksturForm_Load(object sender, EventArgs e)
        {

            fiksturConfiguration = new FiksturConfiguration();

           
            panel_sayisi_lig1 =  fiksturConfiguration.getLig1HaftaSayisi();
            panel_sayisi_lig2 = fiksturConfiguration.getLig2HaftaSayisi();
            panel_sayisi_lig3 = fiksturConfiguration.getLig3HaftaSayisi();

            haftadaki_panel_sayisi_lig1 = fiksturConfiguration.getLig1HaftadakiMacSayisi();
            haftadaki_panel_sayisi_lig2 = fiksturConfiguration.getLig2HaftadakiMacSayisi();
            haftadaki_panel_sayisi_lig3 = fiksturConfiguration.getLig3HaftadakiMacSayisi();

            musabakalarLig1 = fiksturConfiguration.getMusabakalarLig1();
            musabakalarLig2 = fiksturConfiguration.getMusabakalarLig2();
            musabakalarLig3 = fiksturConfiguration.getMusabakalarLig3();


            panelBuild();

            
        }

        public void panelBuild()
        {
            for (int i = 1; i <= panel_sayisi_lig1;i++ )
            {
                Panel panel = new Panel();
                

                
                panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
                panel.Location = new System.Drawing.Point(3, 68);
                panel.Size = new System.Drawing.Size(500, 200);

                panel1.Controls.Add(panel);
            }

           
                Button btn = new Button();
                btn.Location = new System.Drawing.Point(391, 801);
                btn.Name = "button10";
                btn.Size = new System.Drawing.Size(300, 23);
                btn.TabIndex = 13;
                btn.Text = "button10";
                btn.UseVisualStyleBackColor = true;
                panel1.Controls.Add(btn);
            


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        

        
      

       

       
    }
}
