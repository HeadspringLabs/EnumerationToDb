namespace EnumerationToDb.Tests
{
    using System.Reflection;
    using Core;
    using Core.Interfaces;

    public class TestEnumerationToDbOptions : IEnumerationToDbOptions
    {
        public string AssemblyFilePath => Assembly.GetExecutingAssembly().Location;
        public string SqlScriptFilePath => "c:/";
        public bool DeprecateEnabled => true;
        public bool NoDropTableMode => true;
        public bool SingleTableMode => true;
        public string TableSchema { get; set; }

        public string Prefix => "";
        public string TableName { get; set; }
        public string DatabaseProvider { get; set; }
    }
}
