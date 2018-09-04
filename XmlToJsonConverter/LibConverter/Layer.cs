using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibConverter
{
    public class Layer
    {
        private string _Name = "";
        private string _Title = "";
        public List<Layer> Sublayers; //подслои
        public List<Attribute> Attributes; //аттрибуты

        public Layer()
        {
            Attributes = new List<Attribute>();
            Sublayers = new List<Layer>();
        }
        public string GetName()
        {
            return this._Name;
        }

        public string GetTitle()
        {
            return _Title;
        }

        //чтение xml и перевод в структуру Layer
        public void ReadXml(XmlElement xml)
        {
            foreach (XmlElement el in xml)
            {
                switch(el.Name.ToString().ToLower())
                {
                    case "name":
                        this._Name = el.InnerText;
                        break;
                    case "title":
                        this._Title = el.InnerText;
                        break;
                    case "attributes":
                        foreach (XmlElement element in el)
                        {
                            Attribute tempA = new Attribute();
                            tempA.ReadXml(element);
                            this.Attributes.Add(tempA);
                        }
                        break;
                    case "layer":
                        Layer tempL = new Layer();
                        tempL.ReadXml(el);
                        this.Sublayers.Add(tempL);
                        break;   
                }
            }
        }
    }
}
