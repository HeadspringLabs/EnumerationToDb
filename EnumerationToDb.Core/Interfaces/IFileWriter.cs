namespace EnumerationToDb.Core.Interfaces
{
    using System;

    public interface IFileWriter : IDisposable
    {
        void WriteLine(string line);
    }
}