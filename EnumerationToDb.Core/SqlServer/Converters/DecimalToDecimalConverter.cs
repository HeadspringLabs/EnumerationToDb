namespace EnumerationToDb.Core.SqlServer.Converters
{
    using System;

    public class DecimalToDecimalConverter : EnumerationToDatabaseConverterBase
    {
        public override string DatabaseType => "decimal(38,18)";
        public override Type PropertyType => typeof(decimal);
    }
}