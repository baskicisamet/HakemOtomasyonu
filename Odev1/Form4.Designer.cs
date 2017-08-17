namespace Odev1
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.takimComboSalon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.takimEkleB = new System.Windows.Forms.Button();
            this.takimComboLig = new System.Windows.Forms.ComboBox();
            this.takimTextAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.P2comboSalon = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.P2guncelleB = new System.Windows.Forms.Button();
            this.P2comboLig = new System.Windows.Forms.ComboBox();
            this.P2textAdi = new System.Windows.Forms.TextBox();
            this.takimSilB = new System.Windows.Forms.Button();
            this.takimListeleB = new System.Windows.Forms.Button();
            this.takimDuzenleB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.takimAramaText = new System.Windows.Forms.TextBox();
            this.takimTablo = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.takimTablo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1095, 630);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tabPage1.Controls.Add(this.takimComboSalon);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.takimEkleB);
            this.tabPage1.Controls.Add(this.takimComboLig);
            this.tabPage1.Controls.Add(this.takimTextAdi);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1087, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EKLEME";
            // 
            // takimComboSalon
            // 
            this.takimComboSalon.FormattingEnabled = true;
            this.takimComboSalon.Location = new System.Drawing.Point(189, 296);
            this.takimComboSalon.Margin = new System.Windows.Forms.Padding(4);
            this.takimComboSalon.Name = "takimComboSalon";
            this.takimComboSalon.Size = new System.Drawing.Size(321, 24);
            this.takimComboSalon.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Buxton Sketch", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(26, 289);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "Spor Salonu :";
            // 
            // takimEkleB
            // 
            this.takimEkleB.BackColor = System.Drawing.Color.DarkGray;
            this.takimEkleB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takimEkleB.Location = new System.Drawing.Point(604, 193);
            this.takimEkleB.Margin = new System.Windows.Forms.Padding(4);
            this.takimEkleB.Name = "takimEkleB";
            this.takimEkleB.Size = new System.Drawing.Size(187, 100);
            this.takimEkleB.TabIndex = 8;
            this.takimEkleB.Text = "EKLE";
            this.takimEkleB.UseVisualStyleBackColor = false;
            this.takimEkleB.Click += new System.EventHandler(this.takimEkleB_Click);
            // 
            // takimComboLig
            // 
            this.takimComboLig.FormattingEnabled = true;
            this.takimComboLig.Location = new System.Drawing.Point(189, 233);
            this.takimComboLig.Margin = new System.Windows.Forms.Padding(4);
            this.takimComboLig.Name = "takimComboLig";
            this.takimComboLig.Size = new System.Drawing.Size(321, 24);
            this.takimComboLig.TabIndex = 7;
            // 
            // takimTextAdi
            // 
            this.takimTextAdi.Location = new System.Drawing.Point(189, 180);
            this.takimTextAdi.Margin = new System.Windows.Forms.Padding(4);
            this.takimTextAdi.Name = "takimTextAdi";
            this.takimTextAdi.Size = new System.Drawing.Size(321, 22);
            this.takimTextAdi.TabIndex = 4;
            this.takimTextAdi.TextChanged += new System.EventHandler(this.salonTextAdi_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Buxton Sketch", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(34, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ligi : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Buxton Sketch", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(34, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Takım Adı : ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.takimSilB);
            this.tabPage2.Controls.Add(this.takimListeleB);
            this.tabPage2.Controls.Add(this.takimDuzenleB);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.takimAramaText);
            this.tabPage2.Controls.Add(this.takimTablo);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1087, 601);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DÜZENLEME";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.P2comboSalon);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.P2guncelleB);
            this.panel2.Controls.Add(this.P2comboLig);
            this.panel2.Controls.Add(this.P2textAdi);
            this.panel2.Location = new System.Drawing.Point(32, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 100);
            this.panel2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(602, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Spor Salonu";
            // 
            // P2comboSalon
            // 
            this.P2comboSalon.FormattingEnabled = true;
            this.P2comboSalon.Location = new System.Drawing.Point(529, 60);
            this.P2comboSalon.Name = "P2comboSalon";
            this.P2comboSalon.Size = new System.Drawing.Size(230, 24);
            this.P2comboSalon.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(350, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Lig";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(95, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Adı";
            // 
            // P2guncelleB
            // 
            this.P2guncelleB.ForeColor = System.Drawing.Color.Maroon;
            this.P2guncelleB.Location = new System.Drawing.Point(881, 17);
            this.P2guncelleB.Name = "P2guncelleB";
            this.P2guncelleB.Size = new System.Drawing.Size(113, 67);
            this.P2guncelleB.TabIndex = 4;
            this.P2guncelleB.Text = "Bilgileri Güncelle";
            this.P2guncelleB.UseVisualStyleBackColor = true;
            this.P2guncelleB.Click += new System.EventHandler(this.P2guncelleB_Click);
            // 
            // P2comboLig
            // 
            this.P2comboLig.FormattingEnabled = true;
            this.P2comboLig.Location = new System.Drawing.Point(253, 60);
            this.P2comboLig.Name = "P2comboLig";
            this.P2comboLig.Size = new System.Drawing.Size(230, 24);
            this.P2comboLig.TabIndex = 3;
            // 
            // P2textAdi
            // 
            this.P2textAdi.Location = new System.Drawing.Point(46, 60);
            this.P2textAdi.Name = "P2textAdi";
            this.P2textAdi.Size = new System.Drawing.Size(176, 22);
            this.P2textAdi.TabIndex = 0;
            // 
            // takimSilB
            // 
            this.takimSilB.Location = new System.Drawing.Point(754, 54);
            this.takimSilB.Name = "takimSilB";
            this.takimSilB.Size = new System.Drawing.Size(75, 23);
            this.takimSilB.TabIndex = 11;
            this.takimSilB.Text = "Sil";
            this.takimSilB.UseVisualStyleBackColor = true;
            this.takimSilB.Click += new System.EventHandler(this.takimSilB_Click);
            // 
            // takimListeleB
            // 
            this.takimListeleB.Location = new System.Drawing.Point(659, 53);
            this.takimListeleB.Name = "takimListeleB";
            this.takimListeleB.Size = new System.Drawing.Size(75, 23);
            this.takimListeleB.TabIndex = 10;
            this.takimListeleB.Text = "Listele";
            this.takimListeleB.UseVisualStyleBackColor = true;
            this.takimListeleB.Click += new System.EventHandler(this.takimListeleB_Click);
            // 
            // takimDuzenleB
            // 
            this.takimDuzenleB.Location = new System.Drawing.Point(861, 54);
            this.takimDuzenleB.Name = "takimDuzenleB";
            this.takimDuzenleB.Size = new System.Drawing.Size(75, 23);
            this.takimDuzenleB.TabIndex = 9;
            this.takimDuzenleB.Text = "Düzenle";
            this.takimDuzenleB.UseVisualStyleBackColor = true;
            this.takimDuzenleB.Click += new System.EventHandler(this.takimDuzenleB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Arama";
            // 
            // takimAramaText
            // 
            this.takimAramaText.Location = new System.Drawing.Point(285, 54);
            this.takimAramaText.Margin = new System.Windows.Forms.Padding(4);
            this.takimAramaText.Name = "takimAramaText";
            this.takimAramaText.Size = new System.Drawing.Size(348, 22);
            this.takimAramaText.TabIndex = 7;
            // 
            // takimTablo
            // 
            this.takimTablo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.takimTablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.takimTablo.Location = new System.Drawing.Point(22, 267);
            this.takimTablo.Margin = new System.Windows.Forms.Padding(4);
            this.takimTablo.Name = "takimTablo";
            this.takimTablo.ReadOnly = true;
            this.takimTablo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.takimTablo.Size = new System.Drawing.Size(1048, 345);
            this.takimTablo.TabIndex = 2;
            this.takimTablo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.takimTablo_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 651);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1091, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ana SAYFA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 695);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form4";
            this.Text = "Takım";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.takimTablo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button takimEkleB;
        private System.Windows.Forms.ComboBox takimComboLig;
        private System.Windows.Forms.TextBox takimTextAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button P2guncelleB;
        private System.Windows.Forms.ComboBox P2comboLig;
        private System.Windows.Forms.TextBox P2textAdi;
        private System.Windows.Forms.Button takimSilB;
        private System.Windows.Forms.Button takimListeleB;
        private System.Windows.Forms.Button takimDuzenleB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox takimAramaText;
        private System.Windows.Forms.DataGridView takimTablo;
        private System.Windows.Forms.ComboBox takimComboSalon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox P2comboSalon;
        private System.Windows.Forms.Button button1;

    }
}