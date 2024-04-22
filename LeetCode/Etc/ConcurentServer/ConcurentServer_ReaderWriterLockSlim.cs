using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Etc.ConcurentServer
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
    public static class ConcurentServer_ReaderWriterLockSlim
    {
        private static int Count;

        private static ReaderWriterLockSlim _readerWriterLockSlim;

        static ConcurentServer_ReaderWriterLockSlim()
        {
            _readerWriterLockSlim = new ReaderWriterLockSlim();
        }

        public static int GetCount()
        {
            _readerWriterLockSlim.EnterReadLock();
            try
            {
                return Count;
            }
            finally
            {
                _readerWriterLockSlim.ExitReadLock();
            }
            
        }

        public static void AddToCount(int value)
        {
            _readerWriterLockSlim.EnterWriteLock();
            try
            {
                Count += value;
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
            }
        }
    }
}
