namespace EnumerationToDb.Tests.Yay
{
    using global::Yay.Enumerations;

    public class SampleYayEnumerationWithDeprecate : Enumeration<SampleYayEnumerationWithDeprecate>
    {
        public static SampleYayEnumerationWithDeprecate YaySampleOne = new SampleYayEnumerationWithDeprecate(1, "One Example");
        [Deprecated]
        public static SampleYayEnumerationWithDeprecate YaySampleTwo = new SampleYayEnumerationWithDeprecate(2, "Two Example");
        public static SampleYayEnumerationWithDeprecate YaySampleThree = new SampleYayEnumerationWithDeprecate(3, "Three Example");

        public SampleYayEnumerationWithDeprecate(int value, string displayName) : base(value, displayName)
        {
        }
    }
}