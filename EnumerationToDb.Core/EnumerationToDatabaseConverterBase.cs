namespace EnumerationToDb.Core
{
    using System;

    public abstract class EnumerationToDatabaseConverterBase
    {
        public abstract string DatabaseType { get; }
        public abstract Type PropertyType { get; }
        
        public bool IsValid(Type type)
        {
            return type == PropertyType;
        }
    }
}