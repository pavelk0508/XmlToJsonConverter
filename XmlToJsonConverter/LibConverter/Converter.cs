using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibConverter
{
    public class Converter
    {
        private Layer _Layers;
        private string _Result = "";
        public Converter(Layer layer, string text)
        {
            _Layers = layer;
            _Result = text;
        }

        //возвращение текста
        public string GetText()
        {
            return _Result;
        }


        //добавление пробелов и переноса
        public string SetSpaces(int count)
        {
            string result = " ";
            result += (char)13;
            for (int i = 0; i < count; i++)
                result += '\t';
            return result;
        }

        //конвертер в текстовый json
        public void ConvertToText(int CountSpaces = 0)
        {
            _Result += '\t' + @"{" + SetSpaces(CountSpaces + 1);
            _Result += @"""name"" : " + @"""" + _Layers.GetName() + @"""," + SetSpaces(CountSpaces + 1);
            _Result += @"""title"" : " + @"""" + _Layers.GetTitle() + @"""," + SetSpaces(CountSpaces + 1);
            if (_Layers.Attributes.Count > 0)
            {
                _Result += @"""attributes"" : [ ";
                for (int i = 0; i < _Layers.Attributes.Count; i++)
                {
                    _Result += SetSpaces(CountSpaces + 2) + "{" + SetSpaces(CountSpaces + 3) + @"""name"" : """ + _Layers.Attributes[i].GetName() + @"""," + SetSpaces(CountSpaces + 3);
                    _Result += @"""type"" : """ + _Layers.Attributes[i].GetType() + @"""" + SetSpaces(CountSpaces + 2);
                    if (i < _Layers.Attributes.Count - 1)
                    {
                        _Result += "}," + SetSpaces(CountSpaces + 1);
                    }
                    else
                    {
                        _Result += "}" + SetSpaces(CountSpaces + 1);
                    }
                }
                _Result += "]" + SetSpaces(CountSpaces);
            }
            if (_Layers.Sublayers.Count > 0)
            {
                _Result += @"""sublayers"" : [ " + SetSpaces(CountSpaces + 1);
                for (int i = 0; i < _Layers.Sublayers.Count; i++)
                {
                    Converter temp = new Converter(_Layers.Sublayers[i], "");
                    temp.ConvertToText(CountSpaces + 1);
                    _Result += temp.GetText();
                    if (i < _Layers.Sublayers.Count - 1)
                    {
                        _Result += ',' + SetSpaces(CountSpaces - 1);
                    }
                    else
                    {
                        _Result += SetSpaces(CountSpaces - 1);
                    }
                }
                _Result += "]" + SetSpaces(CountSpaces);
            }
            _Result += "}";
        }
    }
}
