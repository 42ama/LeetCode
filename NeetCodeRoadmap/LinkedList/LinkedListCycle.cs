using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class LinkedListCycle
    {
        public bool HasCycle_1(ListNode head)
        {
            var set = new HashSet<ListNode>();
            var current = head;
            while (current != null)
            {
                if (set.Contains(current))
                {
                    return true;
                }

                set.Add(current);
                current = current.next;
            }

            return false;
        }

        public bool HasCycle_2(ListNode head)
        {
            var slow = head;
            var fast = head?.next;

            while (fast != null)
            {
                if (slow == fast)
                {
                    return true;
                }

                slow = slow?.next;
                fast = fast?.next?.next;
            }

            return false;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
