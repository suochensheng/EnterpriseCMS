using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationUtility
{
    public class XMLHelper
    {
        #region XML Seriliza / Deserialize

        public static void SerializaXML<T>(string path, T model)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                fileInfo.Create().Dispose();
            }
            else
                fileInfo.Create().Dispose();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            serializer.Serialize(fs, model);
            fs.Close();
        }
        public static T DeserializeXML<T>(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                return default(T);
            }
            

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            T model = (T)serializer.Deserialize(fs);
            fs.Close();
            return model;
        }

        #endregion
    }
}
