using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Trees
{
    internal class InvertBinaryTreeSolution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) { return null; }

            var newRoot = new TreeNode(root.val);

            newRoot.left = InvertTree(root.right);
            newRoot.right = InvertTree(root.left);

            return newRoot;
        }
    }
}
