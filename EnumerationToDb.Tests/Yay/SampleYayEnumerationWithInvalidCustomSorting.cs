namespace EnumerationToDb.Tests.Yay
{
    using System.Collections.Generic;
    using global::Yay.Enumerations;

    public class SampleYayEnumerationWithInvalidCustomSorting : OrderedEnumeration<SampleYayEnumerationWithSorting>
    {
        public static SampleYayEnumerationWithInvalidCustomSorting YaySampleOne = new SampleYayEnumerationWithInvalidCustomSorting(1, "One Example", 3, new List<string> {"1"}, true);
        public static SampleYayEnumerationWithInvalidCustomSorting YaySampleTwo = new SampleYayEnumerationWithInvalidCustomSorting(2, "Two Example", 2, new List<string> { "2" }, false);
        public static SampleYayEnumerationWithInvalidCustomSorting YaySampleThree = new SampleYayEnumerationWithInvalidCustomSorting(3, "Three Example", 1, new List<string> { "3" }, true);

        public SampleYayEnumerationWithInvalidCustomSorting(int value, string displayName, int order, List<string> items, bool yesNo) : base(value, displayName, order)
        {
            Items = items;
            YesNo = yesNo;
        }

        public List<string> Items { get; set; }
        public bool YesNo { get; set; }
    }
}