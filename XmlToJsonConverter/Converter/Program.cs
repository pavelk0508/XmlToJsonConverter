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
        static int Main(string[] args)
        {
            if (args.Count() > 1)
            {
                Layer json = new Layer();
                string fileName = args[0];
                //читаем данные из файла
                XmlDocument doc = new XmlDocument();
                if (File.Exists(fileName))
                {
                    try
                    {
                        doc.Load(fileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR. Неверный формат XML файла");
                        return -1;
                    }
                    XmlElement xml = doc.DocumentElement;
                    json.ReadXml(xml);
                    string result = "";
                    LibConverter.Converter xmljson = new LibConverter.Converter(json.Sublayers.First(), "");
                    xmljson.ConvertToText();
                    result = xmljson.GetText();
                    try
                    {
                        File.WriteAllText(args[1], result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR. Ошибка записи в файл!");
                        return -1;
                    }
                    Console.WriteLine("Преобразование успешно завершено!");
                    return 0;
                }
                else
                {
                    Console.WriteLine("ERROR. Преобразование не выполнено. Не найден исходный файл.");
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("ERROR. Укажите аргументы: test файл_исходный файл_назначения");
                return -1;
            }
        }
    }
}
