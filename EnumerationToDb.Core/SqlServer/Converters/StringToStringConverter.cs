namespace EnumerationToDb.Core.SqlServer.Converters
{
    using System;

    public class StringToStringConverter : EnumerationToDatabaseConverterBase
    {
        public override string DatabaseType => "nvarchar(max)";
        public override Type PropertyType => typeof(string);
    }
}