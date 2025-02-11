using ParallelArraySum.Calculators.Interfaces;

namespace ParallelArraySum.Calculators;

///<summary>
/// Calculates the sum of elements in an integer array using a sequential approach.
///</summary>
public class SequentialSumCalculator : ISumCalculator
{
    ///<summary>
    /// Calculates the sum of elements in the given integer array sequentially.
    ///</summary>
    ///<param name="array">The input integer array.</param>
    ///<returns>The sum of all elements in the array.</returns>
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