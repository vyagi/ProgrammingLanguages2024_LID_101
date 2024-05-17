namespace InvoiceApplication.BusinessLogic;

public static class CollectionsExtension1
{
    public static T Second<T>(this IEnumerable<T> collection)
    {
        return collection.Skip(1).First();
    }

    public static T Third<T>(this IEnumerable<T> collection)
    {
        return collection.Skip(1).First();
    }
}
