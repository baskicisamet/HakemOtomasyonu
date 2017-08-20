using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
    class Eleman
    {
        String tip;
        String textColor;
        String bgColor;
        String tur;

        public Eleman(String tip,String textColor, String bgColor,String tur)
        {
            this.textColor = textColor;
            this.bgColor = bgColor;
            this.tip = tip;
            this.tur = tur;

        }

        public Eleman()
        {
           

        }

        public String getTip()
        {
            return this.tip;

        }
        public String getTextColor()
        {
            return this.textColor;

        }
        public String getBgColor()
        {
            return this.bgColor;

        }
        public String getTur()
        {
            return this.tur;

        }


        public void setTip(String tip)
        {
            this.tip = tip;
        }
        public void setTextColor(String textColor)
        {
            this.textColor = textColor;
        }
        public void setBgColor(String bgColor)
        {
            this.bgColor = bgColor;
        }
        public void setTur(String tur)
        {
            this.tur = tur;
        }

    }
}
