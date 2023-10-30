using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class CopyListWithRandomPounterSolution
    {
        public RandomListNode Execute(RandomListNode head)
        {
            var nodes = new List<RandomListNode>();

            var newHead = new RandomListNode { val = head.val };
            var current = head.next;

            var last = newHead;
            while (true)
            {
                // Установили val
                var newCurrent = new RandomListNode { val = current.val };

                // Установили next
                last.next = newCurrent;

                // Установили random
                if (current.random < nodes.Count)
                {

                }
            }
        }

        public class RandomListNode : ListNode
        {
            // position of linked
            public int random;

            // Hiding base.next;
            public RandomListNode next;

            public override string ToString()
            {
                // !!! Возмонжо уходит в рекурсию и ломает всё.
                return base.ToString() + $" random: {random}";
            }
        }
    }
}
