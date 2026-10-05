using System;

public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sorted)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sorted, 0, sorted.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sorted, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;

        int mid = first + (last - first) / 2;
        bst.Insert(sorted[mid]);
        InsertMiddle(sorted, first, mid - 1, bst);
        InsertMiddle(sorted, mid + 1, last, bst);
    }
}
