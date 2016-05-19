namespace EnumerationToDb.Core
{
    using System.Collections.Generic;

    public class EnumerationDataStructure
    {
        public string Name { get; set; }
        public IEnumerable<ColumnDefinition> Columns { get; set; }
        public List<EnumerationDefinition> EnumerationInstances { get; set; }

    }
}