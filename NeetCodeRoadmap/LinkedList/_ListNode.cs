using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }

        public static ListNode Create(params int[] values)
        {
            var first = new ListNode(values[0]);

            var previous = first;
            for (int i = 1; i < values.Length; i++)
            {
                var current = new ListNode(values[i]);
                previous.next = current;
                previous = current;
            }

            return first;
        }

        public override string ToString()
        {
            var values = new List<int> { val };
            var current = next;
            while (current != null)
            {
                values.Add(current.val);
                current = current.next;
            }

            return string.Join(", ", values);
        }
    } 
}
