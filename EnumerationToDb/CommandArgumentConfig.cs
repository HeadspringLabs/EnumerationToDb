namespace EnumerationToDb
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Core.Interfaces;

    [Description("Used to create a sql file to populate lookup table(s) for your enumerations")]
    public class CommandArgumentConfig : IEnumerationToDbOptions
    {
        [Required]
        [Args.ArgsMemberSwitch("assembly", "AssemblyFilePath")]
        [Description("* Path to the assembly containing enumerations")]
        public string AssemblyFilePath { get; set; }

        [Required]
        [Args.ArgsMemberSwitch("sqlfile", "SqlScriptFilePath")]
        [Description("* Path to your DB Migration scripts")]
        public string SqlScriptFilePath { get; set; }

        [Args.ArgsMemberSwitch("schema")]
        [Description("Table schema name (default: dbo)")]
        public string TableSchema { get; set; } = "dbo";

        [Args.ArgsMemberSwitch("prefix")]
        [Description("Adds a prefix to the table name")]
        public string Prefix { get; set; }

        [Args.ArgsMemberSwitch("donotdrop")]
        [Description("Do not drop table before creation")]
        public bool NoDropTableMode { get; set; }

        [Args.ArgsMemberSwitch("deprecate")]
        [Description("Creates an IsDeprecated column")]
        public bool DeprecateEnabled { get; set; }

        [Args.ArgsMemberSwitch("single")]
        [Description("Creates a single table for all enumerations (meaning no custom properties)")]
        public bool SingleTableMode { get; set; }

        [Args.ArgsMemberSwitch("tablename")]
        [Description("Table name for single table mode (default: EnumerationLookup)")]
        public string TableName { get; set; } = "EnumerationLookup";

        [Args.ArgsMemberSwitch("help", "h")]
        [Description("Display Help")]
        public bool HelpMode { get; set; }

        [Args.ArgsMemberSwitch("dbtype")]
        [Description("Database Type (default: SqlServerDataProvider)")]
        public string DatabaseProvider { get; set; } = "SqlServerDataProvider";
    }
}