using System;
using System.Collections.Generic;
using ParallelArraySum.Calculators.Interfaces;
using ParallelArraySum.Calculators;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelArraySum;

public class Program
{
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

    private static void RunTest(ISumCalculator calculator, int[] array, Action<string> actionResult)
    {
        Measure(() => calculator.CalculateSum(array), actionResult);
    }

    private static void Measure(Func<long> calculation, Action<string> actionResult)
    {
        var stopwatch = Stopwatch.StartNew();
        long result = calculation();
        stopwatch.Stop();

        actionResult($"{stopwatch.ElapsedMilliseconds} ms, Result: {result}");
    }
}
