using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Trees
{
    internal class MaxDepthSolution
    {
        public int MaxDepth_Recursive_DFS(TreeNode root)
        {
            if (root == null) { return 0;}
            var depth = 1;

            var leftDepth = MaxDepth_Recursive_DFS(root.left);
            var rightDepth = MaxDepth_Recursive_DFS(root.right);

            return 1 + Math.Max(leftDepth, rightDepth);
        }

        public int MaxDepth_Iterative_DFS(TreeNode root)
        {
            if (root == null) { return 0; }

            var maximumLevel = 1;
            var stack = new Stack<(TreeNode node, int depth)>();

            stack.Push((root, maximumLevel));

            while (stack.Count > 0)
            {
                var nodeInfo = stack.Pop();

                if (nodeInfo.node == null)
                {
                    continue;
                }

                maximumLevel = Math.Max(maximumLevel, nodeInfo.depth);
                stack.Push((nodeInfo.node.left, nodeInfo.depth + 1));
                stack.Push((nodeInfo.node.right, nodeInfo.depth + 1));
            }

            return maximumLevel;
        }

        public int MaxDepth_BFS(TreeNode root)
        {
            if (root == null) { return 0; }

            var currentLevel = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var nodesOnInspection = new List<TreeNode>();
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    nodesOnInspection.Add(node);
                }

                foreach (var node in nodesOnInspection)
                {
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                currentLevel++;
            }

            return currentLevel;

        }
    }
}
