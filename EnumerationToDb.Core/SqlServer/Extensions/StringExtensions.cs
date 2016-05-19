namespace EnumerationToDb.Core.SqlServer.Extensions
{
    public static class StringExtensions
    {
        public static string ToSqlSafeString(this object o)
        {
            return o.ToString().Replace("'", "''");
        }
    }
}