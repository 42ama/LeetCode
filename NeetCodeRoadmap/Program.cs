using NeetCodeRoadmap.ArraysHashing;

var solutionOnTest = new EncodeDecodeSolution_OutOfContest();

var testData = new List<string> { "we", "say", ":", "yes", "or fucking no", "what do you", "not", " ", "", "understand" };
var result = solutionOnTest.Encode(testData);

Console.WriteLine($"Encoded: {result}");
Console.WriteLine($"Decoded: {string.Join(",", solutionOnTest.Decode(result))}");