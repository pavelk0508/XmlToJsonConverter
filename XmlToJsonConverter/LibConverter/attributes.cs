using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibConverter
{
    public class Attribute
    {
        private string _Name;
        private string _Type;
        Attribute(string Name, string Type)
        {
            this._Name = Name;
            this._Type = Type;
        }

        public Attribute()
        {

        }

        public string GetName()
        {
            return this._Name;
        }

        public string GetType()
        {
            return _Type;
        }

        public void ReadXml(XmlElement xml)
        {
            this._Name = xml.GetAttribute("name");
            this._Type = xml.GetAttribute("type");
        }
    }
}