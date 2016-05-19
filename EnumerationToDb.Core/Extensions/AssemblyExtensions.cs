namespace EnumerationToDb.Core.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class AssemblyExtensions
    {
        public static Type[] GetTypesLoaded(this Assembly assembly)
        {
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null).ToArray();
            }

            return types;
        }
    }
}