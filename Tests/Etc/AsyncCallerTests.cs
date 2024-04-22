using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Etc;

namespace Tests.Etc
{
    [TestClass]
    public class AsyncCallerTests
    {
        private const int MS_1500 = 1500;

        private event EventHandler _testHandler;


        [TestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(2000)]
        [DataRow(5000)]
        public void AsyncCaller_DifferentTimeouts(int timeoutMs)
        {
            _testHandler += Sleep_1500ms;
            var asyncCaller = new AsyncCaller(_testHandler);
            var result = asyncCaller.Invoke(timeoutMs, null, EventArgs.Empty);

            // Всё что меньше 1500 true, больше - false;
            Assert.AreEqual(timeoutMs < MS_1500, result);
        }

        private void Sleep_1500ms(object? sender, EventArgs e)
        {
            Thread.Sleep(MS_1500);
        }
    }
}
