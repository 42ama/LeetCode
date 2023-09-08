using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Recursion
{
    internal class AddTwoNumbersSolution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry = 0)
        {

            if (l1 is null && l2 is null && carry == 0) { return null; }

            var number = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            var currentCarry = number / 10;
            if (currentCarry > 0)
            {
                number = number - 10;
                currentCarry = 1;
            }

            return new ListNode(number, AddTwoNumbers(l1?.next, l2?.next, currentCarry));
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
