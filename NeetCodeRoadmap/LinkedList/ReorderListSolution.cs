using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class ReorderListSolution
    {
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) { return; }

            var allNodes = new List<ListNode>();

            var current = head;
            do
            {
                allNodes.Add(current);
                current = current.next;
            } while (current != null);

            var firstPointer = 0;
            var lastPointer = allNodes.Count - 1;

            while (firstPointer != lastPointer)
            {
                var last = allNodes[lastPointer];
                last.next = null; // Нужно чтобы комп не решил просчитать циклический linked-list
                allNodes[firstPointer].next = last;

                firstPointer++;

                if (firstPointer == lastPointer) { return; }

                allNodes[firstPointer].next = null; // Нужно чтобы комп не решил просчитать циклический linked-list
                last.next = allNodes[firstPointer];
                lastPointer--;
            }
        }
    }
}
