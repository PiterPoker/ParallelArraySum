using System;
using System.Collections.Generic;
using ParallelArraySum.Calculators.Interfaces;
using ParallelArraySum.Calculators;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelArraySum;

///<summary>
/// Program to compare the performance of sequential, parallel, and LINQ-based array summation.
///</summary>
public class Program
{
    ///<summary>
    /// The main program entry point.  Tests array summation methods with different array sizes.
    ///</summary>
    ///<param name="args">Command-line arguments (not used).</param>
    public static void Main(string[] args)
    {
        int[][] arrays = [
            [.. Enumerable.Range(0, 100000)], 
            [.. Enumerable.Range(0, 1000000)], 
            [.. Enumerable.Range(0, 10000000)]
        ];

        var sequentialCalc = new SequentialSumCalculator();
        var parallelCalc = new ParallelSumCalculator(Environment.ProcessorCount);
        var linqCalc = new LinqSumCalculator();

        foreach (var array in arrays)
        {
            Console.WriteLine($"Measurements for an array of {array.Length} elements:");
            RunTest(sequentialCalc, array, (message) => Console.WriteLine($"Sequential computing: {message}"));
            RunTest(parallelCalc, array, (message) => Console.WriteLine($"Parallel computing: {message}"));
            RunTest(linqCalc, array, (message) => Console.WriteLine($"LINQ: {message}"));
        }
    }

    ///<summary>
    /// Runs a test with the specified calculator and array, measuring execution time.
    ///</summary>
    ///<param name="calculator">The summation calculator to use.</param>
    ///<param name="array">The input integer array.</param>
    ///<param name="actionResult">An action to handle the test results (time and sum).</param>
    private static void RunTest(ISumCalculator calculator, int[] array, Action<string> actionResult)
    {
        Measure(() => calculator.CalculateSum(array), actionResult);
    }

    ///<summary>
    ///  Measures the execution time of a given calculation.
    ///</summary>
    ///<param name="calculation">The calculation to time.</param>
    ///<param name="actionResult">An action to handle the timing result.</param>
    private static void Measure(Func<long> calculation, Action<string> actionResult)
    {
        var stopwatch = Stopwatch.StartNew();
        long result = calculation();
        stopwatch.Stop();

        actionResult($"{stopwatch.ElapsedMilliseconds} ms, Result: {result}");
    }
}
