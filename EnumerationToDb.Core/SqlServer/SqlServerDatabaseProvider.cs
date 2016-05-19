namespace EnumerationToDb.Core.SqlServer
{
    using Interfaces;

    public class SqlServerDatabaseProvider : IDatabaseProvider
    {
        public ISqlWriter SqlWriter => new SqlServerSqlWriter();
        public IDataTypeProvider DataTypeProvider => new SqlServerDataTypeProvider();
    }
}