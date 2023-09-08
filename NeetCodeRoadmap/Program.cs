using NeetCodeRoadmap.ArraysHashing;
using NeetCodeRoadmap.Stack;
using Newtonsoft.Json.Linq;

var jObject = JObject.Parse(@"{
  CPU: 'Intel',
  Drives: [
    'DVD read/writer',
    '500 gigabyte hard drive'
  ]
}");
foreach (var item in jObject)
{
    ;
}

var solution = new EvaluateReversePolishNotationSolution();
var result = solution.EvalRPN(new string[] { "4", "13", "5", "/", "+" });
Console.WriteLine(result);

