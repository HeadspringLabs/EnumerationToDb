namespace EnumerationToDb.Core.Interfaces
{
    public interface IDatabaseProvider
    {
        ISqlWriter SqlWriter { get; }
        IDataTypeProvider DataTypeProvider { get; }
    }
}