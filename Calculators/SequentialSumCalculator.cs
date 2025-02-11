using ParallelArraySum.Calculators.Interfaces;

namespace ParallelArraySum.Calculators;

public class SequentialSumCalculator : ISumCalculator
{
    public long CalculateSum(int[] array)
    {
        long sum = 0;
        foreach (int element in array)
        {
            sum += element;
        }
        return sum;
    }
}