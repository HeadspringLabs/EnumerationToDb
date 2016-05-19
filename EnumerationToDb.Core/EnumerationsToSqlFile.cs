namespace EnumerationToDb.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Extensions;
    using Interfaces;

    public class EnumerationsToSqlFile
    {
        private readonly IFileWriter _fileWriter;
        private readonly ISqlWriter _sqlWriter;
        private readonly IEnumerationToDataStructureService _enumerationToDataStructureService;

        public EnumerationsToSqlFile(IFileWriter fileWriter, ISqlWriter sqlWriter, IEnumerationToDataStructureService enumerationToDataStructureService)
        {
            _fileWriter = fileWriter;
            _sqlWriter = sqlWriter;
            _enumerationToDataStructureService = enumerationToDataStructureService;
        }

        public string GenerateSqlFile(IEnumerationToDbOptions options)
        {
            var assembly = Assembly.LoadFrom(options.AssemblyFilePath);
            var enumerations = assembly.GetTypesLoaded().Where(enumType => enumType.BaseType != null && (!enumType.IsAbstract && enumType.BaseType.Name.Contains("Enumeration")));

            var structures = _enumerationToDataStructureService.GetStructures(enumerations, options.SingleTableMode, options.DeprecateEnabled);

            if (options.SingleTableMode)
            {
                CreateSqlFileForSingleTable(structures, options);
            }
            else
            {
                CreateSqlFileForMultiTable(structures, options);
            }

            return Path.GetFullPath(options.SqlScriptFilePath);
        }

        private void CreateSqlFileForMultiTable(IEnumerable<EnumerationDataStructure> enumerationDataStructures, IEnumerationToDbOptions options)
        {
            using (_fileWriter)
            {
                foreach (var structure in enumerationDataStructures)
                {
                    var name = structure.Name;
                    options.TableName = options.Prefix + name;
                    if (!options.NoDropTableMode)
                    {
                        _fileWriter.WriteLine(_sqlWriter.DropTable(options.TableSchema, options.TableName));
                    }
                    _fileWriter.WriteLine(_sqlWriter.CreateTable(options, structure.Columns));

                    foreach (var enumerationType in structure.EnumerationInstances)
                    {
                        _fileWriter.WriteLine(_sqlWriter.InsertStatement(enumerationType, options));
                    }
                }
            }
        }

        private void CreateSqlFileForSingleTable(IEnumerable<EnumerationDataStructure> enumerationDataStructures, IEnumerationToDbOptions options)
        {
            var structures = enumerationDataStructures.ToList();
            using (_fileWriter)
            {
                if (!options.NoDropTableMode)
                {
                    _fileWriter.WriteLine(_sqlWriter.DropTable(options.TableSchema, options.TableName));
                }
                
                _fileWriter.WriteLine(_sqlWriter.CreateTable(options, structures.First().Columns));

                foreach (var structure in structures)
                {
                    foreach (var enumerationType in structure.EnumerationInstances)
                    {
                        _fileWriter.WriteLine(_sqlWriter.InsertStatement(enumerationType, options));
                    }
                }
            }
        }
    }
}
