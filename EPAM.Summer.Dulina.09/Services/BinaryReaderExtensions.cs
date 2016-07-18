using System.IO;

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
