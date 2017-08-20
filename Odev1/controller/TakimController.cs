using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
    class TakimController
    {


        sporEntities _db = new sporEntities();
        public void ekle(String _adi, String _lig,String _salon)
        {
            using (_db = new sporEntities())
            {
                takim t = new takim();

                t.t_adi = _adi;
                
                t.l_id = _db.lig.First(x => x.l_adi == _lig).l_id;
                t.s_id = _db.sporsalonu.First(x => x.s_adi == _salon).s_id;
                
                _db.takim.Add(t);
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


        public dynamic salonListele()
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from s in _db.sporsalonu
                           orderby s.s_id ascending
                           select s.s_adi).ToList();
                return tmp;
            }


        }


        public dynamic arama(string _takim)
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from t in _db.takim
                           where t.t_adi.Contains(_takim)
                           orderby t.t_id ascending
                           select new { t.t_id, t.t_adi,t.lig.l_adi, t.sporsalonu.s_adi  }).ToList();
                return tmp;
            }


        }

        public void duzenle(int _takimId, string _adi, string _lig, string _salon)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.takim.Where(x => x.t_id == _takimId).Select(x => x).First();
                if (deger != null)
                {
                    deger.t_adi = _adi;
                    
                    
                    deger.l_id = _db.lig.First(x => x.l_adi == _lig).l_id;
                    deger.s_id = _db.sporsalonu.First(x => x.s_adi == _salon).s_id;

                    _db.SaveChanges();
                }
            }
        }

        public void sil(int _takimId)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.takim.Where(x => x.t_id == _takimId).Select(x => x).FirstOrDefault();
                if (deger != null)
                {
                    _db.takim.Remove(deger);
                    _db.SaveChanges();

                }
            }

        }

    }
}
