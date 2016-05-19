namespace EnumerationToDb.Core.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IEnumerationToDataStructureService
    {
        IEnumerable<EnumerationDataStructure> GetStructures(IEnumerable<Type> enumerations, bool singleMode = false, bool includeDeprecate = false);
    }
}