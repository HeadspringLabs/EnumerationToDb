namespace EnumerationToDb.Core.Extensions
{
    using System.Linq;
    using System.Reflection;

    public static class FieldExtensions
    {
        public static bool IsDeprecated(this FieldInfo fieldInfo)
        {
            return fieldInfo.GetCustomAttributes().Any(x => x.TypeId.ToString().Contains("Deprecated"));
        }
    }
}