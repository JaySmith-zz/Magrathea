using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Magrathea.Data
{
    public class RepositoryXmlSerialization
    {
        private Serialization.ObjectSerializer _seralizer;

        public RepositoryXmlSerialization()
        {
            _seralizer = new Serialization.ObjectSerializer();
        }

        public void SaveAs<T>(T Obj, string FileName, Encoding encoding, Type[] extraTypes)
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(FileName));
            if (!di.Exists)
                di.Create();
            XmlDocument document = new XmlDocument();
            XmlWriterSettings wSettings = new XmlWriterSettings();
            wSettings.Indent = true;
            wSettings.Encoding = encoding;
            wSettings.CloseOutput = true;
            wSettings.CheckCharacters = false;
            using (XmlWriter writer = XmlWriter.Create(FileName, wSettings))
            {
                if (extraTypes != null)
                   _seralizer.Serialize<T>(Obj, writer, extraTypes);
                else
                    _seralizer.Serialize<T>(Obj, writer);
                writer.Flush();
                document.Save(writer);
            }
        }

        public void SaveAs<T>(T Obj, string FileName, Type[] extraTypes)
        {
            SaveAs<T>(Obj, FileName, Encoding.UTF8, extraTypes);
        }

        public void SaveAs<T>(T Obj, string FileName, Encoding encoding)
        {
            SaveAs<T>(Obj, FileName, encoding, null);
        }

        public void SaveAs<T>(T Obj, string FileName)
        {
            SaveAs<T>(Obj, FileName, Encoding.UTF8);
        }

        public T Open<T>(string FileName, Type[] extraTypes)
        {
            T obj = default(T);
            if (File.Exists(FileName))
            {
                XmlReaderSettings rSettings = new XmlReaderSettings();
                rSettings.CloseInput = true;
                rSettings.CheckCharacters = false;
                using (XmlReader reader = XmlReader.Create(FileName, rSettings))
                {
                    reader.ReadOuterXml();
                    if (extraTypes != null)
                        obj = _seralizer.Deserialize<T>(reader, extraTypes);
                    else
                        obj = _seralizer.Deserialize<T>(reader);
                }
            }
            return obj;
        }

        public T Open<T>(string FileName)
        {
            return Open<T>(FileName, null);
        }
    }
}
