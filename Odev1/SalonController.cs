using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
    class SalonController
    {

        sporEntities _db = new sporEntities();



     
        public void ekle(string _adi, string _sehir, string _lig, string _ozellik)
        {
            using (_db = new sporEntities())
            {
                sporsalonu s = new sporsalonu();
                s.s_adi = _adi;
                s.ozellik = _ozellik;
                s.l_id = _db.lig.First(x => x.l_adi == _lig).l_id;
                s.s_sehir = _sehir;
                _db.sporsalonu.Add(s);
                _db.SaveChanges();
            }

        }


        public dynamic ligListele()
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from l in _db.lig
                           orderby l.l_id ascending
                           select l.l_adi).ToList();
                return tmp;
            }


        }



        public dynamic arama(string _salon)
        {

            
            using (var _db = new sporEntities())
            {

               
                var tmp = (from s in _db.sporsalonu
                           where s.s_adi.Contains(_salon)
                           orderby s.s_id ascending
                           select new { s.s_id, s.s_adi, s.s_sehir, s.lig.l_adi, s.ozellik }).ToList();
                return tmp;
            }


        }


        public void duzenle(int _salonId, string _adi, string _sehir, string _lig, string _ozellik)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.sporsalonu.Where(x => x.s_id == _salonId).Select(x => x).First();
                if (deger != null)
                {
                    deger.s_adi = _adi;
                    deger.s_sehir = _sehir;
                    deger.ozellik = _ozellik;
                    deger.l_id = _db.lig.First(x => x.l_adi == _lig).l_id;
                    _db.SaveChanges();
                }
            }
        }




        public void sil(int _salonId)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.sporsalonu.Where(x => x.s_id == _salonId).Select(x => x).FirstOrDefault();
                if (deger != null)
                {
                    _db.sporsalonu.Remove(deger);
                    _db.SaveChanges();

                }
            }

        }
        
    }
}
