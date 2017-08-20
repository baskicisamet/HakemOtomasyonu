using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev1
{
    public class FileLogger:Logger
    {

        private static FileLogger instance;
        private static String path;



        private FileLogger(String _path)
        {
            path = _path;
        }

        public static FileLogger getInstance(String _path)
        {
            
            if(instance == null){
                instance = new FileLogger(_path);
            }
            return instance;
        }

        public String getPath()
        {
            return path;
        }
       public void setPath(String _path)
        {
            path = _path;
        }


        public override void doLog(log _log) // log nesnesi formda doldurulacak
        {
            //log dosyasina yazma islemi ypilacak
            
            String tarih = _log.tarih.ToString();
            String isim = _log.isim;
            String tur = _log.tur;
            String islem = _log.islem;
            
            
            StreamWriter sw = new StreamWriter(path,true);
            
                
            sw.WriteLineAsync(tarih.ToString()+" "+tur+" "+isim+" "+" "+islem); // gelen log bilgileri dosyaya yaziliyor

            sw.Flush();
            sw.Close();
            
        }


    }
}
