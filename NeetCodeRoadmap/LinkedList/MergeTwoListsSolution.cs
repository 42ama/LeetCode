using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.LinkedList
{
    internal class MergeTwoListsSolution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2  == null) { return null; }

            if (list1 == null) { return list2; }
            if (list2 == null) { return list1; }

            if (list1.next == null && list2.next == null)
            {
                return CompareTwoReturnSorted(list1, list2);
            }

            if (list1.next !=null && list2.next == null)
            {
                if (list1.val < list2.val)
                {
                    var merged = MergeTwoLists(list1.next, list2);
                    list1.next = merged;
                    return list1;
                }
                else
                {
                    list2.next = list1;
                    return list2;
                }
            }

            if (list1.next == null && list2.next != null)
            {
                if (list1.val < list2.val)
                {
                    list1.next = list2;
                    return list1;
                }
                else
                {
                    var merged = MergeTwoLists(list1, list2.next);
                    list2.next = merged;
                    return list2;
                }
            }

            // теперь мы в ситуации, когда у каждой ноды есть next
            if (list1.val < list2.val)
            {
                var merged = MergeTwoLists(list1.next, list2);
                list1.next = merged;
                return list1;
            }
            else
            {
                var merged = MergeTwoLists(list1, list2.next);
                list2.next = merged;
                return list2;
            }
        }

        private ListNode CompareTwoReturnSorted(ListNode list1, ListNode list2)
        {
            if (list1.val < list2.val)
            {
                list1.next = list2;
                return list1;
            }
            else
            {
                list2.next = list1;
                return list2;
            }
        }
    }
}
