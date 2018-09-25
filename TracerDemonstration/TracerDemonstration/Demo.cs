using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Tracer;

namespace TracerDemonstration
{
    internal class TestMethods
    {
        private ITracer _tracer;

        internal TestMethods(ITracer tracer)
        {
            _tracer = tracer;
        }

        internal void XMethod()
        {
            _tracer.StartTrace();

            Thread.Sleep(new Random().Next(10, 500));

            _tracer.StopTrace();
        }

        internal void XXMethod()
        {
            _tracer.StartTrace();

            Thread.Sleep(new Random().Next(10, 500));
            XMethod();

            _tracer.StopTrace();
        }

        internal void XXXMethod()
        {
            _tracer.StartTrace();

            Thread.Sleep(new Random().Next(10, 500));
            XXMethod();
            var threadList = new List<Thread>();
            threadList.Add(new Thread(XMethod));
            threadList.Add(new Thread(XXMethod));
            foreach (Thread thread in threadList)
            {
                thread.Start();
            }
            foreach (Thread thread in threadList)
            {
                thread.Join();
            }

            _tracer.StopTrace();
        }
    }

    class Demo
    {
        private static Tracer.Tracer tracer;

        static void Main(string[] args)
        {
            tracer = new Tracer.Tracer();
            var test = new TestMethods(tracer);
            test.XXXMethod();

            new ConsoleWriter().Write(new SerializerJSON(), tracer.GetTraceResult());
            string filename = "D:\\УНИВЕР\\5 семестр\\СПП\\ThreadsInfo.txt";
            new FileWriter(filename).Write(new SerializerXML(), tracer.GetTraceResult());        

            Console.ReadKey();
        }
    }
}