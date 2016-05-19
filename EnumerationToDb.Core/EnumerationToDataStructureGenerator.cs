namespace EnumerationToDb.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Interfaces;

    public class EnumerationToDataStructureGenerator : IEnumerationToDataStructureService
    {
        private readonly IDataTypeProvider _databaseProvider;
        public EnumerationToDataStructureGenerator(IDataTypeProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public IEnumerable<EnumerationDataStructure> GetStructures(IEnumerable<Type> enumerations, bool singleMode=false, bool includeDeprecate=false)
        {
            var structures = new List<EnumerationDataStructure>();
            foreach (var enumeration in enumerations)
            {
                var structure = new EnumerationDataStructure
                {
                    Name = enumeration.Name,
                    Columns = singleMode ? GetStandardColumnDefinition(includeDeprecate) : GetCustomColumnDefinition(enumeration, includeDeprecate),
                    EnumerationInstances = singleMode ? GetStandardEnumerations(enumeration, includeDeprecate) : GetCustomEnumerations(enumeration, includeDeprecate),
                };

                structures.Add(structure);
            }
            return structures;
        }

        private IEnumerable<ColumnDefinition> GetStandardColumnDefinition(bool includeDeprecate)
        {
            yield return new ColumnDefinition { ColumnName = StandardEnumerationColumns.DisplayName, DatabaseType = _databaseProvider.GetDataType<string>()};
            yield return new ColumnDefinition { ColumnName = StandardEnumerationColumns.Value, DatabaseType = _databaseProvider.GetDataType<int>()};
            yield return new ColumnDefinition { ColumnName = StandardEnumerationColumns.Type, DatabaseType = _databaseProvider.GetDataType<string>()};

            if (includeDeprecate)
            {
                yield return new ColumnDefinition { ColumnName = StandardEnumerationColumns.IsDeprecated, DatabaseType = _databaseProvider.GetDataType<bool>() };
            }
        }

        private IEnumerable<ColumnDefinition> GetCustomColumnDefinition(Type enumerationType, bool includeDeprecate)
        {
            foreach (var property in enumerationType.GetProperties())
            {
                if (_databaseProvider.IsPropertyValid(property.PropertyType))
                {
                    yield return new ColumnDefinition
                    {
                        ColumnName = property.Name,
                        DatabaseType = _databaseProvider.GetDataType(property.PropertyType),
                    };
                }
            }

            if (includeDeprecate)
            {
                yield return new ColumnDefinition {ColumnName = StandardEnumerationColumns.IsDeprecated, DatabaseType = _databaseProvider.GetDataType<bool>()};
            }
        }

        private List<EnumerationDefinition> GetStandardEnumerations(Type enumerationType, bool includeDeprecate)
        {
            var enumerationDefinitions = new List<EnumerationDefinition>();
            foreach (var field in enumerationType.GetFields())
            {
                var enumerationInstance = field.GetValue(null);
                var definition = new EnumerationDefinition
                {
                    EnumerationName = field.Name,
                };

                var displayNameProperty = enumerationType.GetProperty(StandardEnumerationColumns.DisplayName);
                definition.AddColumnValue(StandardEnumerationColumns.DisplayName, displayNameProperty.GetValue(enumerationInstance));
                var valueProperty = enumerationType.GetProperty(StandardEnumerationColumns.Value);
                definition.AddColumnValue(StandardEnumerationColumns.Value, valueProperty.GetValue(enumerationInstance));
                definition.AddColumnValue(StandardEnumerationColumns.Type, enumerationType.Name);

                if (includeDeprecate)
                {
                    definition.AddColumnValue(StandardEnumerationColumns.IsDeprecated, field.IsDeprecated());
                }

                enumerationDefinitions.Add(definition);
            }
            return enumerationDefinitions;
        }

        private List<EnumerationDefinition> GetCustomEnumerations(Type enumerationType, bool includeDeprecate)
        {
            var enumerationDefinitions = new List<EnumerationDefinition>();
            foreach (var field in enumerationType.GetFields())
            {
                var enumerationInstance = field.GetValue(null);
                var definition = new EnumerationDefinition
                {
                    EnumerationName = field.Name,
                };

                var columnsToMatch = GetCustomColumnDefinition(enumerationType, includeDeprecate);
                foreach (var property in enumerationType.GetProperties().Where(p => columnsToMatch.Any(d => d.ColumnName == p.Name)))
                {
                    definition.AddColumnValue(property.Name, property.GetValue(enumerationInstance));
                }

                if (includeDeprecate)
                {
                    definition.AddColumnValue(StandardEnumerationColumns.IsDeprecated, field.IsDeprecated());
                }

                enumerationDefinitions.Add(definition);
            }
            return enumerationDefinitions;
        }
    }
}
