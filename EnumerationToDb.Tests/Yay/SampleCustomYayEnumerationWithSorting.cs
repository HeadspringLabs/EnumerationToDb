namespace EnumerationToDb.Tests.Yay
{
    using global::Yay.Enumerations;

    public class SampleCustomYayEnumerationWithSorting : OrderedEnumeration<SampleCustomYayEnumerationWithSorting>
    {
        public static SampleCustomYayEnumerationWithSorting YaySampleOne = new SampleCustomYayEnumerationWithSorting(1, "One Example", 3, "1 Example");
        public static SampleCustomYayEnumerationWithSorting YaySampleTwo = new SampleCustomYayEnumerationWithSorting(2, "Two Example", 2, "2 Example");
        public static SampleCustomYayEnumerationWithSorting YaySampleThree = new SampleCustomYayEnumerationWithSorting(3, "Three Example", 1, "3 Example");

        public SampleCustomYayEnumerationWithSorting(int value, string displayName, int order, string friendlyName) : base(value, displayName, order)
        {
            FriendlyName = friendlyName;
        }
        public string FriendlyName { get; set; }
    }
}