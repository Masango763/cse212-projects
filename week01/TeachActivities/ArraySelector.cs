public class ArraySelector
{
    public static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];
        int l1Index = 0;
        int l2Index = 0;

        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                result[i] = list1[l1Index++];
            }
            else if (select[i] == 2)
            {
                result[i] = list2[l2Index++];
            }
        }
        return result;
    }
}
