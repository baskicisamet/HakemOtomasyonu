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


    public partial class FiksturFormm : Form,IObservable
    {

        log _log = new log();
        List<IObserver> observers = new List<IObserver>();

        int takim_sayisi_lig1;
        int takim_sayisi_lig2;
        int takim_sayisi_lig3;


        int musabaka_sayisi_lig1;
        int musabaka_sayisi_lig2;
        int musabaka_sayisi_lig3;

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
        public FiksturFormm()
        {
            InitializeComponent();

            //observer tanimlama
            Logger fileLogger = FileLogger.getInstance("log.log");
            Logger dbLogger = DBLogger.getInstance();

            //observer ekle
            registerObserver(fileLogger);
            registerObserver(dbLogger);

            

            fiksturConfiguration = new FiksturConfiguration();

            fiksturConfiguration.Lig1TakimEslestir();
            fiksturConfiguration.lig1TakimEslestirDevre2();
            fiksturConfiguration.hakemAtaLig1();
            fiksturConfiguration.fiksturKaydetLig1();

            fiksturConfiguration.Lig2TakimEslestir();
            fiksturConfiguration.lig2TakimEslestirDevre2();
            fiksturConfiguration.hakemAtaLig2();
            fiksturConfiguration.fiksturKaydetLig2();

            fiksturConfiguration.Lig3TakimEslestir();
            fiksturConfiguration.lig3TakimEslestirDevre2();
            fiksturConfiguration.hakemAtaLig3();
            fiksturConfiguration.fiksturKaydetLig3();


            this._log.tarih = DateTime.Now;
            this._log.tur = "fikstur";
            this._log.isim = " ";
            this._log.islem = "oluşturuldu";
            notifyObservers(); // log dosyasi butun observer lara gonderiliyor




            musabakalarLig1 = fiksturConfiguration.getFiksturLig1(); // veri tabanindan musabakalari cekiyor
            musabakalarLig2 = fiksturConfiguration.getFiksturLig2();
            musabakalarLig3 = fiksturConfiguration.getFiksturLig3();




            //panel sayilarini hesapla
            musabaka_sayisi_lig1 = musabakalarLig1.Count;
            musabaka_sayisi_lig2 = musabakalarLig2.Count;
            musabaka_sayisi_lig3 = musabakalarLig3.Count;


            takim_sayisi_lig1 = musabakasayisiToTakimSayisi(musabaka_sayisi_lig1);
            takim_sayisi_lig2 = musabakasayisiToTakimSayisi(musabaka_sayisi_lig2);
            takim_sayisi_lig3 = musabakasayisiToTakimSayisi(musabaka_sayisi_lig3);
            

            haftadaki_panel_sayisi_lig1 = takim_sayisi_lig1 / 2;
            haftadaki_panel_sayisi_lig2 = takim_sayisi_lig2 / 2;
            haftadaki_panel_sayisi_lig3 = takim_sayisi_lig3 / 2;


            panel_sayisi_lig1 = musabaka_sayisi_lig1 / haftadaki_panel_sayisi_lig1;
            panel_sayisi_lig2 = musabaka_sayisi_lig2 / haftadaki_panel_sayisi_lig2;
            panel_sayisi_lig3 = musabaka_sayisi_lig3 / haftadaki_panel_sayisi_lig3;

            

            controlsBuildLig1();
            controlsBuildLig2();
            controlsBuildLig3();




           

        }

        public int musabakasayisiToTakimSayisi(int m_sayi){
            int takim_sayisi=0;
            for (int i = 0; i < m_sayi ;i++ )
            {
                if((i*(i+1))== m_sayi){
                    takim_sayisi = i + 1;
                    
                    break;
                }
            }
            return takim_sayisi;
        }


        public void controlsBuildLig1()
        {
            int index = 0;
            for (int i = 0; i < panel_sayisi_lig1;i++ )
            {
                
                
                //hafta panalleri olusturluyor
                Panel haftaPanel = new Panel();
                //panel ozellikleri belirle
                haftaPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

                haftaPanel.Location = new System.Drawing.Point(71, 79+(i*326));
                haftaPanel.Name = "panel3";
                haftaPanel.Size = new System.Drawing.Size(100+(haftadaki_panel_sayisi_lig1*236), 310);
                haftaPanel.TabIndex = 7;

                containerPanelLig1.Controls.Add(haftaPanel);

                //hafta panel baslik olusturuluyor
                Panel haftaPanelBaslik = new Panel();

                haftaPanelBaslik.BackColor = System.Drawing.Color.Gray;
                haftaPanelBaslik.Location = new System.Drawing.Point(3, 3);
                haftaPanelBaslik.Name = "hafta_baslik_panel_1";
                haftaPanelBaslik.Size = new System.Drawing.Size(100 + (haftadaki_panel_sayisi_lig1 * 236), 20);
                haftaPanelBaslik.TabIndex = 5;

                haftaPanel.Controls.Add(haftaPanelBaslik);

                // hafta panel baslik label oluşturuluyor
                Label haftaBaslikLabel = new Label();

                haftaBaslikLabel.AutoSize = true;
                haftaBaslikLabel.ForeColor = System.Drawing.Color.Maroon;
                haftaBaslikLabel.Location = new System.Drawing.Point(18, 3);
                haftaBaslikLabel.Name = "hafta_baslik_label_"+i;
                haftaBaslikLabel.Size = new System.Drawing.Size(52, 17);
                haftaBaslikLabel.TabIndex = 0;
                haftaBaslikLabel.Text = (i+1)+".hafta";

                haftaPanelBaslik.Controls.Add(haftaBaslikLabel);

                for (int j = 0; j < haftadaki_panel_sayisi_lig1;j++ )
                {   //musabaka Panalleri olusturuluyor
                    Panel musabakaPanel = new Panel();

                    musabakaPanel.BackColor = System.Drawing.Color.Snow;
                    musabakaPanel.Location = new System.Drawing.Point(32+(j*242), 29);
                    musabakaPanel.Name = "hafta1_1";
                    musabakaPanel.Size = new System.Drawing.Size(236, 271);
                    musabakaPanel.TabIndex = 0;

                    haftaPanel.Controls.Add(musabakaPanel);

                    //musabaka icindeki labeller olusturuluyor

                    //A takim label
                    Label aTakimLabel = new Label();
                    aTakimLabel.AutoSize = true;
                    aTakimLabel.ForeColor = System.Drawing.Color.ForestGreen;
                    aTakimLabel.Location = new System.Drawing.Point(13, 12);
                    aTakimLabel.Name = "A_takim_1_1"+i+j;
                    aTakimLabel.Size = new System.Drawing.Size(46, 17);
                    aTakimLabel.TabIndex = 0;
                    aTakimLabel.Text = musabakalarLig1[index].ev_sahibi.ToString(); // A takim ********
                    musabakaPanel.Controls.Add(aTakimLabel);

                    // vs Label
                    Label vsLabel = new Label();
                    vsLabel.AutoSize = true;
                    vsLabel.Location = new System.Drawing.Point(101, 12);
                    vsLabel.Name = "vs_1_1"+i+j;
                    vsLabel.Size = new System.Drawing.Size(46, 17);
                    vsLabel.TabIndex = 1;
                    vsLabel.Text = "Vs";
                    musabakaPanel.Controls.Add(vsLabel);

                    //B takim label 
                    Label bTakimLabel = new Label();
                    bTakimLabel.AutoSize = true;
                    bTakimLabel.ForeColor = System.Drawing.Color.ForestGreen;
                    bTakimLabel.Location = new System.Drawing.Point(150, 12);
                    bTakimLabel.Name = "B_takim_1_1"+i+j;
                    bTakimLabel.Size = new System.Drawing.Size(46, 17);
                    bTakimLabel.TabIndex = 2;
                    bTakimLabel.Text = musabakalarLig1[index].misafir.ToString();  // B takim*********
                    musabakaPanel.Controls.Add(bTakimLabel);

                    //cizgiLabel

                    Label cizgiLabel = new Label();

                    cizgiLabel.AutoSize = true;
                    cizgiLabel.Location = new System.Drawing.Point(3, 40);
                    cizgiLabel.Name = "label4";
                    cizgiLabel.Size = new System.Drawing.Size(228, 17);
                    cizgiLabel.TabIndex = 0;
                    cizgiLabel.Text = "----------------------------------------------------------------------------";
                    musabakaPanel.Controls.Add(cizgiLabel);

                    // hakemGorevLabel
                    Label hakemGorevLabel = new Label();
                    hakemGorevLabel.AutoSize = true;
                    hakemGorevLabel.ForeColor = System.Drawing.Color.White;
                    hakemGorevLabel.Location = new System.Drawing.Point(81, 57);
                    hakemGorevLabel.Name = "gorevli_hakem_1_1"+i+j;
                    hakemGorevLabel.Size = new System.Drawing.Size(46, 17);
                    hakemGorevLabel.TabIndex = 3;
                    hakemGorevLabel.Text = "Görevli Hakemler";
                    musabakaPanel.Controls.Add(hakemGorevLabel);


                    // basHakemLabel
                    Label basHakemLabel = new Label();
                    basHakemLabel.AutoSize = true;
                    basHakemLabel.Location = new System.Drawing.Point(13, 84);
                    basHakemLabel.Name = "label5"+i+j;
                    basHakemLabel.Size = new System.Drawing.Size(46, 17);
                    basHakemLabel.TabIndex = 4;
                    basHakemLabel.Text = "Baş Hakem : "; 
                    musabakaPanel.Controls.Add(basHakemLabel);


                    //yardimciHakemLabel
                    Label yardimciHakemLabel = new Label();
                    yardimciHakemLabel.AutoSize = true;
                    yardimciHakemLabel.Location = new System.Drawing.Point(13, 113);
                    yardimciHakemLabel.Name = "label6"+i+j;
                    yardimciHakemLabel.Size = new System.Drawing.Size(46, 17);
                    yardimciHakemLabel.TabIndex = 5;
                    yardimciHakemLabel.Text = "Yardımcı Hakem : ";
                    musabakaPanel.Controls.Add(yardimciHakemLabel);

                    //yaziciHakemLabel
                    Label yaziciHakemLabel = new Label();
                    yaziciHakemLabel.AutoSize = true;
                    yaziciHakemLabel.Location = new System.Drawing.Point(13, 139);
                    yaziciHakemLabel.Name = "label7"+i+j;
                    yaziciHakemLabel.Size = new System.Drawing.Size(46, 17);
                    yaziciHakemLabel.TabIndex = 6;
                    yaziciHakemLabel.Text = "Yazıcı Hakem : ";
                    musabakaPanel.Controls.Add(yaziciHakemLabel);
                    

                    //cizgiHakem1Label
                    Label cizgiHakem1Label = new Label();
                    cizgiHakem1Label.AutoSize = true;
                    cizgiHakem1Label.Location = new System.Drawing.Point(13, 165);
                    cizgiHakem1Label.Name = "label8"+i+j;
                    cizgiHakem1Label.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem1Label.TabIndex = 7;
                    cizgiHakem1Label.Text = "Çizgi Hakem 1 : ";
                    musabakaPanel.Controls.Add(cizgiHakem1Label);

                    // //cizgiHakem2Label
                    Label cizgiHakem2Label = new Label();
                    cizgiHakem2Label.AutoSize = true;
                    cizgiHakem2Label.Location = new System.Drawing.Point(13, 191);
                    cizgiHakem2Label.Name = "label10";
                    cizgiHakem2Label.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem2Label.TabIndex = 8;
                    cizgiHakem2Label.Text = "Çizgi Hakem 2 :";
                    musabakaPanel.Controls.Add(cizgiHakem2Label);

                    //hakem Atamalari

                    // basHakemLabel
                    Label basHakemLabelA = new Label();
                    basHakemLabelA.AutoSize = true;
                    basHakemLabelA.Location = new System.Drawing.Point(110, 84);
                    basHakemLabelA.Name = "label5A" + i + j;
                    basHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    basHakemLabelA.TabIndex = 4;
                    basHakemLabelA.Text = musabakalarLig1[index].bas_hakem.ToString(); // bas hakem ********************
                    musabakaPanel.Controls.Add(basHakemLabelA);


                    //yardimciHakemLabel
                    Label yardimciHakemLabelA = new Label();
                    yardimciHakemLabelA.AutoSize = true;
                    yardimciHakemLabelA.Location = new System.Drawing.Point(110, 113);
                    yardimciHakemLabelA.Name = "label6A" + i + j;
                    yardimciHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    yardimciHakemLabelA.TabIndex = 5;
                    yardimciHakemLabelA.Text = musabakalarLig1[index].yardimci_hakem.ToString(); // yar hakem ********************
                    musabakaPanel.Controls.Add(yardimciHakemLabelA);

                    //yaziciHakemLabel
                    Label yaziciHakemLabelA = new Label();
                    yaziciHakemLabelA.AutoSize = true;
                    yaziciHakemLabelA.Location = new System.Drawing.Point(110, 139);
                    yaziciHakemLabelA.Name = "label7A" + i + j;
                    yaziciHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    yaziciHakemLabelA.TabIndex = 6;
                    yaziciHakemLabelA.Text = musabakalarLig1[index].yazi_hakemi.ToString(); // yazi hakem ********************
                    musabakaPanel.Controls.Add(yaziciHakemLabelA);


                    //cizgiHakem1Label
                    Label cizgiHakem1LabelA = new Label();
                    cizgiHakem1LabelA.AutoSize = true;
                    cizgiHakem1LabelA.Location = new System.Drawing.Point(110, 165);
                    cizgiHakem1LabelA.Name = "label8A" + i + j;
                    cizgiHakem1LabelA.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem1LabelA.TabIndex = 7;
                    cizgiHakem1LabelA.Text = musabakalarLig1[index].cizgi_hakem1.ToString();// cizgi1 hakem ********************
                    musabakaPanel.Controls.Add(cizgiHakem1LabelA);

                    // //cizgiHakem2Label
                    Label cizgiHakem2LabelA = new Label();
                    cizgiHakem2LabelA.AutoSize = true;
                    cizgiHakem2LabelA.Location = new System.Drawing.Point(110, 191);
                    cizgiHakem2LabelA.Name = "label10A"+i+j;
                    cizgiHakem2LabelA.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem2LabelA.TabIndex = 8;
                    cizgiHakem2LabelA.Text = musabakalarLig1[index].cizgi_hakem2.ToString(); ;// cizgi2 hakem ********************
                    musabakaPanel.Controls.Add(cizgiHakem2LabelA);

                    index++;
                }


                
            }
            
        }


        public void controlsBuildLig2()
        {

            
            int index = 0;
            for (int i = 0; i < panel_sayisi_lig2; i++)
            {


                //hafta panalleri olusturluyor
                Panel haftaPanel = new Panel();
                //panel ozellikleri belirle
                haftaPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

                haftaPanel.Location = new System.Drawing.Point(71, 79 + (i * 326));
                haftaPanel.Name = "panel3";
                haftaPanel.Size = new System.Drawing.Size(100 + (haftadaki_panel_sayisi_lig2 * 236), 310);
                haftaPanel.TabIndex = 7;

                containerPanelLig2.Controls.Add(haftaPanel);

                //hafta panel baslik olusturuluyor
                Panel haftaPanelBaslik = new Panel();

                haftaPanelBaslik.BackColor = System.Drawing.Color.Gray;
                haftaPanelBaslik.Location = new System.Drawing.Point(3, 3);
                haftaPanelBaslik.Name = "hafta_baslik_panel_1";
                haftaPanelBaslik.Size = new System.Drawing.Size(100 + (haftadaki_panel_sayisi_lig2 * 236), 20);
                haftaPanelBaslik.TabIndex = 5;

                haftaPanel.Controls.Add(haftaPanelBaslik);

                // hafta panel baslik label oluşturuluyor
                Label haftaBaslikLabel = new Label();

                haftaBaslikLabel.AutoSize = true;
                haftaBaslikLabel.ForeColor = System.Drawing.Color.Maroon;
                haftaBaslikLabel.Location = new System.Drawing.Point(18, 3);
                haftaBaslikLabel.Name = "hafta_baslik_label_" + i;
                haftaBaslikLabel.Size = new System.Drawing.Size(52, 17);
                haftaBaslikLabel.TabIndex = 0;
                haftaBaslikLabel.Text = (i + 1) + ".hafta";

                haftaPanelBaslik.Controls.Add(haftaBaslikLabel);

                for (int j = 0; j < haftadaki_panel_sayisi_lig2; j++)
                {   //musabaka Panalleri olusturuluyor
                    Panel musabakaPanel = new Panel();

                    musabakaPanel.BackColor = System.Drawing.Color.Maroon;
                    musabakaPanel.Location = new System.Drawing.Point(32 + (j * 242), 29);
                    musabakaPanel.Name = "hafta1_1";
                    musabakaPanel.Size = new System.Drawing.Size(236, 271);
                    musabakaPanel.TabIndex = 0;

                    haftaPanel.Controls.Add(musabakaPanel);

                    //musabaka icindeki labeller olusturuluyor

                    //A takim label
                    Label aTakimLabel = new Label();
                    aTakimLabel.AutoSize = true;
                    aTakimLabel.ForeColor = System.Drawing.Color.Yellow;
                    aTakimLabel.Location = new System.Drawing.Point(13, 12);
                    aTakimLabel.Name = "A_takim_1_1" + i + j;
                    aTakimLabel.Size = new System.Drawing.Size(46, 17);
                    aTakimLabel.TabIndex = 0;
                    aTakimLabel.Text = musabakalarLig2[index].ev_sahibi.ToString(); // A takim ********
                    musabakaPanel.Controls.Add(aTakimLabel);

                    // vs Label
                    Label vsLabel = new Label();
                    vsLabel.AutoSize = true;
                    vsLabel.Location = new System.Drawing.Point(101, 12);
                    vsLabel.Name = "vs_1_1" + i + j;
                    vsLabel.Size = new System.Drawing.Size(46, 17);
                    vsLabel.TabIndex = 1;
                    vsLabel.Text = "Vs";
                    musabakaPanel.Controls.Add(vsLabel);

                    //B takim label 
                    Label bTakimLabel = new Label();
                    bTakimLabel.AutoSize = true;
                    bTakimLabel.ForeColor = System.Drawing.Color.Yellow;
                    bTakimLabel.Location = new System.Drawing.Point(150, 12);
                    bTakimLabel.Name = "B_takim_1_1" + i + j;
                    bTakimLabel.Size = new System.Drawing.Size(46, 17);
                    bTakimLabel.TabIndex = 2;
                    bTakimLabel.Text = musabakalarLig2[index].misafir.ToString();  // B takim*********
                    musabakaPanel.Controls.Add(bTakimLabel);

                    //cizgiLabel

                    Label cizgiLabel = new Label();

                    cizgiLabel.AutoSize = true;
                    cizgiLabel.Location = new System.Drawing.Point(3, 40);
                    cizgiLabel.Name = "label4";
                    cizgiLabel.Size = new System.Drawing.Size(228, 17);
                    cizgiLabel.TabIndex = 0;
                    cizgiLabel.Text = "----------------------------------------------------------------------------";
                    musabakaPanel.Controls.Add(cizgiLabel);

                    // hakemGorevLabel
                    Label hakemGorevLabel = new Label();
                    hakemGorevLabel.AutoSize = true;
                    hakemGorevLabel.ForeColor = System.Drawing.Color.White;
                    hakemGorevLabel.Location = new System.Drawing.Point(81, 57);
                    hakemGorevLabel.Name = "gorevli_hakem_1_1" + i + j;
                    hakemGorevLabel.Size = new System.Drawing.Size(46, 17);
                    hakemGorevLabel.TabIndex = 3;
                    hakemGorevLabel.Text = "Görevli Hakemler";
                    musabakaPanel.Controls.Add(hakemGorevLabel);


                    // basHakemLabel
                    Label basHakemLabel = new Label();
                    basHakemLabel.AutoSize = true;
                    basHakemLabel.Location = new System.Drawing.Point(13, 84);
                    basHakemLabel.Name = "label5" + i + j;
                    basHakemLabel.Size = new System.Drawing.Size(46, 17);
                    basHakemLabel.TabIndex = 4;
                    basHakemLabel.Text = "Baş Hakem : ";
                    musabakaPanel.Controls.Add(basHakemLabel);


                    //yardimciHakemLabel
                    Label yardimciHakemLabel = new Label();
                    yardimciHakemLabel.AutoSize = true;
                    yardimciHakemLabel.Location = new System.Drawing.Point(13, 113);
                    yardimciHakemLabel.Name = "label6" + i + j;
                    yardimciHakemLabel.Size = new System.Drawing.Size(46, 17);
                    yardimciHakemLabel.TabIndex = 5;
                    yardimciHakemLabel.Text = "Yardımcı Hakem : ";
                    musabakaPanel.Controls.Add(yardimciHakemLabel);

                    //yaziciHakemLabel
                    Label yaziciHakemLabel = new Label();
                    yaziciHakemLabel.AutoSize = true;
                    yaziciHakemLabel.Location = new System.Drawing.Point(13, 139);
                    yaziciHakemLabel.Name = "label7" + i + j;
                    yaziciHakemLabel.Size = new System.Drawing.Size(46, 17);
                    yaziciHakemLabel.TabIndex = 6;
                    yaziciHakemLabel.Text = "Yazıcı Hakem : ";
                    musabakaPanel.Controls.Add(yaziciHakemLabel);


                    //cizgiHakem1Label
                    Label cizgiHakem1Label = new Label();
                    cizgiHakem1Label.AutoSize = true;
                    cizgiHakem1Label.Location = new System.Drawing.Point(13, 165);
                    cizgiHakem1Label.Name = "label8" + i + j;
                    cizgiHakem1Label.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem1Label.TabIndex = 7;
                    cizgiHakem1Label.Text = "Çizgi Hakem 1 : ";
                    musabakaPanel.Controls.Add(cizgiHakem1Label);

                    // //cizgiHakem2Label
                    Label cizgiHakem2Label = new Label();
                    cizgiHakem2Label.AutoSize = true;
                    cizgiHakem2Label.Location = new System.Drawing.Point(13, 191);
                    cizgiHakem2Label.Name = "label10";
                    cizgiHakem2Label.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem2Label.TabIndex = 8;
                    cizgiHakem2Label.Text = "Çizgi Hakem 2 :";
                    musabakaPanel.Controls.Add(cizgiHakem2Label);

                    //hakem Atamalari

                    // basHakemLabel
                    Label basHakemLabelA = new Label();
                    basHakemLabelA.AutoSize = true;
                    basHakemLabelA.Location = new System.Drawing.Point(110, 84);
                    basHakemLabelA.Name = "label5A" + i + j;
                    basHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    basHakemLabelA.TabIndex = 4;
                    basHakemLabelA.Text = musabakalarLig2[index].bas_hakem.ToString(); // bas hakem ********************
                    musabakaPanel.Controls.Add(basHakemLabelA);


                    //yardimciHakemLabel
                    Label yardimciHakemLabelA = new Label();
                    yardimciHakemLabelA.AutoSize = true;
                    yardimciHakemLabelA.Location = new System.Drawing.Point(110, 113);
                    yardimciHakemLabelA.Name = "label6A" + i + j;
                    yardimciHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    yardimciHakemLabelA.TabIndex = 5;
                    yardimciHakemLabelA.Text = musabakalarLig2[index].yardimci_hakem.ToString(); // yar hakem ********************
                    musabakaPanel.Controls.Add(yardimciHakemLabelA);

                    //yaziciHakemLabel
                    Label yaziciHakemLabelA = new Label();
                    yaziciHakemLabelA.AutoSize = true;
                    yaziciHakemLabelA.Location = new System.Drawing.Point(110, 139);
                    yaziciHakemLabelA.Name = "label7A" + i + j;
                    yaziciHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    yaziciHakemLabelA.TabIndex = 6;
                    yaziciHakemLabelA.Text = musabakalarLig2[index].yazi_hakemi.ToString(); // yazi hakem ********************
                    musabakaPanel.Controls.Add(yaziciHakemLabelA);


                    //cizgiHakem1Label
                    Label cizgiHakem1LabelA = new Label();
                    cizgiHakem1LabelA.AutoSize = true;
                    cizgiHakem1LabelA.Location = new System.Drawing.Point(110, 165);
                    cizgiHakem1LabelA.Name = "label8A" + i + j;
                    cizgiHakem1LabelA.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem1LabelA.TabIndex = 7;
                    cizgiHakem1LabelA.Text = musabakalarLig2[index].cizgi_hakem1.ToString();// cizgi1 hakem ********************
                    musabakaPanel.Controls.Add(cizgiHakem1LabelA);

                    // //cizgiHakem2Label
                    Label cizgiHakem2LabelA = new Label();
                    cizgiHakem2LabelA.AutoSize = true;
                    cizgiHakem2LabelA.Location = new System.Drawing.Point(110, 191);
                    cizgiHakem2LabelA.Name = "label10A" + i + j;
                    cizgiHakem2LabelA.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem2LabelA.TabIndex = 8;
                    cizgiHakem2LabelA.Text = musabakalarLig2[index].cizgi_hakem2.ToString(); ;// cizgi2 hakem ********************
                    musabakaPanel.Controls.Add(cizgiHakem2LabelA);

                    index++;
                }
            }
        }


        public void controlsBuildLig3()
        {
            int index = 0;
            for (int i = 0; i < panel_sayisi_lig3; i++)
            {


                //hafta panalleri olusturluyor
                Panel haftaPanel = new Panel();
                //panel ozellikleri belirle
                haftaPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

                haftaPanel.Location = new System.Drawing.Point(71, 79 + (i * 326));
                haftaPanel.Name = "panel3";
                haftaPanel.Size = new System.Drawing.Size(100 + (haftadaki_panel_sayisi_lig3 * 236), 310);
                haftaPanel.TabIndex = 7;

                containerPanelLig3.Controls.Add(haftaPanel);

                //hafta panel baslik olusturuluyor
                Panel haftaPanelBaslik = new Panel();

                haftaPanelBaslik.BackColor = System.Drawing.Color.Gray;
                haftaPanelBaslik.Location = new System.Drawing.Point(3, 3);
                haftaPanelBaslik.Name = "hafta_baslik_panel_1";
                haftaPanelBaslik.Size = new System.Drawing.Size(100 + (haftadaki_panel_sayisi_lig3 * 236), 20);
                haftaPanelBaslik.TabIndex = 5;

                haftaPanel.Controls.Add(haftaPanelBaslik);

                // hafta panel baslik label oluşturuluyor
                Label haftaBaslikLabel = new Label();

                haftaBaslikLabel.AutoSize = true;
                haftaBaslikLabel.ForeColor = System.Drawing.Color.Maroon;
                haftaBaslikLabel.Location = new System.Drawing.Point(18, 3);
                haftaBaslikLabel.Name = "hafta_baslik_label_" + i;
                haftaBaslikLabel.Size = new System.Drawing.Size(52, 17);
                haftaBaslikLabel.TabIndex = 0;
                haftaBaslikLabel.Text = (i + 1) + ".hafta";

                haftaPanelBaslik.Controls.Add(haftaBaslikLabel);

                for (int j = 0; j < haftadaki_panel_sayisi_lig3; j++)
                {   //musabaka Panalleri olusturuluyor
                    Panel musabakaPanel = new Panel();

                    musabakaPanel.BackColor = System.Drawing.Color.Maroon;
                    musabakaPanel.Location = new System.Drawing.Point(32 + (j * 242), 29);
                    musabakaPanel.Name = "hafta1_1";
                    musabakaPanel.Size = new System.Drawing.Size(236, 271);
                    musabakaPanel.TabIndex = 0;

                    haftaPanel.Controls.Add(musabakaPanel);

                    //musabaka icindeki labeller olusturuluyor

                    //A takim label
                    Label aTakimLabel = new Label();
                    aTakimLabel.AutoSize = true;
                    aTakimLabel.ForeColor = System.Drawing.Color.Yellow;
                    aTakimLabel.Location = new System.Drawing.Point(13, 12);
                    aTakimLabel.Name = "A_takim_1_1" + i + j;
                    aTakimLabel.Size = new System.Drawing.Size(46, 17);
                    aTakimLabel.TabIndex = 0;
                    aTakimLabel.Text = musabakalarLig3[index].ev_sahibi.ToString(); // A takim ********
                    musabakaPanel.Controls.Add(aTakimLabel);

                    // vs Label
                    Label vsLabel = new Label();
                    vsLabel.AutoSize = true;
                    vsLabel.Location = new System.Drawing.Point(101, 12);
                    vsLabel.Name = "vs_1_1" + i + j;
                    vsLabel.Size = new System.Drawing.Size(46, 17);
                    vsLabel.TabIndex = 1;
                    vsLabel.Text = "Vs";
                    musabakaPanel.Controls.Add(vsLabel);

                    //B takim label 
                    Label bTakimLabel = new Label();
                    bTakimLabel.AutoSize = true;
                    bTakimLabel.ForeColor = System.Drawing.Color.Yellow;
                    bTakimLabel.Location = new System.Drawing.Point(150, 12);
                    bTakimLabel.Name = "B_takim_1_1" + i + j;
                    bTakimLabel.Size = new System.Drawing.Size(46, 17);
                    bTakimLabel.TabIndex = 2;
                    bTakimLabel.Text = musabakalarLig3[index].misafir.ToString();  // B takim*********
                    musabakaPanel.Controls.Add(bTakimLabel);

                    //cizgiLabel

                    Label cizgiLabel = new Label();

                    cizgiLabel.AutoSize = true;
                    cizgiLabel.Location = new System.Drawing.Point(3, 40);
                    cizgiLabel.Name = "label4";
                    cizgiLabel.Size = new System.Drawing.Size(228, 17);
                    cizgiLabel.TabIndex = 0;
                    cizgiLabel.Text = "----------------------------------------------------------------------------";
                    musabakaPanel.Controls.Add(cizgiLabel);

                    // hakemGorevLabel
                    Label hakemGorevLabel = new Label();
                    hakemGorevLabel.AutoSize = true;
                    hakemGorevLabel.ForeColor = System.Drawing.Color.White;
                    hakemGorevLabel.Location = new System.Drawing.Point(81, 57);
                    hakemGorevLabel.Name = "gorevli_hakem_1_1" + i + j;
                    hakemGorevLabel.Size = new System.Drawing.Size(46, 17);
                    hakemGorevLabel.TabIndex = 3;
                    hakemGorevLabel.Text = "Görevli Hakemler";
                    musabakaPanel.Controls.Add(hakemGorevLabel);


                    // basHakemLabel
                    Label basHakemLabel = new Label();
                    basHakemLabel.AutoSize = true;
                    basHakemLabel.Location = new System.Drawing.Point(13, 84);
                    basHakemLabel.Name = "label5" + i + j;
                    basHakemLabel.Size = new System.Drawing.Size(46, 17);
                    basHakemLabel.TabIndex = 4;
                    basHakemLabel.Text = "Baş Hakem : ";
                    musabakaPanel.Controls.Add(basHakemLabel);


                    //yardimciHakemLabel
                    Label yardimciHakemLabel = new Label();
                    yardimciHakemLabel.AutoSize = true;
                    yardimciHakemLabel.Location = new System.Drawing.Point(13, 113);
                    yardimciHakemLabel.Name = "label6" + i + j;
                    yardimciHakemLabel.Size = new System.Drawing.Size(46, 17);
                    yardimciHakemLabel.TabIndex = 5;
                    yardimciHakemLabel.Text = "Yardımcı Hakem : ";
                    musabakaPanel.Controls.Add(yardimciHakemLabel);

                    //yaziciHakemLabel
                    Label yaziciHakemLabel = new Label();
                    yaziciHakemLabel.AutoSize = true;
                    yaziciHakemLabel.Location = new System.Drawing.Point(13, 139);
                    yaziciHakemLabel.Name = "label7" + i + j;
                    yaziciHakemLabel.Size = new System.Drawing.Size(46, 17);
                    yaziciHakemLabel.TabIndex = 6;
                    yaziciHakemLabel.Text = "Yazıcı Hakem : ";
                    musabakaPanel.Controls.Add(yaziciHakemLabel);


                    //cizgiHakem1Label
                    Label cizgiHakem1Label = new Label();
                    cizgiHakem1Label.AutoSize = true;
                    cizgiHakem1Label.Location = new System.Drawing.Point(13, 165);
                    cizgiHakem1Label.Name = "label8" + i + j;
                    cizgiHakem1Label.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem1Label.TabIndex = 7;
                    cizgiHakem1Label.Text = "Çizgi Hakem 1 : ";
                    musabakaPanel.Controls.Add(cizgiHakem1Label);

                    // //cizgiHakem2Label
                    Label cizgiHakem2Label = new Label();
                    cizgiHakem2Label.AutoSize = true;
                    cizgiHakem2Label.Location = new System.Drawing.Point(13, 191);
                    cizgiHakem2Label.Name = "label10";
                    cizgiHakem2Label.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem2Label.TabIndex = 8;
                    cizgiHakem2Label.Text = "Çizgi Hakem 2 :";
                    musabakaPanel.Controls.Add(cizgiHakem2Label);

                    //hakem Atamalari

                    // basHakemLabel
                    Label basHakemLabelA = new Label();
                    basHakemLabelA.AutoSize = true;
                    basHakemLabelA.Location = new System.Drawing.Point(110, 84);
                    basHakemLabelA.Name = "label5A" + i + j;
                    basHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    basHakemLabelA.TabIndex = 4;
                    basHakemLabelA.Text = musabakalarLig3[index].bas_hakem.ToString(); // bas hakem ********************
                    musabakaPanel.Controls.Add(basHakemLabelA);


                    //yardimciHakemLabel
                    Label yardimciHakemLabelA = new Label();
                    yardimciHakemLabelA.AutoSize = true;
                    yardimciHakemLabelA.Location = new System.Drawing.Point(110, 113);
                    yardimciHakemLabelA.Name = "label6A" + i + j;
                    yardimciHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    yardimciHakemLabelA.TabIndex = 5;
                    yardimciHakemLabelA.Text = musabakalarLig3[index].yardimci_hakem.ToString(); // yar hakem ********************
                    musabakaPanel.Controls.Add(yardimciHakemLabelA);

                    //yaziciHakemLabel
                    Label yaziciHakemLabelA = new Label();
                    yaziciHakemLabelA.AutoSize = true;
                    yaziciHakemLabelA.Location = new System.Drawing.Point(110, 139);
                    yaziciHakemLabelA.Name = "label7A" + i + j;
                    yaziciHakemLabelA.Size = new System.Drawing.Size(46, 17);
                    yaziciHakemLabelA.TabIndex = 6;
                    yaziciHakemLabelA.Text = musabakalarLig3[index].yazi_hakemi.ToString(); // yazi hakem ********************
                    musabakaPanel.Controls.Add(yaziciHakemLabelA);


                    //cizgiHakem1Label
                    Label cizgiHakem1LabelA = new Label();
                    cizgiHakem1LabelA.AutoSize = true;
                    cizgiHakem1LabelA.Location = new System.Drawing.Point(110, 165);
                    cizgiHakem1LabelA.Name = "label8A" + i + j;
                    cizgiHakem1LabelA.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem1LabelA.TabIndex = 7;
                    cizgiHakem1LabelA.Text = musabakalarLig3[index].cizgi_hakem1.ToString();// cizgi1 hakem ********************
                    musabakaPanel.Controls.Add(cizgiHakem1LabelA);

                    // //cizgiHakem2Label
                    Label cizgiHakem2LabelA = new Label();
                    cizgiHakem2LabelA.AutoSize = true;
                    cizgiHakem2LabelA.Location = new System.Drawing.Point(110, 191);
                    cizgiHakem2LabelA.Name = "label10A" + i + j;
                    cizgiHakem2LabelA.Size = new System.Drawing.Size(46, 17);
                    cizgiHakem2LabelA.TabIndex = 8;
                    cizgiHakem2LabelA.Text = musabakalarLig3[index].cizgi_hakem2.ToString(); ;// cizgi2 hakem ********************
                    musabakaPanel.Controls.Add(cizgiHakem2LabelA);

                    index++;
                }
            }
        }


        private void FiksturFormm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testtcs f = new testtcs();
            f.Show();
            this.Hide();
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
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].update(this._log);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void containerPanelLig1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
