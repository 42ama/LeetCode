using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Recursion
{
    internal class MergeTwoListsSolution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) { return null; }

            if (list1 == null) { return new ListNode(list2.val, list2.next); }
            if (list2 == null) { return new ListNode(list1.val, list1.next); }

            if (list1.val < list2.val)
            {
                return new ListNode(list1.val, MergeTwoLists(list1.next, list2));
            }
            else
            {
                return new ListNode(list2.val, MergeTwoLists(list1, list2.next));
            }            
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
