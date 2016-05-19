namespace EnumerationToDb.Core.SqlServer.Converters
{
    using System;

    public class DoubleToDoubleConverter : EnumerationToDatabaseConverterBase
    {
        public override string DatabaseType => "float";
        public override Type PropertyType => typeof(double);
    }
}