using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Etc
{
    /*
     В .net есть возможность звать делегаты как синхронно: 
    EventHandler h = new EventHandler(this.myEventHandler); 
    h.Invoke(null, EventArgs.Empty); 
    так и асинхронно:
    var res = h.BeginInvoke(null, EventArgs.Empty, null, null);

    Нужно реализовать возможность полусинхронного вызова делегата (написать реализацию класса AsyncCaller), который бы работал таким образом: 

    EventHandler h = new EventHandler(this.myEventHandler); 
    ac = new AsyncCaller(h); 
    bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);

    "Полусинхронного" в данном случае означает, что делегат будет вызван, и вызывающий поток будет ждать, пока вызов не выполнится.  Но если выполнение делегата займет больше 5000 миллисекунд, то ac.Invoke выйдет и вернет в completedOK значение false.
    */
    public class AsyncCaller
    {
        private EventHandler _handler;

        private bool _isCallFinished = false;

        private const int ONE_ITERATION_MS = 100;

        public AsyncCaller(EventHandler handler)
        {
            _handler = handler;
        }

        public bool Invoke(int timeoutMs, object? sender, EventArgs e)
        {
            // Простая реализация, но с ограничением. В худшем случае от времени завершения кода до получения результата ждём ONE_ITERATION_MS. Плюс тратим дополнительное время на проверки.
            _handler.BeginInvoke(sender, e, ar =>
            {
                _isCallFinished = true;
            }, null);

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            while (!_isCallFinished)
            {
                Thread.Sleep(ONE_ITERATION_MS);
                if (stopwatch.ElapsedMilliseconds >= timeoutMs)
                {
                    break;
                }
            }

            stopwatch.Stop();

            return _isCallFinished;
        }
    }
}
