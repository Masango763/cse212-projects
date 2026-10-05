using System.Collections.Generic;

public static class ExtensionMethods
{
    public static string AsString<T>(this IEnumerable<T> source)
    {
        if (source is BinarySearchTree)
        {
            return "<Bst>{" + string.Join(", ", source) + "}";
        }
        return "<IEnumerable>{" + string.Join(", ", source) + "}";
    }
}
