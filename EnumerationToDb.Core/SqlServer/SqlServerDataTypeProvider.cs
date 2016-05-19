namespace EnumerationToDb.Core.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class SqlServerDataTypeProvider : IDataTypeProvider
    {
        private readonly IEnumerable<EnumerationToDatabaseConverterBase> _converters;

        public SqlServerDataTypeProvider()
        {
            _converters = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(type => type.Namespace.StartsWith(GetType().Namespace) &&
                                              typeof(EnumerationToDatabaseConverterBase).IsAssignableFrom(type))
                                  .Select(Activator.CreateInstance)
                                  .Cast<EnumerationToDatabaseConverterBase>();
        }

        public string GetDataType(Type propertyType)
        {
            return _converters.Single(x => x.PropertyType == propertyType).DatabaseType;
        }

        public string GetDataType<T>()
        {
            return GetDataType(typeof(T));
        }

        public bool IsPropertyValid(Type propertyType)
        {
            return _converters.Any(x => x.PropertyType == propertyType);
        }

        public IEnumerable<EnumerationToDatabaseConverterBase> GetConverters()
        {
            return _converters;
        }
    }
}