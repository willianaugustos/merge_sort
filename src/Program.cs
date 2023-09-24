

namespace merge_sort
{

    public static class Program
    {
        public static void Main()
        {
            int[] a = { 14, 6, 15, 2, 7, 12, 4, 10, 11, 1, 5, 13, 3, 9, 8 };
            
            Console.WriteLine("...........SORTING PROCESS STARTED...........");
            var sorted = MergeSort(a, 0, a.Length-1, 1);

            Console.WriteLine("...........SORTING PROCESS ENDED...........");
            Console.WriteLine("Sorted array = [" + string.Join(",",sorted)+"]");
        }

        private static int [] MergeSort(int[] a, int index_a, int index_b, int depth)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("  ", depth* 2)) + "Processing array  = [" + string.Join(",", a[index_a..index_b])+"]");
            if (index_b - index_a < 1)
            {
                return a[index_a..(index_b+1)];
            }

            int mid = (index_b-index_a)/2+index_a;
            var arrayLeft = MergeSort(a, index_a, mid, depth+1);
            var arrayRight = MergeSort(a, mid+1, index_b, depth+1);
            
            return merge(arrayLeft, arrayRight, depth);
        }

        private static int[] merge(int[] a, int[] b, int depth)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("  ", depth* 2)) + "Merging arrays.. a = [" + string.Join(",",a)+"] b=["+string.Join(",", b)+"]");
            int i=0;
            int j=0;
            int current=-1;
            int[] result = new int[a.Length+b.Length];
            while (i<a.Length && j<b.Length)
            {
                current++;
                if (a[i] < b[j])
                {
                    result[current]=a[i];
                    i++;
                    continue;
                }
                
                result[current]=b[j];
                j++;                
            }
            putRemaining(result, current, (j<b.Length) ? b : a, (j<b.Length) ? j : i);

            Console.WriteLine(string.Concat(Enumerable.Repeat("  ", depth*2)) + "Merged sub-array = [" + string.Join(",",result)+"]\n");
            return result;
        }

        private static void putRemaining(int[] arrayDestination, int current, int[] arrayOrigin, int index)
        {
            for (int i = index; i < arrayOrigin.Length; i++)
            {
                current++;
                arrayDestination[current] = arrayOrigin[i];
                
            }
        }
    }
}