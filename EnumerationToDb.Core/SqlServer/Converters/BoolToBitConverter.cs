namespace EnumerationToDb.Core.SqlServer.Converters
{
    using System;

    public class BoolToBitConverter : EnumerationToDatabaseConverterBase
    {
        public override string DatabaseType => "bit";
        public override Type PropertyType => typeof(bool);
    }
}