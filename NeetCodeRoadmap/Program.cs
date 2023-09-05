using NeetCodeRoadmap.ArraysHashing;
using NeetCodeRoadmap.Stack;

Console.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssz"));
Console.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"));
Console.WriteLine(DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssz"));
Console.WriteLine(DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssz"));
Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"));

var solution = new EvaluateReversePolishNotationSolution();
var result = solution.EvalRPN(new string[] { "4", "13", "5", "/", "+" });
Console.WriteLine(result);

