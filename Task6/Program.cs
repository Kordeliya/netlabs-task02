using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Task6
{
    class Program
    {
        private readonly static string path = "fonts.xml";
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в систему редактирования шрифтов.");
            while (true)
            {
                List<DataFont> list = GetListFont();
                if (list == null)
                {
                    Console.WriteLine("На данный момент списка шрифтов не существует.");
                    list = CreateNewList();
                    SaveListFont(list);
                }
                else
                {
                    Console.WriteLine("Существует список шрифтов с параметрами.");
                    list = ChangeList(list);
                    SaveListFont(list);
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Изменяем существующий список шрифтов
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<DataFont> ChangeList(List<DataFont> list)
        {
            Console.WriteLine("Выберите шрифт для изменения. Для сохранения всех изменений введите s");
            for (int i = 0; i < list.Count(); i++)
            {
                Console.Write("{0} - {1}({2}) ", i, list[i].NameFont, list[i].Type);
            }
            Console.WriteLine();
            while(true)
            {
                var choice = Console.ReadLine();
                if(choice == "s")
                    break;
                int font;
                if (Int32.TryParse(choice, out font))
                {
                    try
                    {
                        DataFont fontForChange = list[font];
                        var item = ChangeParam(fontForChange.NameFont);
                        if (item != null)
                        {
                            list[font] = item;
                            Console.WriteLine("Изменения:Шрифт {0} тип начертания {1}", list[font].NameFont, list[font].Type);
                        }
                        Console.WriteLine("Выберите шрифт для изменения. Для сохранения всех изменений введите s");
                    }
                    catch
                    {
                        Console.WriteLine("Неверно введены данные повторите ввод:");
                    }
                }

            }
            return list;
        }

        /// <summary>
        /// Изменение типа шрифта
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static DataFont ChangeParam(string font)
        {
            DataFont fontData = null ;
            bool IsNotSuccess = true;
            Console.WriteLine("Выберите параметр надписи:{0}", font);
            Console.WriteLine("1: bold");
            Console.WriteLine("2: italic");
            Console.WriteLine("3: underline");
            var choice = Console.ReadLine();
            while (IsNotSuccess)
            {
                TypeLettering type;
                if (CheckPickParam(choice, out type))
                {
                    fontData = new DataFont { NameFont = font, Type = type };
                    IsNotSuccess = false;
                }
                else
                {
                    Console.WriteLine("Произошла ошибка ввода типа начертания!");
                }
            }
            return fontData;
        }
        /// <summary>
        /// создание нового листа шрифтов
        /// </summary>
        /// <returns></returns>
        private static List<DataFont> CreateNewList()
        {
            Console.WriteLine("Создание нового списка шрифтов.");
            List<DataFont> result = new List<DataFont>();
            List<string> fonts = new List<string> { "None", "Bold", "Bold Italic", "Italic"};
            foreach (var item in fonts)
            {
                DataFont font = ChangeParam(item);
                result.Add(font);
                Console.WriteLine();
            }
            return result;
        }

        /// <summary>
        /// Проверка введенного типа начертания
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool CheckPickParam(string choice, out TypeLettering type)
        {
            type = TypeLettering.None;
            bool isSuccess = true;
            switch (choice)
            {
                case "1":
                    type = TypeLettering.Bold;
                    break;
                case "2":
                    type = TypeLettering.Italic;
                    break;
                case "3":
                    type = TypeLettering.UnderLine;
                    break;
                default:    
                    isSuccess =  false;
                    break;
            }
            return isSuccess;

        }

        /// <summary>
        /// Получение списка шрифтов из файла
        /// </summary>
        /// <returns></returns>
        private static List<DataFont> GetListFont()
        {
            List<DataFont> result = null;
            if (File.Exists(path))
            {
                XmlReader reader = XmlReader.Create(path);
                XmlSerializer serializer = new XmlSerializer(typeof(List<DataFont>));
                List<DataFont> fontsList = (List<DataFont>)serializer.Deserialize(reader);
                result = fontsList;
                reader.Close();
            }
            return result;
        }

        /// <summary>
        /// Сохранение листа шрифтов
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool SaveListFont(List<DataFont> list)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<DataFont>));

                FileStream fs = new FileStream(path, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                // Serialize using the XmlTextWriter.
                serializer.Serialize(writer, list);
                writer.Close();
                fs.Close();
                Console.WriteLine("Изменения успешно сохранены!");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
