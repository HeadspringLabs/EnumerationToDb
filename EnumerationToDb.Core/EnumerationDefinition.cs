namespace EnumerationToDb.Core
{
    using System.Collections.Generic;

    public class EnumerationDefinition
    {
        public string EnumerationName { get; set; }
        public List<ColumnValue> Properties { get; set; } = new List<ColumnValue>();

        public void AddColumnValue(string columnName, object value)
        {
            Properties.Add(new ColumnValue {ColumnName = columnName, Value = value});
        }
        public class ColumnValue
        {
            public string ColumnName { get; set; }
            public object Value { get; set; }
        }
    }
}