namespace EnumerationToDb.Core.Interfaces
{
    using System;

    public interface IDataTypeProvider
    {
        string GetDataType(Type propertyType);
        string GetDataType<T>();
        bool IsPropertyValid(Type propertyType);

    }
}