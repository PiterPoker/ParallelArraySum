namespace ParallelArraySum.Calculators.Interfaces;

///<summary>
/// Interface for calculating the sum of elements in an integer array.
///</summary>
public interface ISumCalculator
{
    /// <summary>
    /// Calculates the sum of elements in the given integer array.
    /// </summary>
    /// <param name="array">The integer array.</param>
    /// <returns>The sum of elements in the array.</returns>
    long CalculateSum(int[] array);
}