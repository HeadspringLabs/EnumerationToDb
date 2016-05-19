namespace EnumerationToDb.Core.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Interfaces;

    public class SqlServerSqlWriter : ISqlWriter
    {
        public string DropTable(string schema, string table)
        {
            const string dropTableSqlTemplate =
                 @"IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}].[{1}]') AND type in (N'U'))
                      DROP TABLE [{0}].[{1}]
                      GO";

            return string.Format(dropTableSqlTemplate, schema, table);
        }

        public string CreateTable(IEnumerationToDbOptions options, IEnumerable<ColumnDefinition> columnDefinitions)
        {
            var createScriptTemplate = @"
                    CREATE TABLE [{0}].[{1}](" +
                                       string.Join(",", columnDefinitions.Select(x=> "[" + x.ColumnName + "] " + x.DatabaseType + " NOT NULL")) +
                                       @"
                    CONSTRAINT [PK_{1}] PRIMARY KEY CLUSTERED 
                    ([" + StandardEnumerationColumns.Value + "] ASC" +
                    (options.SingleTableMode ? ",[" + StandardEnumerationColumns.Type + "] ASC" : "") +
                                       @"
                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                    ) ON [PRIMARY]
                    GO";

            return string.Format(createScriptTemplate, options.TableSchema, options.TableName);
        }
        public string InsertStatement(EnumerationDefinition definition, IEnumerationToDbOptions options)
        {
            var commaSeparate = new Func<IEnumerable<object>, string>(objects => string.Join(",", objects));

            return string.Format("INSERT INTO [{0}].[{1}]({2}) VALUES({3});", options.TableSchema
                                                                            , options.TableName
                                                                            , commaSeparate(definition.Properties.Select(x => "[" + x.ColumnName + "]"))
                                                                            , commaSeparate(definition.Properties.Select(x => "'" + x.Value.ToSqlSafeString() + "'")));
        }
    }
}