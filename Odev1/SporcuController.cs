using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
    class SporcuController
    {
        sporEntities _db = new sporEntities();
        public void ekle(string _adi,string _soyadi,string _lig,string _ozellik)
        {
           using( _db = new sporEntities()){
               sporcu s = new sporcu();

                s.adi=_adi;
                s.ozellik =_ozellik;
                s.l_id = _db.lig.First(x=>x.l_adi==_lig).l_id;
                s.soyadi = _soyadi;
               _db.sporcu.Add(s);
               _db.SaveChanges();
                
                
           }
            

        }


        public void deleteAllMusabaka()
        {

            _db.Database.ExecuteSqlCommand("delete from musabaka");
            _db.SaveChanges();

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

      
        public dynamic arama(string _sporcu)
        {
            using (var _db = new sporEntities())
            {
                var tmp = (from s in _db.sporcu
                           where s.adi.Contains(_sporcu)
                           orderby s.id ascending
                           select new { s.id,s.adi,s.soyadi,s.lig.l_adi,s.ozellik}).ToList();
                return tmp;
            }


        }

        public void duzenle(int _sporcuId,string _adi,string _soyadi,string _lig,string _ozellik)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.sporcu.Where(x => x.id == _sporcuId).Select(x => x).First();
                if (deger != null)
                {
                    deger.adi = _adi;
                    deger.soyadi = _soyadi;
                    deger.ozellik = _ozellik;
                    deger.l_id = _db.lig.First(x => x.l_adi == _lig).l_id;
                    _db.SaveChanges();
                }
            }
        }

        public void sil(int _sporcuId)
        {
            using (_db = new sporEntities())
            {
                var deger = _db.sporcu.Where(x => x.id == _sporcuId).Select(x => x).FirstOrDefault();
                if (deger != null)
                {
                    _db.sporcu.Remove(deger);
                    _db.SaveChanges();
                
                }
            }

        }

      
    }
}
