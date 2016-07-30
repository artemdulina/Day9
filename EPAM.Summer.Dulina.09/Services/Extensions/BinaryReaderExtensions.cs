using System.IO;

namespace Services.Extensions
{
    /// <summary>
    /// Provides extensions methods for System.IO.BinaryReader.
    /// </summary>
    public static class BinaryReaderExtensions
    {
        /// <summary>
        /// Checks at the end of a binary file.
        /// </summary>
        /// <param name="binaryReader">System.IO.BinaryReader to check end of file or not</param>
        /// <returns>True if the end of file reached otherwise false.</returns>
        public static bool Eof(this BinaryReader binaryReader)
        {
            return binaryReader.BaseStream.Position == binaryReader.BaseStream.Length;
        }
    }
}
