using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class MethodInfo
    {
        private Stopwatch timer;
        private List<MethodInfo> insideMethods;        

        public MethodInfo()
        {
            timer = new Stopwatch();
            insideMethods = new List<MethodInfo>();           
        }

        public string Name { get; set; }
        public string ClassName { get; set; }

        public long Time
        {
            get
            {
                return timer.ElapsedMilliseconds;
            }
        }

        public string TimeStr { get { return Time.ToString() + "ms"; } set { } }

        public List<MethodInfo> InsideMethods
        {
            get
            {
                return new List<MethodInfo>(insideMethods);
            }
            set { }
        }        

        internal void StartTrace()
        {
            timer.Start();
        }

        internal void StopTrace()
        {
            timer.Stop();
        }

        internal void InsideMethodAdd(MethodInfo method)
        {
            insideMethods.Add(method);
        }
    }


    public class ThreadInfo
    {
        private Stack<MethodInfo> stackOfMethods;
        private List<MethodInfo> listOfExternalMethods;

        public int ThreadID { get; set; }

        internal ThreadInfo(int id)
        {
            ThreadID = id;
            stackOfMethods = new Stack<MethodInfo>();
            listOfExternalMethods = new List<MethodInfo>();
        }

        public string Time
        {
            get
            {
                long time = 0;
                foreach (MethodInfo method in listOfExternalMethods)
                {
                    time += method.Time;
                }
                return time.ToString();
            }
            set { }
        }

        public List<MethodInfo> InsideMethods
        {
            get
            {
                return new List<MethodInfo>(listOfExternalMethods);
            }
            set { }
        }

        protected void ThreadMethodAdd(MethodInfo method)
        {
            if (stackOfMethods.Count >= 1)
            {
                stackOfMethods.Peek().InsideMethodAdd(method);
            }
            else
            {
                listOfExternalMethods.Add(method);
            }
            stackOfMethods.Push(method);
        }

        internal void StartMethodTracing(MethodInfo method)
        {
            ThreadMethodAdd(method);
            method.StartTrace();
        }

        internal void StopMethodTracing()
        {
            stackOfMethods.Pop().StopTrace();
        }
    }


    public class TraceResult
    {
    }
}
