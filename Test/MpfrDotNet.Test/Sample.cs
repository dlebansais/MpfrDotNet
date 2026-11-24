namespace Test;

internal static class Sample
{
    public static T CreateNull<T>()
        where T : class
        => null!;
}
