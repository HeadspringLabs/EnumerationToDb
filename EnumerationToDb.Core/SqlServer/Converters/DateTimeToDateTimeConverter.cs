namespace EnumerationToDb.Core.SqlServer.Converters
{
    using System;

    public class DateTimeToDateTimeConverter : EnumerationToDatabaseConverterBase
    {
        public override string DatabaseType => "datetime2";
        public override Type PropertyType => typeof(DateTime);
    }
}