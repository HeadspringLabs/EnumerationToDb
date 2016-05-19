namespace EnumerationToDb.Tests.Yay
{
    using global::Yay.Enumerations;

    public class SampleYayEnumerationWithSorting : OrderedEnumeration<SampleYayEnumerationWithSorting>
    {
        public static SampleYayEnumerationWithSorting YaySampleOne = new SampleYayEnumerationWithSorting(1, "One Example", 3);
        public static SampleYayEnumerationWithSorting YaySampleTwo = new SampleYayEnumerationWithSorting(2, "Two Example", 2);
        public static SampleYayEnumerationWithSorting YaySampleThree = new SampleYayEnumerationWithSorting(3, "Three Example", 1);

        public SampleYayEnumerationWithSorting(int value, string displayName, int order) : base(value, displayName, order)
        {
        }
    }
}