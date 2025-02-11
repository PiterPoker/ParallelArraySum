using ParallelArraySum.Calculators.Interfaces;

namespace ParallelArraySum.Calculators;

///<summary>
/// Calculates the sum of elements in an integer array using parallel processing.
///</summary>
public class ParallelSumCalculator : ISumCalculator
{
    ///<summary>
    /// The number of threads to use for parallel processing.
    ///</summary>
    private int _threadCount;
    /// <summary>
    /// A shared resource used to accumulate the sum across threads.  Using Interlocked.Add for thread safety.
    ///</summary>
    private long _usingResource = 0;
    
    ///<summary>
    /// Initializes a new instance of the <see cref="T:ParallelArraySum.Calculators.ParallelSumCalculator"/> class.
    ///</summary>
    ///<param name="threadCount">The number of threads to use for parallel processing.</param>
    public ParallelSumCalculator(int threadCount)
    {
        _threadCount = threadCount;
    }

    ///<summary>
    /// Calculates the sum of elements in the given integer array using parallel processing.
    ///</summary>
    ///<param name="array">The input integer array.</param>
    ///<returns>The sum of all elements in the array.</returns>
    public long CalculateSum(int[] array)
    {
        try
        {
            int chunkSize = array.Length / _threadCount;
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < _threadCount; i++)
            {
                int start = i * chunkSize;
                int end = (i == _threadCount - 1) ? array.Length : start + chunkSize;
                Thread thread = GetThreadSum(array, start, end);
                threads.Add(thread);
                thread.Start();
            }

            ThreadWaitAll(threads);

            return _usingResource;

        }
        finally
        {
            _usingResource = 0;
        }
    }
    ///<summary>
    /// Waits for all threads in the given list to complete.
    ///</summary>
    ///<param name="threads">The list of threads to wait for.</param>
    private static void ThreadWaitAll(List<Thread> threads)
    {
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }

    ///<summary>
    /// Creates a new thread that calculates the sum of a portion of the array.
    ///</summary>
    ///<param name="array">The input array.</param>
    ///<param name="start">The starting index of the portion to sum.</param>
    ///<param name="end">The ending index (exclusive) of the portion to sum.</param>
    ///<returns>A new Thread object configured to calculate the sum of a portion of the array.</returns>
    private Thread GetThreadSum(int[] array, int start, int end)
    {
        return new Thread(() =>
            {
                for (int j = start; j < end; j++)
                {
                    Interlocked.Add(ref _usingResource, array[j]);
                }
            });
    }
}