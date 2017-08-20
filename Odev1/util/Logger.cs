using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev1
{
     public abstract class  Logger:IObserver
    {




         private log _log;

         public log getLog()
         {
             return this._log;
         }

         public void  logSetLog(log _log){
             this._log = _log;

         }

        public void update(log _log)
        {
            this._log = _log;
            
            doLog(this._log);
        }

        public abstract void doLog(log _log);
    } 
}
