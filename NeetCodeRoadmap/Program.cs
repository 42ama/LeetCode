using NeetCodeRoadmap.ArraysHashing;
using NeetCodeRoadmap.Stack;

var minStack = new MinStackNeetCodeSolution();
minStack.Push(-2);
minStack.Push(0);
minStack.Push(-3);
var a= minStack.GetMin(); // return -3
minStack.Pop();
var b = minStack.Top();    // return 0
var c = minStack.GetMin(); // return -2
;
