namespace EnumerationToDb.Core
{
    using System.IO;
    using Interfaces;

    public class FileWriter : IFileWriter
    {
        private readonly StreamWriter _streamWriter;

        public FileWriter(string file)
        {
            _streamWriter = new StreamWriter(file);
        }

        public void Dispose()
        {
            if (_streamWriter != null)
                _streamWriter.Dispose();
        }

        public void WriteLine(string line)
        {
            _streamWriter.WriteLine(line);
        }
    }
}