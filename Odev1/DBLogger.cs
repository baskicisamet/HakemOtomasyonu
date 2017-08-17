using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
    public class DBLogger:Logger
    {

        private static DBLogger instance;
        sporEntities _db;

        private DBLogger()
        {

        }

        public static DBLogger getInstance()
        {
            if(instance == null){
                instance = new DBLogger();
            }

            return instance;
        }





        

        public override void doLog(log _log)
        {
            // gelen log veri tabanina yazilacak

            using(_db = new sporEntities()){

                _db.log.Add(_log);
                _db.SaveChanges();


            }


            
        }

    }
}
