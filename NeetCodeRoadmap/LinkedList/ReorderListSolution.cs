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
            var reverseData = ReverseList(head);

            var current = head;
            var prev = current;
            var currentReverse = reverseData.Head;
            ListNode temp, tempReverse;
            var counter = reverseData.TotalCount % 2;
            while (counter < reverseData.TotalCount/2)
            {
                prev = current;
                temp = current.next;
                tempReverse = currentReverse.next;

                current.next = currentReverse;
                currentReverse.next = temp;

                current = temp;
                currentReverse = tempReverse;
                counter++;
            }

            Console.WriteLine(prev);
            Console.WriteLine(current);
            Console.WriteLine(currentReverse);
            //prev.next = null;
            //current.next = null;
            //currentReverse.next = null;
        }

        private (ListNode Head, int TotalCount) ReverseList(ListNode head)
        {
            var stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }

            var headNode = new ListNode(stack.Pop());
            var previousNode = headNode;
            var totalCount = stack.Count;
            while (stack.Count > 0)
            {
                var item = stack.Pop();

                var newNode = new ListNode(item);
                previousNode.next = newNode;
                previousNode = newNode;
            }

            return (headNode, totalCount + 1);
        }
    }
}
