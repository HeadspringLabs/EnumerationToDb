namespace EnumerationToDb.Core.Interfaces
{
    using System.Collections.Generic;

    public interface ISqlWriter
    {
        string DropTable(string schema, string table);
        string CreateTable(IEnumerationToDbOptions options, IEnumerable<ColumnDefinition> columnDefinitions);
        string InsertStatement(EnumerationDefinition definition, IEnumerationToDbOptions options);
    }
}
