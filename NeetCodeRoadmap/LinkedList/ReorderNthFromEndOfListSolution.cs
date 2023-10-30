using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class ReorderNthFromEndOfListSolution
    {
        public void Execute(ListNode head, int n)
        {
            var allNodes = new List<ListNode>();

            var current = head;
            do
            {
                allNodes.Add(current);
                current = current.next;
            } while (current != null);

            // Если n крайний справа, то справа не будет соединения можно соединять с Null
            if (n == allNodes.Count - 1)
            {
                allNodes[n - 1].next = null;
            }
            else
            {
                allNodes[n - 1].next = allNodes[n + 1];
            }
        }
    }
}
