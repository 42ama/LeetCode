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
            return Recurse(head.next, head);
        }

        private ListNode Recurse(ListNode current, ListNode previous)
        {
            if (current == null) { return null; }

            if (current.next == null)
            {
                var newNext = new ListNode(current.val);
                return newNext;
            }

            var newHead = Recurse(current.next, current);
            current.next = null;
            newHead.next = current;
            return current;
        }
    }
}
