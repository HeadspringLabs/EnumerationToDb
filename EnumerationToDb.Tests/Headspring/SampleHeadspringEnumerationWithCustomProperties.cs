namespace EnumerationToDb.Tests.Headspring
{
    using global::Headspring;

    public class SampleHeadspringEnumerationWithCustomProperties : Enumeration<SampleHeadspringEnumeration>
    {
        public static SampleHeadspringEnumerationWithCustomProperties ExampleOne = new SampleHeadspringEnumerationWithCustomProperties(1, "Example One", "Example 1");
        public static SampleHeadspringEnumerationWithCustomProperties ExampleTwo = new SampleHeadspringEnumerationWithCustomProperties(2, "Example Two", "Example 2");
        public static SampleHeadspringEnumerationWithCustomProperties ExampleThree = new SampleHeadspringEnumerationWithCustomProperties(3, "Example Three", "Example 3");
        public static SampleHeadspringEnumerationWithCustomProperties ExampleFour = new SampleHeadspringEnumerationWithCustomProperties(4, "Example Four", "Example 4");
        public static SampleHeadspringEnumerationWithCustomProperties ExampleFive = new SampleHeadspringEnumerationWithCustomProperties(5, "Example Five", "Example 5");

        public SampleHeadspringEnumerationWithCustomProperties(int value, string displayName, string friendlyName) : base(value, displayName)
        {
            FriendlyName = friendlyName;
        }

        public string FriendlyName { get; }
    }
}