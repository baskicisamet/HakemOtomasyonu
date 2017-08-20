using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev1
{
    class FiksturConfiguration
    {
        sporEntities _db = new sporEntities();

        List<TakimTmp> takimlar; // bu takimlari altta liglere gore ayristir
        List<TakimTmp> takimlar_lig1;
        List<TakimTmp> takimlar_lig2;
        List<TakimTmp> takimlar_lig3;


        List<hakem> hakemler = new List<hakem>(); // bu hakemleri alt lig ve turlerine gore ayristir
        List<hakem> bas_hakemler;
        List<hakem> bas_hakemler_lig1;
        List<hakem> bas_hakemler_lig2;
        List<hakem> bas_hakemler_lig3;
        List<hakem> yazi_hakemler;
        List<hakem> yazi_hakemler_lig1;
        List<hakem> yazi_hakemler_lig2;
        List<hakem> yazi_hakemler_lig3;
        List<hakem> yardimci_hakemler;
        List<hakem> yardimci_hakemler_lig1;
        List<hakem> yardimci_hakemler_lig2;
        List<hakem> yardimci_hakemler_lig3;
        List<hakem> cizgi_hakemler;
        List<hakem> cizgi_hakemler_lig1;
        List<hakem> cizgi_hakemler_lig2;
        List<hakem> cizgi_hakemler_lig3;

        List<musabaka> musabakalar_lig1;
        List<musabaka> musabakalar_lig2;
        List<musabaka> musabakalar_lig3;

        int takim_sayisi_lig1;
        int toplam_mac_sayisi_lig1;
        int haftadaki_mac_sayisi_lig1;
        int toplam_hafta_lig1;
        int devredeki_hafta_sayisi_lig1;
        int takim_sayisi_lig2;
        int toplam_mac_sayisi_lig2;
        int haftadaki_mac_sayisi_lig2;
        int toplam_hafta_lig2;
        int devredeki_hafta_sayisi_lig2;
        int takim_sayisi_lig3;
        int toplam_mac_sayisi_lig3;
        int haftadaki_mac_sayisi_lig3;
        int toplam_hafta_lig3;
        int devredeki_hafta_sayisi_lig3;


        public FiksturConfiguration()
        {
            takimlar = new List<TakimTmp>();
            takimlar_lig1 = new List<TakimTmp>();
            takimlar_lig2 = new List<TakimTmp>();
            takimlar_lig3 = new List<TakimTmp>();

            bas_hakemler = new List<hakem>();
            bas_hakemler_lig1 = new List<hakem>();
            bas_hakemler_lig2 = new List<hakem>();
            bas_hakemler_lig3 = new List<hakem>();
            yazi_hakemler = new List<hakem>();
            yazi_hakemler_lig1 = new List<hakem>();
            yazi_hakemler_lig2 = new List<hakem>();
            yazi_hakemler_lig3 = new List<hakem>();
            yardimci_hakemler = new List<hakem>();
            yardimci_hakemler_lig1 = new List<hakem>();
            yardimci_hakemler_lig2 = new List<hakem>();
            yardimci_hakemler_lig3 = new List<hakem>();
            cizgi_hakemler = new List<hakem>();
            cizgi_hakemler_lig1 = new List<hakem>();
            cizgi_hakemler_lig2 = new List<hakem>();
            cizgi_hakemler_lig3 = new List<hakem>();

            musabakalar_lig1 = new List<musabaka>();
            musabakalar_lig2 = new List<musabaka>();
            musabakalar_lig3 = new List<musabaka>();


            //Fill List
            hakemCek();
            takimCek();
            hakemAyristir();
            takimAyristir();

            //formülleri hesapla
            takim_sayisi_lig1 = takimlar_lig1.Count;
            toplam_mac_sayisi_lig1 = (takim_sayisi_lig1) * (takim_sayisi_lig1 - 1);
            haftadaki_mac_sayisi_lig1 = takim_sayisi_lig1 / 2;
            toplam_hafta_lig1 = toplam_mac_sayisi_lig1 / haftadaki_mac_sayisi_lig1;
            devredeki_hafta_sayisi_lig1 = toplam_hafta_lig1 / 2;

            takim_sayisi_lig2 = takimlar_lig2.Count;
            toplam_mac_sayisi_lig2 = (takim_sayisi_lig2) * (takim_sayisi_lig2 - 1);
            haftadaki_mac_sayisi_lig2 = takim_sayisi_lig2 / 2;
            toplam_hafta_lig2 = toplam_mac_sayisi_lig2 / haftadaki_mac_sayisi_lig2;
            devredeki_hafta_sayisi_lig2 = toplam_hafta_lig2 / 2;


            takim_sayisi_lig3 = takimlar_lig3.Count;
            toplam_mac_sayisi_lig3 = (takim_sayisi_lig3) * (takim_sayisi_lig3 - 1);
            haftadaki_mac_sayisi_lig3 = takim_sayisi_lig3 / 2;
            toplam_hafta_lig3 = toplam_mac_sayisi_lig3 / haftadaki_mac_sayisi_lig3;
            devredeki_hafta_sayisi_lig3 = toplam_hafta_lig3 / 2;



        }

        public void takimCek()
        {

            //takim_doldur
            using (var _db = new sporEntities())
            {
                /*var tmp = (from t in _db.takim

                           select new { t });

                takimlar = (List<takim>)tmp;
                 * */

                var tmp = (from t in _db.takim


                           select new { t.t_adi, t.lig.l_adi, t.sporsalonu.s_adi }).ToList();

                // listeye dolduruluyor takimlar
                for (int i = 0; i < tmp.Count; i++)
                {
                    TakimTmp takimtmp = new TakimTmp();
                    takimtmp.setAd(tmp[i].t_adi);
                    takimtmp.setLig(tmp[i].l_adi);
                    takimtmp.setSalon(tmp[i].s_adi);

                    takimlar.Add(takimtmp);

                }

            }


        }

        public void hakemCek()
        {

            using (var _db = new sporEntities())
            {
                var tmp = (from h in _db.hakem

                           select new { h.hakem_adi, h.hakem_soyadi, h.hakem_turu, h.hakem_classman }).ToList();



                // listeye dolduruluyor takimlar
                for (int i = 0; i < tmp.Count; i++)
                {
                    hakem hakem_tmp = new hakem();

                    hakem_tmp.hakem_adi = tmp[i].hakem_adi;
                    hakem_tmp.hakem_soyadi = tmp[i].hakem_soyadi;
                    hakem_tmp.hakem_turu = tmp[i].hakem_turu;
                    hakem_tmp.hakem_classman = tmp[i].hakem_classman;

                    hakemler.Add(hakem_tmp);

                }






            }

        }

        public void takimAyristir()
        {

            foreach (TakimTmp t in takimlar)
            {

                switch (t.getLig())// burdan devammmm . . . . .  .. . . . . .. .!!!111!!!11
                {
                    case "1.lig": takimlar_lig1.Add(t);
                        break;
                    case "2.lig": takimlar_lig2.Add(t);
                        break;
                    case "3.lig": takimlar_lig3.Add(t);
                        break;

                }
            }
        }

        public void hakemAyristir()
        {
            foreach (hakem h in hakemler)
            {

                if (h.hakem_classman == "1.lig")
                {

                    if (h.hakem_turu == "baş hakem") { bas_hakemler_lig1.Add(h); }
                    else if (h.hakem_turu == "yardımcı hakem") { yardimci_hakemler_lig1.Add(h); }
                    else if (h.hakem_turu == "yazıcı hakem") { yazi_hakemler_lig1.Add(h); }
                    else if (h.hakem_turu == "çizgi hakemi") { cizgi_hakemler_lig1.Add(h); }
                }
                else if (h.hakem_classman == "2.lig")
                {

                    if (h.hakem_turu == "baş hakem") { bas_hakemler_lig2.Add(h); }
                    else if (h.hakem_turu == "yardımcı hakem") { yardimci_hakemler_lig2.Add(h); }
                    else if (h.hakem_turu == "yazıcı hakem") { yazi_hakemler_lig2.Add(h); }
                    else if (h.hakem_turu == "çizgi hakemi") { cizgi_hakemler_lig2.Add(h); }
                }
                else if (h.hakem_classman == "3.lig")
                {
                    if (h.hakem_turu == "baş hakem") { bas_hakemler_lig3.Add(h); }
                    else if (h.hakem_turu == "yardımcı hakem") { yardimci_hakemler_lig3.Add(h); }
                    else if (h.hakem_turu == "yazıcı hakem") { yazi_hakemler_lig3.Add(h); }
                    else if (h.hakem_turu == "çizgi hakemi") { cizgi_hakemler_lig3.Add(h); }
                }

            }
        }

        public List<TakimTmp> takimKar(List<TakimTmp> l)
        {
            // verilen listeyi karicak

            return l;
        }

        public void Lig1TakimEslestir()
        {

            musabakalar_lig1.Clear();

            // 1.lig icin
            for (int i = 1; i <= devredeki_hafta_sayisi_lig1; i++)
            {
                for (int j = 0; j < haftadaki_mac_sayisi_lig1; j++)
                {
                    
                    musabaka _musabaka = new musabaka();

                  
                    _musabaka.ev_sahibi = takimlar_lig1[j].getAd();
                    
                    _musabaka.misafir = takimlar_lig1[(takim_sayisi_lig1) - (j+1)].getAd();
                    _musabaka.salon = takimlar_lig1[j].getSalon();
                    _musabaka.hafta = i.ToString();
                    _musabaka.lig = "1.lig";

                    musabakalar_lig1.Add(_musabaka);
                }

                //sonraki haftaya gectigimizde pozisyonlarin degismesi icin
                TakimTmp tmp = takimlar_lig1[takim_sayisi_lig1-1];
                for (int j = takim_sayisi_lig1 - 1; j > 1; j--)
                {
                    takimlar_lig1[j] = takimlar_lig1[j-1];
                }
                takimlar_lig1[1] = tmp;

                //lig1 bitti

            }

        }

        public void lig1TakimEslestirDevre2()
        {
            int index =0;
            int kacinci_hafta;
            for (int i = 1; i <= devredeki_hafta_sayisi_lig1; i++)
            {
                for (int j = 0; j < haftadaki_mac_sayisi_lig1; j++)
                {
                    musabaka _musabaka = new musabaka();
                    _musabaka.ev_sahibi = musabakalar_lig1[index].misafir;
                    _musabaka.misafir = musabakalar_lig1[index].ev_sahibi;
                    _musabaka.lig = musabakalar_lig1[index].lig;

                    kacinci_hafta = Int32.Parse(musabakalar_lig1[index].hafta)+devredeki_hafta_sayisi_lig1;
                    _musabaka.hafta = kacinci_hafta.ToString();
                    _musabaka.salon = musabakalar_lig1[index].salon;

                    musabakalar_lig1.Add(_musabaka);

                    index++;
                }
            }
        }

        public void Lig2TakimEslestir()
        {
            musabakalar_lig2.Clear();
            

            // 2.lig icin
            for (int i = 1; i <= devredeki_hafta_sayisi_lig2; i++)
            {
                for (int j = 0; j < haftadaki_mac_sayisi_lig2; j++)
                {

                    musabaka _musabaka = new musabaka();


                    _musabaka.ev_sahibi = takimlar_lig2[j].getAd();

                    _musabaka.misafir = takimlar_lig2[(takim_sayisi_lig2) - (j + 1)].getAd();
                    _musabaka.salon = takimlar_lig2[j].getSalon();
                    _musabaka.hafta = i.ToString();
                    _musabaka.lig = "2.lig";

                    musabakalar_lig2.Add(_musabaka);
                }

                //sonraki haftaya gectigimizde pozisyonlarin degismesi icin
                TakimTmp tmp = takimlar_lig2[takim_sayisi_lig2 - 1];
                for (int j = takim_sayisi_lig2 - 1; j > 1; j--)
                {
                    takimlar_lig2[j] = takimlar_lig2[j - 1];
                }
                takimlar_lig2[1] = tmp;

                //lig2 bitti

            }


        }


        public void lig2TakimEslestirDevre2()
        {
            int index = 0;
            int kacinci_hafta;
            for (int i = 1; i <= devredeki_hafta_sayisi_lig2; i++)
            {
                for (int j = 0; j < haftadaki_mac_sayisi_lig2; j++)
                {
                    musabaka _musabaka = new musabaka();
                    _musabaka.ev_sahibi = musabakalar_lig2[index].misafir;
                    _musabaka.misafir = musabakalar_lig2[index].ev_sahibi;
                    _musabaka.lig = musabakalar_lig2[index].lig;

                    kacinci_hafta = Int32.Parse(musabakalar_lig2[index].hafta) + devredeki_hafta_sayisi_lig2;
                    _musabaka.hafta = kacinci_hafta.ToString();
                    _musabaka.salon = musabakalar_lig2[index].salon;

                    musabakalar_lig2.Add(_musabaka);

                    index++;
                }
            }
        }


        public void Lig3TakimEslestir()
        {
            musabakalar_lig3.Clear();


            // 2.lig icin
            for (int i = 1; i <= devredeki_hafta_sayisi_lig3; i++)
            {
                for (int j = 0; j < haftadaki_mac_sayisi_lig3; j++)
                {

                    musabaka _musabaka = new musabaka();


                    _musabaka.ev_sahibi = takimlar_lig3[j].getAd();

                    _musabaka.misafir = takimlar_lig3[(takim_sayisi_lig3) - (j + 1)].getAd();
                    _musabaka.salon = takimlar_lig3[j].getSalon();
                    _musabaka.hafta = i.ToString();
                    _musabaka.lig = "3.lig";

                    musabakalar_lig3.Add(_musabaka);
                }

                //sonraki haftaya gectigimizde pozisyonlarin degismesi icin
                TakimTmp tmp = takimlar_lig3[takim_sayisi_lig3 - 1];
                for (int j = takim_sayisi_lig3 - 1; j > 1; j--)
                {
                    takimlar_lig3[j] = takimlar_lig3[j - 1];
                }
                takimlar_lig3[1] = tmp;

                //lig3 bitti

            }


        }



        public void lig3TakimEslestirDevre2()
        {
            int index = 0;
            int kacinci_hafta;
            for (int i = 1; i <= devredeki_hafta_sayisi_lig3; i++)
            {
                for (int j = 0; j < haftadaki_mac_sayisi_lig3; j++)
                {
                    musabaka _musabaka = new musabaka();
                    _musabaka.ev_sahibi = musabakalar_lig3[index].misafir;
                    _musabaka.misafir = musabakalar_lig3[index].ev_sahibi;
                    _musabaka.lig = musabakalar_lig3[index].lig;

                    kacinci_hafta = Int32.Parse(musabakalar_lig3[index].hafta) + devredeki_hafta_sayisi_lig3;
                    _musabaka.hafta = kacinci_hafta.ToString();
                    _musabaka.salon = musabakalar_lig3[index].salon;

                    musabakalar_lig3.Add(_musabaka);

                    index++;
                }
            }
        }

        public int getLig1HaftaSayisi()
        {
            return devredeki_hafta_sayisi_lig1;
        }
        public int getLig2HaftaSayisi()
        {
            return devredeki_hafta_sayisi_lig2;
        }

        public int getLig3HaftaSayisi()
        {
            return devredeki_hafta_sayisi_lig3;
        }

        public int getLig1HaftadakiMacSayisi()
        {
            return haftadaki_mac_sayisi_lig1;
        }

        public int getLig2HaftadakiMacSayisi()
        {
            return haftadaki_mac_sayisi_lig2;
        }

        public int getLig3HaftadakiMacSayisi()
        {
            return haftadaki_mac_sayisi_lig3;
        }


        public List<musabaka> getMusabakalarLig1()
        {

            return this.musabakalar_lig1;
        }

        public List<musabaka> getMusabakalarLig2()
        {

            return this.musabakalar_lig2;
        }

        public List<musabaka> getMusabakalarLig3()
        {

            return this.musabakalar_lig3;
        }


        public void hakemAtaLig1()
        {
            int index = 0;
            
            for (int i = 0; i < devredeki_hafta_sayisi_lig1*2;i++ )
            {

                for (int j = 0; j < haftadaki_mac_sayisi_lig1;j++ )
                {
                   
                    musabakalar_lig1[index].bas_hakem = bas_hakemler_lig1[j].hakem_adi + bas_hakemler_lig1[j].hakem_soyadi; // bas hakemler ataniyor
                    musabakalar_lig1[index].yardimci_hakem = yardimci_hakemler_lig1[j].hakem_adi + yardimci_hakemler_lig1[j].hakem_soyadi; // yardimci hakemler ataniyor
                    musabakalar_lig1[index].yazi_hakemi = yazi_hakemler_lig1[j].hakem_adi + yazi_hakemler_lig1[j].hakem_soyadi; // yazi hakemler ataniyor
                    musabakalar_lig1[index].cizgi_hakem1 = cizgi_hakemler_lig1[j * 2].hakem_adi + cizgi_hakemler_lig1[j * 2].hakem_soyadi; // cizgi1 hakemler ataniyor
                    musabakalar_lig1[index].cizgi_hakem2 = cizgi_hakemler_lig1[j * 2 + 1].hakem_adi + cizgi_hakemler_lig1[(j * 2) + 1].hakem_soyadi; // cizgi2 hakemler ataniyor
                   
                    
                    
                    index++;
                }
            }
            
        }


        public void hakemAtaLig2()
        {

            int index = 0;
            
            for (int i = 0; i < devredeki_hafta_sayisi_lig2 * 2; i++)
            {

                for (int j = 0; j < haftadaki_mac_sayisi_lig2; j++)
                {

                    musabakalar_lig2[index].bas_hakem = bas_hakemler_lig2[j].hakem_adi + bas_hakemler_lig2[j].hakem_soyadi; // bas hakemler ataniyor
                    musabakalar_lig2[index].yardimci_hakem = yardimci_hakemler_lig2[j].hakem_adi + yardimci_hakemler_lig2[j].hakem_soyadi; // yardimci hakemler ataniyor
                    musabakalar_lig2[index].yazi_hakemi = yazi_hakemler_lig2[j].hakem_adi + yazi_hakemler_lig2[j].hakem_soyadi; // yazi hakemler ataniyor
                    musabakalar_lig2[index].cizgi_hakem1 = cizgi_hakemler_lig2[j * 2].hakem_adi + cizgi_hakemler_lig2[j * 2].hakem_soyadi; // cizgi1 hakemler ataniyor
                    musabakalar_lig2[index].cizgi_hakem2 = cizgi_hakemler_lig2[j * 2 + 1].hakem_adi + cizgi_hakemler_lig2[(j * 2) + 1].hakem_soyadi; // cizgi2 hakemler ataniyor



                    index++;
                }
            }

        }

        public void hakemAtaLig3()
        {

            int index = 0;
            
            for (int i = 0; i < devredeki_hafta_sayisi_lig3 * 2; i++)
            {

                for (int j = 0; j < haftadaki_mac_sayisi_lig3; j++)
                {
                   
                    musabakalar_lig3[index].bas_hakem = bas_hakemler_lig3[j].hakem_adi + bas_hakemler_lig3[j].hakem_soyadi; // bas hakemler ataniyor
                    musabakalar_lig3[index].yardimci_hakem = yardimci_hakemler_lig3[j].hakem_adi + yardimci_hakemler_lig3[j].hakem_soyadi; // yardimci hakemler ataniyor
                    musabakalar_lig3[index].yazi_hakemi = yazi_hakemler_lig3[j].hakem_adi + yazi_hakemler_lig3[j].hakem_soyadi; // yazi hakemler ataniyor
                    musabakalar_lig3[index].cizgi_hakem1 = cizgi_hakemler_lig3[j * 2].hakem_adi + cizgi_hakemler_lig3[j * 2].hakem_soyadi; // cizgi1 hakemler ataniyor
                    musabakalar_lig3[index].cizgi_hakem2 = cizgi_hakemler_lig3[j * 2 + 1].hakem_adi + cizgi_hakemler_lig3[(j * 2) + 1].hakem_soyadi; // cizgi2 hakemler ataniyor

                    

                    index++;
                }
            }

        }




        public void fiksturKaydetLig1()
        {
            //lig1 deki musabakalar db ye kaydet
            foreach(musabaka m in musabakalar_lig1){

                using (_db = new sporEntities())
                {

                    _db.musabaka.Add(m);
                 _db.SaveChanges();
                }

           }
        }


        public void fiksturKaydetLig2()
        {
            //lig1 deki musabakalar db ye kaydet
            foreach (musabaka m in musabakalar_lig2)
            {

                using (_db = new sporEntities())
                {

                    _db.musabaka.Add(m);
                    _db.SaveChanges();
                }

            }
        }

        public void fiksturKaydetLig3()
        {
            //lig1 deki musabakalar db ye kaydet
            foreach (musabaka m in musabakalar_lig3)
            {

                using (_db = new sporEntities())
                {

                    _db.musabaka.Add(m);
                    _db.SaveChanges();
                }

            }
        }

        public List<musabaka> getFiksturLig1()
        {
            List<musabaka> _musabakalar = new List<musabaka>();
            using (var _db = new sporEntities())
            {
                var tmp = (from m in _db.musabaka
                           where m.lig == "1.lig"
                           select m).ToList();

                // listeye dolduruluyor takimlar
                for (int i = 0; i < tmp.Count; i++)
                {
                    musabaka musabaka_tmp = new musabaka();
                    musabaka_tmp = (musabaka)tmp[i];
                    _musabakalar.Add(musabaka_tmp);
                }
            }
            return _musabakalar;
        }

        public List<musabaka> getFiksturLig2()
        {
            List<musabaka> _musabakalar = new List<musabaka>();
            using (var _db = new sporEntities())
            {
                var tmp = (from m in _db.musabaka
                           where m.lig == "2.lig"
                           select m).ToList();

                // listeye dolduruluyor takimlar
                for (int i = 0; i < tmp.Count; i++)
                {
                    musabaka musabaka_tmp = new musabaka();
                    musabaka_tmp = (musabaka)tmp[i];
                    _musabakalar.Add(musabaka_tmp);
                }
            }
            return _musabakalar;
        }

        public List<musabaka> getFiksturLig3()
        { 
            List<musabaka> _musabakalar = new List<musabaka>();
            using (var _db = new sporEntities())
            {
                var tmp = (from m in _db.musabaka
                           where m.lig == "3.lig"
                           select m).ToList();

                // listeye dolduruluyor takimlar
                for (int i = 0; i < tmp.Count; i++)
                {
                    musabaka musabaka_tmp = new musabaka();
                    musabaka_tmp = (musabaka)tmp[i];
                    _musabakalar.Add(musabaka_tmp);
                }
            }
            return _musabakalar;
        }

    }
}
