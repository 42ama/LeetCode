using LeetCode.Etc;
using LeetCode.Etc.ConcurentServer;
using System.Diagnostics;

namespace Tests.Etc
{
    [TestClass]
    public class ConcurentServerTests
    {
        [TestMethod]
        public void Interlocked_Reading_DoesNotLocks()
        {
            Reading(ConcurentServer_Interlocked.GetCount);
        }

        [TestMethod]
        public void Interlocked_ReadingAndWriting_WritesCorreclty()
        {
            var expected = ReadingAndWriting(ConcurentServer_Interlocked.GetCount, ConcurentServer_Interlocked.AddToCount);

            Assert.AreEqual(expected, ConcurentServer_Interlocked.GetCount());   
        }

        [TestMethod]
        public void ReaderWriterLockSlim_Reading_DoesNotLocks()
        {
            Reading(ConcurentServer_ReaderWriterLockSlim.GetCount);
        }

        [TestMethod]
        public void ReaderWriterLockSlim_ReadingAndWriting_WritesCorreclty()
        {
            var expected = ReadingAndWriting(ConcurentServer_ReaderWriterLockSlim.GetCount, ConcurentServer_ReaderWriterLockSlim.AddToCount);

            Assert.AreEqual(expected, ConcurentServer_ReaderWriterLockSlim.GetCount());
        }

        private void Reading(Func<int> getFunc)
        {
            var cycles = 10000;
            Parallel.For(0, cycles, i =>
            {
                getFunc.Invoke();
            });
        }

        private int ReadingAndWriting(Func<int> getFunc, Action<int> addFunc)
        {
            var cycles = 10000;
            Parallel.For(0, cycles, i =>
            {
                if (i % 2 == 0)
                {
                    getFunc.Invoke();
                }
                else
                {
                    addFunc.Invoke(1);
                }
            });

            return cycles / 2;
        }
    }
}