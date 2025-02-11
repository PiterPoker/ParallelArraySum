
using ParallelArraySum.Calculators.Interfaces;

namespace ParallelArraySum.Calculators;

///<summary>
/// Calculates the sum of elements in an integer array using LINQ and parallel processing.
///</summary>
public class LinqSumCalculator : ISumCalculator
{
    ///<summary>
    /// Calculates the sum of elements in the given integer array using LINQ with parallel execution.
    ///</summary>
    ///<param name="array">The input integer array.</param>
    ///<returns>The sum of all elements in the array. Returns 0 if the array is null or empty.</returns>
    public long CalculateSum(int[] array)
    {
        return array.AsParallel().Sum(a=>(long)a);
    }
}