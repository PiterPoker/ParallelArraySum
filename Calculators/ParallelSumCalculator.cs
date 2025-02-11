using ParallelArraySum.Calculators.Interfaces;

namespace ParallelArraySum.Calculators;

public class ParallelSumCalculator : ISumCalculator
{
    private int _threadCount;
    private long _usingResource = 0;

    public ParallelSumCalculator(int threadCount)
    {
        _threadCount = threadCount;
    }

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

    private static void ThreadWaitAll(List<Thread> threads)
    {
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }

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