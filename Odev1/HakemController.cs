using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
    class HakemController
    { 

        sporEntities _db = new sporEntities();


      
       
        
        
        public void ekle(hakem h)
        {
            using (_db = new sporEntities())
            {
                
                _db.hakem.Add(h);
                _db.SaveChanges();
            }

        }

        

        public dynamic hakemTuruListele()
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from h in _db.hakem
                           orderby h.hakem_id ascending
                           select h.hakem_turu).ToList();
                return tmp;
            }


        }



        public dynamic hakemClassmanListele()
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from l in _db.lig
                           orderby l.l_id ascending
                           select l.l_adi).ToList();
                return tmp;
            }


        }



       /* public dynamic hakemBolgeListele()
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from h in _db.hakem
                           orderby h.hakem_id ascending
                           select h.hakem_bolge).ToList();
                return tmp;
            }


        }
        */

        public dynamic arama(string _hakem)
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from h in _db.hakem
                           where h.hakem_adi.Contains(_hakem)
                           orderby h.hakem_id ascending
                           select new { h.hakem_id, h.hakem_adi, h.hakem_soyadi, h.hakem_turu, h.hakem_classman,h.hakem_bolge }).ToList();
                return tmp;
            }


        }

        public void duzenle(int _hakemId, string _hakemAdi, string _hakemSoyadi, string _hakemTuru, string _hakemClassman, string _hakemBolge)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.hakem.Where(x => x.hakem_id == _hakemId).Select(x => x).First();
                if (deger != null)
                {
                    deger.hakem_adi = _hakemAdi;
                    deger.hakem_soyadi = _hakemSoyadi;
                    deger.hakem_turu = _hakemTuru;
                    deger.hakem_classman = _hakemClassman;
                    deger.hakem_bolge = _hakemBolge;
                    _db.SaveChanges();
                }
            }
        }

        public void sil(int _hakemId)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.hakem.Where(x => x.hakem_id == _hakemId).Select(x => x).FirstOrDefault();
                if (deger != null)
                {
                    _db.hakem.Remove(deger);
                    _db.SaveChanges();

                }
            }

        } 
        
    }
}
