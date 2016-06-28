using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task6
{
    [Serializable]
    public class DataFont
    {

        /// <summary>
        /// Имя шрифта
        /// </summary>
        [XmlElement("NameFont")]
        public string NameFont { get; set; }

        /// <summary>
        /// Тип начертания шрифта
        /// </summary>
        [XmlElement("Type")]
        public TypeLettering Type { get; set; }
    }
}
