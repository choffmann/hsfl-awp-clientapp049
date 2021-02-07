using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerializer
{
    public class BinarySerializerFileHandler
    {
        public static void Save(LearningCardCollection model)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\temp\LearningCards.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, model);
            stream.Close();
        }

        public static LearningCardCollection Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\temp\LearningCards.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            LearningCardCollection model = (LearningCardCollection)formatter.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}
