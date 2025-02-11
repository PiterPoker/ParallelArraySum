
using ParallelArraySum.Calculators.Interfaces;

namespace ParallelArraySum.Calculators;

public class LinqSumCalculator : ISumCalculator
{
    public long CalculateSum(int[] array)
    {
        return array.AsParallel().Sum(a=>(long)a);
    }
}