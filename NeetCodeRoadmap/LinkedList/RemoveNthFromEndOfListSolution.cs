using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class RemoveNthFromEndOfListSolution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var allNodes = new List<ListNode>();

            var current = head;
            do
            {
                allNodes.Add(current);
                current = current.next;
            } while (current != null);

            var index = allNodes.Count - n;
            var previousIndex = index - 1;
            if (previousIndex >= 0)
            {
                if (index == allNodes.Count - 1)
                {
                    // Если n крайний справа, то справа не будет соединения можно соединять с Null
                    allNodes[previousIndex].next = null;

                }
                else
                {
                    allNodes[previousIndex].next = allNodes[index + 1];
                }                
            }
            else
            {
                head = head.next;
            }

            return head;
        }
    }
}
