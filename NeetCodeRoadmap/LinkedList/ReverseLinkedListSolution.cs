using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class ReverseLinkedListSolution
    {

        public ListNode ReverseList(ListNode head)
        {
            return Iterative(head);
        }

        private ListNode Iterative(ListNode head)
        {
            var stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }

            if (stack.Count == 0) { return null; }

            var headNode = new ListNode(stack.Pop());
            var previousNode = headNode;
            while (stack.Count > 0)
            {
                var item = stack.Pop();

                var newNode = new ListNode(item);
                previousNode.next = newNode;
                previousNode = newNode;
            }

            return headNode;
        }
    }
}
