using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace TracerTests
{
    [TestClass]
    public class TracerTests
    {
        private Tracer.Tracer tracer;
        int waittime = 200;

        [TestMethod]
        public void TestMethod1()
        {
            tracer = new Tracer.Tracer();
            tracer.StartTrace();
            Thread.Sleep(waittime);
            tracer.StopTrace();
            long actualtime = tracer.GetTraceResult().Threads[0].Time;
            Assert.IsTrue(actualtime >= waittime);
        }
    }
}
