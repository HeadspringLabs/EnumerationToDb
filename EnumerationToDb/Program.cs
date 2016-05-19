namespace EnumerationToDb
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Core;
    using Core.Interfaces;
    using Core.SqlServer;

    class Program
    {
        private static void Main(string[] args)
        {
            var definition = Args.Configuration.Configure<CommandArgumentConfig>();
            try
            {
                var command = definition.CreateAndBind(args);
                if (command.HelpMode)
                {
                    ShowHelp(definition);
                    return;
                }

                if (!File.Exists(command.AssemblyFilePath) || !command.AssemblyFilePath.EndsWith(".dll"))
                    throw new FileNotFoundException();

                if (command.SingleTableMode && string.IsNullOrEmpty(command.TableName))
                {
                    throw new ArgumentException("TableName is required if in SingleTableMode.");
                }

                var dbProvider = GetDbProvider(command.DatabaseProvider);
                var enumerationsToSqlFile = new EnumerationsToSqlFile(new FileWriter(command.SqlScriptFilePath), dbProvider.SqlWriter, new EnumerationToDataStructureGenerator(dbProvider.DataTypeProvider));

                var fileName = enumerationsToSqlFile.GenerateSqlFile(command);

                Console.Out.WriteLine("SQL script saved successfully - {0}", fileName);
            }
            catch (FileNotFoundException ex)
            {
                HandleException(ex.Message, definition);
            }
            catch (InvalidOperationException ex)
            {
                HandleException(ex.Message, definition);
            }
            catch (ArgumentException ex)
            {
                HandleException(ex.Message, definition);
            }
        }

        private static IDatabaseProvider GetDbProvider(string databaseProvider)
        {
            IDatabaseProvider dbProvider = new SqlServerDatabaseProvider();
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(x => x.Name == databaseProvider);
            if (type != null)
                dbProvider = (IDatabaseProvider)Activator.CreateInstance(type);

            return dbProvider;
        }

        private static void HandleException(string message, Args.IModelBindingDefinition<CommandArgumentConfig> definition)
        {
            ShowHelp(definition);
            Console.Out.WriteLine(message);
        }

        private static void ShowHelp(Args.IModelBindingDefinition<CommandArgumentConfig> definition)
        {
            var help = new Args.Help.HelpProvider().GenerateModelHelp(definition);
            var f = new Args.Help.Formatters.ConsoleHelpFormatter(120, 1, 5);

            f.WriteHelp(help, Console.Out);
        }
    }

}
