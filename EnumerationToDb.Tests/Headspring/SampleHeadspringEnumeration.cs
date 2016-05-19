namespace EnumerationToDb.Tests.Headspring
{
    using global::Headspring;

    public class SampleHeadspringEnumeration : Enumeration<SampleHeadspringEnumeration>
    {
        public static SampleHeadspringEnumeration ExampleOne = new SampleHeadspringEnumeration(1, "Example One");
        public static SampleHeadspringEnumeration ExampleTwo = new SampleHeadspringEnumeration(2, "Example Two");
        public static SampleHeadspringEnumeration ExampleThree = new SampleHeadspringEnumeration(3, "Example Three");
        public static SampleHeadspringEnumeration ExampleFour = new SampleHeadspringEnumeration(4, "Example Four");
        public static SampleHeadspringEnumeration ExampleFive = new SampleHeadspringEnumeration(5, "Example Five");

        public SampleHeadspringEnumeration(int value, string displayName) : base(value, displayName)
        {
        }
    }
}
