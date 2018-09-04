using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibConverter;
using System.Xml;
using System.IO;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 1)
            {
                Layer json = new Layer();
                string fileName = args[0];
                //читаем данные из файла
                XmlDocument doc = new XmlDocument();
                if (File.Exists(fileName))
                {
                    doc.Load(fileName);
                    XmlElement xml = doc.DocumentElement;
                    json.ReadXml(xml);
                    string result = "";
                    LibConverter.Converter xmljson = new LibConverter.Converter(json.Sublayers.First(), "");
                    xmljson.ConvertToText();
                    result = xmljson.GetText();
                    File.WriteAllText(args[1], result);
                    Console.WriteLine("Преобразование успешно завершено!");
                }
                else
                {
                    Console.WriteLine("Преобразование не выполнено. Не найден исходный файл.");
                }
            }
            else
            {
                Console.WriteLine("Укажите аргументы: test файл_исходный файл_назначения");
            }
        }
    }
}
