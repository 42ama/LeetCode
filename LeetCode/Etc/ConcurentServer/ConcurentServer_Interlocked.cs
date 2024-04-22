using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Etc
{
    /*
    Есть "сервер" в виде статического класса.  
    У него есть переменная count (тип int) и два метода, которые позволяют эту переменную читать и писать: GetCount() и AddToCount(int value). 
    К серверу стучатся множество параллельных клиентов, которые в основном читают, но некоторые добавляют значение к count. 

    Нужно реализовать GetCount / AddToCount так, чтобы: 
    читатели могли читать параллельно, без выстраивания в очередь по локу; 
    писатели писали только последовательно и никогда одновременно; 
    пока писатели добавляют и пишут, читатели должны ждать окончания записи. 
    */
    public static class ConcurentServer_Interlocked
    {
        private static int Count;

        public static int GetCount()
        {
            return Count;
        }

        public static void AddToCount(int value)
        {
            Interlocked.Add(ref Count, value);
        }
    }
}
