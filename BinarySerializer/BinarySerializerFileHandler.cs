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
        public static void Save(Manager model)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\hoffmann\Documents\FH Flensburg\AWP\serialisierung\LearningCards.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, model);
            stream.Close();
        }

        public static Manager Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\hoffmann\Documents\FH Flensburg\AWP\serialisierung\LearningCards.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Manager model = (Manager)formatter.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}
