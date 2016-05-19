namespace EnumerationToDb.Tests.Yay
{
    using global::Yay.Enumerations;

    public class SampleYayEnumeration : Enumeration<SampleYayEnumeration>
    {
        public static SampleYayEnumeration YaySampleOne = new SampleYayEnumeration(1, "One Example");
        public static SampleYayEnumeration YaySampleTwo = new SampleYayEnumeration(2, "Two Example");
        public static SampleYayEnumeration YaySampleThree = new SampleYayEnumeration(3, "Three Example");

        public SampleYayEnumeration(int value, string displayName) : base(value, displayName)
        {
        }
    }
}