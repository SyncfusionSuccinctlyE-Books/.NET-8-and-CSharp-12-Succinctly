using System.Diagnostics;
using InterceptorDemo;

var random = new Random();
var largeArray = Enumerable.Range(0, 50000).Select(x => random.Next()).ToArray();

var sorter = new ArraySorter();

var stopwatch = Stopwatch.StartNew();

sorter.Sort(largeArray);

stopwatch.Stop();

Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
Console.ReadLine();

