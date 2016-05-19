namespace EnumerationToDb.Core.SqlServer.Converters
{
    using System;

    public class IntToIntConverter : EnumerationToDatabaseConverterBase
    {
        public override string DatabaseType => "int";
        public override Type PropertyType => typeof(int);
    }
}