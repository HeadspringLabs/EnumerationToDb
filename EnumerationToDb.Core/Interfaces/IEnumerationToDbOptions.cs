namespace EnumerationToDb.Core.Interfaces
{
    public interface IEnumerationToDbOptions
    {
        string AssemblyFilePath { get; }
        string SqlScriptFilePath { get; }

        bool DeprecateEnabled { get; }

        bool NoDropTableMode { get; }
        bool SingleTableMode { get; }

        string TableSchema { get; set; }
        string Prefix { get; }
        string TableName { get; set; }
        string DatabaseProvider { get; set; }
    }
}