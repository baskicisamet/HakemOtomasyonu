using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Odev1
{
    class ComponentConfiguration
    {

        private  static ComponentConfiguration instance;


         XmlTextReader oku;
         private String dosya = "ComponentConfig.xml";
         List<Eleman> elemanlar;
         


        

        private ComponentConfiguration()
         {
             
            
           oku = new XmlTextReader(dosya);
           elemanlar = new List<Eleman>();


           String bulunulanNode;

           try
           {
               while (oku.Read()) //Dosyadaki veriler tükenene kadar okuma işlemi devam eder.
               {
                   
                   

                   if (oku.NodeType == XmlNodeType.Element)//Düğümlerdeki veri element türünde ise okuma gerçekleşir.
                   {
                       
                       if(oku.GetAttribute("iscomponent")=="true"){
                       Eleman e = new Eleman();
                       bulunulanNode = oku.Name;
                       e.setTip(oku.GetAttribute("tip"));
                       e.setTur(oku.Name);
                       while(oku.Read() && oku.Name != bulunulanNode){

                           
                       switch (oku.Name)//Elementlerin isimlerine göre okuma işlemi gerçekleşir.
                       {
                           case "textcolor":
                               e.setTextColor(oku.ReadString());
                               break;
                           case "bgcolor":
                               e.setBgColor(oku.ReadString());
                               break;
                           
                       }
                           }//while
                       elemanlar.Add(e);
                   }//component ise
                   }
                  
                    
                   
               }

               oku.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show("okunmadı"+ex.Message);
               
           }  
        }

        public static ComponentConfiguration Instance()
        {
            if(instance == null){
                instance = new ComponentConfiguration();
            }

            return instance;
        }

        public List<Eleman> getBilgiler()
        {

            return elemanlar;

            
        }

        public void textBoxDizaynEt(List<TextBox> componentler, String tip)
        {
            Color textColor = new Color();
            Color bgColor = new Color();
            Eleman uygulanicakTip = new Eleman();
            for (int i = 0; i < elemanlar.Count;i++ )
            {
                if(elemanlar[i].getTur() == "textbox" && elemanlar[i].getTip() == tip){
                    uygulanicakTip = elemanlar[i]; // nesnenin dolup dolmsdigina bak !!!!!!!!!
                    
                }
            }
            for (int i = 0; i < componentler.Count;i++ )
            {   
                // tipin text color'unu ve bgcolor'unu aliyoruz
                textColor = Color.FromName(uygulanicakTip.getTextColor().ToString());
                bgColor = Color.FromName(uygulanicakTip.getBgColor());

                componentler[i].ForeColor = textColor;
                componentler[i].BackColor = bgColor;
            }   
        }




        public void comboBoxDizaynEt(List<ComboBox> componentler, String tip)
        {
            Color textColor = new Color();
            Color bgColor = new Color();
            Eleman uygulanicakTip = new Eleman();
            for (int i = 0; i < elemanlar.Count; i++)
            {
                if (elemanlar[i].getTur() == "combobox" && elemanlar[i].getTip() == tip)
                {
                    uygulanicakTip = elemanlar[i]; 
                }
            }
            for (int i = 0; i < componentler.Count; i++)
            {
                // tipin text color'unu ve bgcolor'unu aliyoruz
                textColor = Color.FromName(uygulanicakTip.getTextColor().ToString());
                bgColor = Color.FromName(uygulanicakTip.getBgColor());

                componentler[i].ForeColor = textColor;
                componentler[i].BackColor = bgColor;
            }
        }



        public void buttonDizaynEt(List<Button> componentler,String tip)
        {
            Color textColor = new Color();
            Color bgColor = new Color();
            Eleman uygulanicakTip = new Eleman();
            for (int i = 0; i < elemanlar.Count; i++)
            {
                if (elemanlar[i].getTur() == "combobox" && elemanlar[i].getTip() == tip)
                {
                    uygulanicakTip = elemanlar[i];
                }
            }
            for (int i = 0; i < componentler.Count; i++)
            {
                // tipin text color'unu ve bgcolor'unu aliyoruz
                textColor = Color.FromName(uygulanicakTip.getTextColor().ToString());
                bgColor = Color.FromName(uygulanicakTip.getBgColor());

                componentler[i].ForeColor = textColor;
                componentler[i].BackColor = bgColor;
            }
        }

        


    }


   


}
