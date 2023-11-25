using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class CopyListWithRandomPounterSolution
    {
        public Node Execute(Node head)
        {
            var nodes = new List<Node>();

            var newHead = new Node { val = head.val };
            var current = head.next;

            var last = newHead;
            while (true)
            {
                // Установили val
                var newCurrent = new Node { val = current.val };

                // Установили next
                last.next = newCurrent;

                // Установили random
                if (current.random < nodes.Count)
                {

                }
            }
        }

        public class Node : ListNode
        {
            // position of linked
            public Node random;

            // Hiding base.next;
            public Node next;

            public override string ToString()
            {
                // !!! Возмонжо уходит в рекурсию и ломает всё.
                return base.ToString() + $" random.val: {random.val}";
            }
        }
    }
}
