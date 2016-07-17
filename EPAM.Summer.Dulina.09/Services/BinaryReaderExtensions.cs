using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class BinaryReaderExtensions
    {
        public static bool Eof(this BinaryReader binaryReader)
        {
            return binaryReader.BaseStream.Position == binaryReader.BaseStream.Length;
        }
    }
}
