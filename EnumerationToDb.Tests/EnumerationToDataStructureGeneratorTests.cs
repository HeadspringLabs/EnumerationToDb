namespace EnumerationToDb.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.SqlServer;
    using Headspring;
    using Should;
    using Yay;

    public class EnumerationToDataStructureGeneratorTests
    {
        public void ShouldReturnEnumerationName()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> {typeof(SampleHeadspringEnumeration)});

            result.Single().Name.ShouldEqual(typeof(SampleHeadspringEnumeration).Name);
        }

        public void ShouldReturnEnumerationColumnsForMultiTables()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> {typeof(SampleHeadspringEnumeration)});
            
            result.Single().Columns.Count().ShouldEqual(2);
        }

        public void ShouldReturnEnumerationColumnsForMultiTablesWithCustomProperties()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> {typeof(SampleHeadspringEnumerationWithCustomProperties)});

            result.Single().Columns.Count().ShouldEqual(3);
        }

        public void ShouldReturnEnumerationColumnsForMultiTablesAndDeprecate()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> {typeof(SampleHeadspringEnumeration)}, includeDeprecate: true);

            result.Single().Columns.Count().ShouldEqual(3);
        }

        public void ShouldReturnEnumerationInstancesForMultiTables()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> {typeof(SampleHeadspringEnumeration)});

            result.Single().EnumerationInstances.Count.ShouldEqual(5);
        }

        public void ShouldReturnEnumerationInstanceValuesForMultiTables()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> {typeof(SampleHeadspringEnumeration)});

            result.Single().EnumerationInstances.First().Properties.First(x=>x.ColumnName==StandardEnumerationColumns.Value).Value.ShouldEqual(SampleHeadspringEnumeration.ExampleOne.Value);
            result.Single().EnumerationInstances.First().Properties.First(x=>x.ColumnName==StandardEnumerationColumns.DisplayName).Value.ShouldEqual(SampleHeadspringEnumeration.ExampleOne.DisplayName);
        }

        public void ShouldReturnEnumerationColumnsForSingleTable()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> {typeof(SampleHeadspringEnumeration)}, true);

            result.Single().Columns.Count().ShouldEqual(3);
        }

        public void ShouldReturnEnumerationInstanceValuesForMultiTablesWithCustomProperties()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> { typeof(SampleHeadspringEnumerationWithCustomProperties) });

            result.Single().EnumerationInstances.First().Properties.First(x=>x.ColumnName == "FriendlyName").Value.ShouldEqual(SampleHeadspringEnumerationWithCustomProperties.ExampleOne.FriendlyName);
        }

        public void ShouldReturnCorrectValueForDeprecatedEnumeration()
        {
            var generator = new EnumerationToDataStructureGenerator(new SqlServerDataTypeProvider());
            var result = generator.GetStructures(new List<Type> { typeof(SampleYayEnumerationWithDeprecate) }, includeDeprecate: true);

            result.Single().EnumerationInstances
                  .Single(x=>x.Properties.Any(column => column.Value == SampleYayEnumerationWithDeprecate.YaySampleTwo.DisplayName))
                  .Properties.Any(x=>x.ColumnName == StandardEnumerationColumns.IsDeprecated && (bool)x.Value)
                  .ShouldBeTrue();
        }

    }
}
