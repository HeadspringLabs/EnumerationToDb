namespace EnumerationToDb.Core.SqlServer.Converters
{
    using System;

    public class Int64ToInt64Converter : EnumerationToDatabaseConverterBase
    {
        public override string DatabaseType => "bigint";
        public override Type PropertyType => typeof(Int64);
    }
}